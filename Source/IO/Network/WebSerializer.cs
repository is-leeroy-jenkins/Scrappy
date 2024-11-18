
namespace Scrappy
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Net;
    using Newtonsoft.Json;

    public static class WebSerializer
    {
        /// <summary>
        /// Serializes an object to a JSON string.
        /// </summary>
        /// <typeparam name="T">The type of the object to serialize.</typeparam>
        /// <param name="data">The object to serialize.</param>
        /// <returns>JSON string representation of the object.</returns>
        public static string Serialize<T>( T data )
        {
            return JsonConvert.SerializeObject( data );
        }

        /// <summary>
        /// Deserializes a JSON string to an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        /// <param name="json">The JSON string to deserialize.</param>
        /// <returns>Deserialized object of the specified type.</returns>
        public static T Deserialize<T>( string json )
        {
            return JsonConvert.DeserializeObject<T>( json );
        }

        /// <summary>
        /// Sends a POST request with a JSON payload and receives the JSON response.
        /// </summary>
        /// <typeparam name="TRequest">Type of the request object to serialize.</typeparam>
        /// <typeparam name="TResponse">Type of the response object to deserialize.</typeparam>
        /// <param name="url">The URL to send the request to.</param>
        /// <param name="requestData">The object to be serialized and sent as JSON.</param>
        /// <returns>Deserialized response object.</returns>
        public static TResponse SendJsonPostRequest<TRequest, TResponse>( string url,
            TRequest requestData )
        {
            // Create the WebRequest
            var _request = WebRequest.Create( url );
            _request.Method = "POST";
            _request.ContentType = "application/json";

            // Serialize the request data to JSON
            var _jsonPayload = Serialize( requestData );
            using( var _streamWriter = new StreamWriter( _request.GetRequestStream( ) ) )
            {
                _streamWriter.Write( _jsonPayload );
            }

            // Send the request and get the response
            using( var _response = _request.GetResponse( ) )
            {
                using( var _responseStream = _response.GetResponseStream( ) )
                {
                    using( var _reader = new StreamReader( _responseStream ) )
                    {
                        var _jsonResponse = _reader.ReadToEnd( );

                        // Deserialize the JSON response into the specified type
                        return Deserialize<TResponse>( _jsonResponse );
                    }
                }
            }
        }

        /// <summary>
        /// Sends a GET request and receives the JSON response.
        /// </summary>
        /// <typeparam name="TResponse">
        /// Type of the response object to deserialize.
        /// </typeparam>
        /// <param name="url">The URL to send the request to.</param>
        /// <returns>Deserialized response object.</returns>
        public static TResponse SendJsonGetRequest<TResponse>( string url )
        {
            // Create the WebRequest
            var _request = WebRequest.Create( url );
            _request.Method = "GET";
            _request.ContentType = "application/json";

            // Send the request and get the response
            using var _response = _request.GetResponse( );
            using var _responseStream = _response.GetResponseStream( );
            using var _reader = new StreamReader( _responseStream );
            var _jsonResponse = _reader.ReadToEnd( );

            // Deserialize the JSON response into the specified type
            return Deserialize<TResponse>( _jsonResponse );
        }
    }
}
