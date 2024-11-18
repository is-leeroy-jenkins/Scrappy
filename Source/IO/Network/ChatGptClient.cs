// ******************************************************************************************
//     Assembly:                Bubba
//     Author:                  Terry D. Eppler
//     Created:                 11-18-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        11-18-2024
// ******************************************************************************************
// <copyright file="ChatGptClient.cs" company="Terry D. Eppler">
//    Bubba is a small windows (wpf) application for interacting with
//    Chat GPT that's developed in C-Sharp under the MIT license
// 
//    Copyright ©  2020-2024 Terry D. Eppler
// 
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the “Software”),
//    to deal in the Software without restriction,
//    including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense,
//    and/or sell copies of the Software,
//    and to permit persons to whom the Software is furnished to do so,
//    subject to the following conditions:
// 
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.
// 
//    THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//    INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT.
//    IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
//    DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//    DEALINGS IN THE SOFTWARE.
// 
//    You can contact me at:  terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   ChatGptClient.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Exception = System.Exception;
    using JsonSerializer = System.Text.Json.JsonSerializer;

    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class ChatGptClient : ChatGptBase
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.ChatGptClient" /> class.
        /// </summary>
        public ChatGptClient( ) 
            : base( )
        {
            _apiKey = "App.KEY";
            _presence = double.Parse( "0.0" );
            _frequency = double.Parse( "0.0" );
            _temperature = "0.5";
            _maximumTokens = "2048";
            _model = "gpt-3.5-turbo";
            _baseUrl = "https://api.openai.com/v1/chat/completions";
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Scrappy.ChatGptClient" /> class.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        /// <param name="maximum">The maximum.</param>
        /// <param name="chatModel">The chat model.</param>
        public ChatGptClient( string temperature, string maximum, string chatModel ) 
            : this( )
        {
            _apiKey = "App.KEY";
            _presence = double.Parse( "0.0" );
            _frequency = double.Parse( "0.0" );
            _temperature = temperature;
            _maximumTokens = maximum;
            _model = chatModel;
            _baseUrl = "https://api.openai.com/v1/chat/completions";
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserId
        {
            get
            {
                return _userId;
            }
            private set
            {
                _userId = value;
            }
        }

        /// <summary>
        /// Gets the frequency.
        /// </summary>
        /// <value>
        /// The frequency.
        /// </value>
        public double Frequency
        {
            get
            {
                return _frequency;
            }
            private set
            {
                _frequency = value;
            }
        }

        /// <summary>
        /// Gets the temperature.
        /// </summary>
        /// <value>
        /// The temperature.
        /// </value>
        public string Temperature
        {
            get
            {
                return _temperature;
            }
            private set
            {
                _temperature = value;
            }
        }

        /// <summary>
        /// Gets the presence.
        /// </summary>
        /// <value>
        /// The presence.
        /// </value>
        public double Presence
        {
            get
            {
                return _presence;
            }
            private set
            {
                _presence = value;
            }
        }

        /// <summary>
        /// Gets the maximum tokens.
        /// </summary>
        /// <value>
        /// The maximum tokens.
        /// </value>
        public string MaximumTokens
        {
            get
            {
                return _maximumTokens;
            }
            private set
            {
                _maximumTokens = value;
            }
        }

        /// <summary>
        /// Gets the chat model.
        /// </summary>
        /// <value>
        /// The chat model.
        /// </value>
        public string Model
        {
            get
            {
                return _model;
            }
            private set
            {
                _model = value;
            }
        }

        /// <summary>
        /// Gets the prompt.
        /// </summary>
        /// <value>
        /// The prompt.
        /// </value>
        public string Prompt
        {
            get
            {
                return _prompt;
            }
            private set
            {
                _prompt = value;
            }
        }

        /// <summary>
        /// Sends a request to the Chat (Assistant) API.
        /// </summary>
        public async Task<string> GetResponseAsync( List<dynamic> messages, string model = "gpt-4",
            int maxTokens = 150, double temperature = 0.7 )
        {
            var _payload = new
            {
                model,
                messages,
                max_tokens = maxTokens,
                temperature
            };

            return await SendRequestAsync( $"{_baseUrl}/chat/completions", _payload );
        }

        /// <summary>
        /// Handles POST requests and response parsing.
        /// </summary>
        private async Task<string> SendRequestAsync( string url, object payload )
        {
            var _serial = JsonConvert.SerializeObject( payload );
            var _content = new StringContent( _serial, Encoding.UTF8, "application/json" );
            _httpClient.DefaultRequestHeaders.Clear( );
            _httpClient.DefaultRequestHeaders.Add( "Authorization", $"Bearer {_apiKey}" );
            var _response = await _httpClient.PostAsync( url, _content );
            if( !_response.IsSuccessStatusCode )
            {
                var _msg =
                    $"Error: {_response.StatusCode}, {await _response.Content.ReadAsStringAsync( )}";

                throw new Exception( _msg );
            }

            var _responseJson = await _response.Content.ReadAsStringAsync( );
            dynamic _result = JsonConvert.DeserializeObject( _responseJson );

            // Extract the relevant part of the response for each API
            if( url.Contains( "/completions" ) )
            {
                return _result?.choices[ 0 ]?.text ?? "No response.";
            }
            else if( url.Contains( "/chat/completions" ) )
            {
                return _result?.choices[ 0 ]?.message?.content ?? "No response.";
            }

            return "Unexpected response format.";
        }

        /// <summary>
        /// Sends the HTTP message.
        /// </summary>
        /// <param name="prompt">The question.</param>
        /// <returns></returns>
        public string SendHttpMessage( string prompt )
        {
            try
            {
                ThrowIf.Null( prompt, nameof( prompt ) );
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                    | SecurityProtocolType.Tls11;

                var _chatModel = _model;
                var _url = _chatModel.Contains( "gpt-3.5-turbo" )
                    ? "https://api.openai.com/v1/chat/completions"
                    : "https://api.openai.com/v1/completions";

                // Validate randomness (temperature)
                var _temp = double.Parse( _temperature );
                var _requestData = CreatePayload( prompt, _chatModel, _temp );
                var _request = WebRequest.Create( _url );
                _request.Method = "POST";
                _request.ContentType = "application/json";
                _request.Headers.Add( "Authorization", $"Bearer {_apiKey}" );
                using var _requestStream = _request.GetRequestStream( );
                using var _writer = new StreamWriter( _requestStream );
                _writer.Write( _requestData );
                using var _response = _request.GetResponse( );
                using var _responseStream = _response.GetResponseStream( );
                if( _responseStream == null )
                {
                    return string.Empty;
                }

                using var _reader = new StreamReader( _responseStream );
                var _jsonResponse = _reader.ReadToEnd( );
                return ExtractMessageFromResponse( _jsonResponse, _chatModel );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        // Helper method to build the request payload
        /// <summary>
        /// Builds the request data.
        /// </summary>
        /// <param name="prompt">The question.</param>
        /// <param name="chatModel">The chat model.</param>
        /// <param name="temperature">The temperature.</param>
        /// <returns></returns>
        private string CreatePayload( string prompt, string chatModel, double temperature )
        {
            var _maxTokens = int.Parse( _maximumTokens );
            var _id = _userId.ToString( );
            if( chatModel.Contains( "gpt-3.5-turbo" ) )
            {
                return JsonSerializer.Serialize( new
                {
                    model = chatModel,
                    messages = new[ ]
                    {
                        new
                        {
                            role = "user",
                            content = prompt
                        }
                    }
                } );
            }
            else
            {
                return JsonSerializer.Serialize( new
                {
                    model = chatModel,
                    prompt,
                    max_tokens = _maxTokens,
                    user = _id,
                    temperature,
                    frequency_penalty = 0.0,
                    presence_penalty = 0.0,
                    stop = new[ ]
                    {
                        "#",
                        ";"
                    }
                } );
            }
        }

        /// <summary>
        /// Extracts the message from response.
        /// Helper method to extract the message from the JSON response
        /// </summary>
        /// <param name="response">The json response.</param>
        /// <param name="chatModel">The chat model.</param>
        /// <returns></returns>
        private string ExtractMessageFromResponse( string response, string chatModel )
        {
            using var _document = JsonDocument.Parse( response );
            var _root = _document.RootElement;
            if( chatModel.Contains( "gpt-3.5-turbo" ) )
            {
                var _choices = _root.GetProperty( "choices" );
                if( _choices.ValueKind == JsonValueKind.Array
                    && _choices.GetArrayLength( ) > 0 )
                {
                    var _element = _choices[ 0 ].GetProperty( "message" );
                    return _element.GetProperty( "content" ).GetString( );
                }
            }
            else
            {
                return _root.GetProperty( "choices" )[ 0 ].GetProperty( "text" ).GetString( );
            }

            return string.Empty;
        }

        public async Task<string> SendHttpMessageAsync( string prompt )
        {
            var _temp = double.Parse( _temperature );
            var _apiUrl = _model.Contains( "gpt-3.5-turbo" )
                ? "https://api.openai.com/v1/chat/completions"
                : "https://api.openai.com/v1/completions";

            // Prepare request payload
            string _payload;
            if( _model.Contains( "gpt-3.5-turbo" ) )
            {
                _payload = JsonSerializer.Serialize( new
                {
                    model = _model,
                    messages = new[ ]
                    {
                        new
                        {
                            role = "user",
                            content = PadQuotes( prompt )
                        }
                    }
                } );
            }
            else
            {
                _payload = JsonSerializer.Serialize( new
                {
                    model = _model,
                    prompt = PadQuotes( prompt ),
                    max_tokens = int.Parse( _maximumTokens ),
                    temperature = _temp,
                    user = _userId,
                    frequency_penalty = 0.0,
                    presence_penalty = 0.0,
                    stop = new[ ]
                    {
                        "#",
                        ";"
                    }
                } );
            }

            try
            {
                using var _client = new HttpClient( );
                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue( "Bearer", _apiKey );

                var _content = new StringContent( _payload, Encoding.UTF8, "application/json" );
                var _response = await _client.PostAsync( _apiUrl, _content );
                _response.EnsureSuccessStatusCode( );
                var _responseText = await _response.Content.ReadAsStringAsync( );
                if( _model.Contains( "gpt-3.5-turbo" ) )
                {
                    using var _doc = JsonDocument.Parse( _responseText );
                    var _root = _doc.RootElement;
                    var _choice = _root.GetProperty( "choices" )[ 0 ];
                    var _message = _choice.GetProperty( "message" ).GetProperty( "content" )
                        .GetString( );

                    return _message ?? string.Empty;
                }
                else
                {
                    using var _doc = JsonDocument.Parse( _responseText );
                    var _root = _doc.RootElement;
                    var _choice = _root.GetProperty( "choices" )[ 0 ];
                    var _text = _choice.GetProperty( "text" ).GetString( );
                    return _text ?? string.Empty;
                }
            }
            catch( HttpRequestException ex )
            {
                Fail( ex );
                return string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }
    }
}