// ******************************************************************************************
//     Assembly:                Bubba
//     Author:                  Terry D. Eppler
//     Created:                 11-15-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        11-15-2024
// ******************************************************************************************
// <copyright file="BabyBoy.cs" company="Terry D. Eppler">
//    Bubba is an open source windows (wpf) application for interacting with OpenAI GPT
//    that is based on NET 7 and written in C-Sharp.
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
//   BabyBoy.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using Scrappy;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ReplaceAutoPropertyWithComputedProperty" ) ]
    public class BabyBoy : ClientBase
    {
        /// <summary>
        /// Gets or sets the bytes.
        /// </summary>
        /// <value>
        /// The bytes.
        /// </value>
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                if( _count != value )
                {
                    _count = value;
                    OnPropertyChanged( nameof( Count ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public override int Port
        {
            get
            {
                return _port;
            }
            set
            {
                if( _port != value )
                {
                    _port = value;
                    OnPropertyChanged( nameof( Port ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the buffer.
        /// </summary>
        /// <value>
        /// The buffer.
        /// </value>
        public override byte[ ] Data
        {
            get
            {
                return _data;
            }
            set
            {
                if( _data != value )
                {
                    _data = value;
                    OnPropertyChanged( nameof( Data ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public override string Message
        {
            get
            {
                return _message;
            }
            set
            {
                if( _message != value )
                {
                    _message = value;
                    OnPropertyChanged( nameof( Message ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        public override Socket Socket
        {
            get
            {
                return _socket;
            }
            set
            {
                if( _socket != value )
                {
                    _socket = value;
                    OnPropertyChanged( nameof( Socket ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the local.
        /// </summary>
        /// <value>
        /// The local.
        /// </value>
        public override IPAddress Address
        {
            get
            {
                return _address;
            }
            set
            {
                if( _address != value )
                {
                    _address = value;
                    OnPropertyChanged( nameof( Address ) );
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the local.
        /// </summary>
        /// <value>
        /// The local.
        /// </value>
        public override IPEndPoint EndPoint
        {
            get
            {
                return _endPoint;
            }
            set
            {
                if( _endPoint != value )
                {
                    _endPoint = value;
                    OnPropertyChanged( nameof( EndPoint ) );
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BabyBoy"/> class.
        /// </summary>
        public BabyBoy( )
        {
            _entry = new object( );
            _count = 1024;
            _port = 5000;
            _data = new byte[ _count ];
            _address = IPAddress.Any;
            _endPoint = new IPEndPoint( _address, _port );
            _socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            _isConnected = false;
            _busy = false;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BabyBoy"/> class.
        /// </summary>
        /// <param name="address">The ip address.</param>
        /// <param name="port">The port number.</param>
        /// <param name="size">Size of the buffer.</param>
        public BabyBoy( string address, int port = 5000, int size = 1024 )
        {
            _count = size;
            _port = port;
            _data = new byte[ size ];
            _address = IPAddress.Parse( address );
            _endPoint = new IPEndPoint( _address, port );
            _socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            _isConnected = false;
            _busy = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BabyBoy"/> class.
        /// </summary>
        /// <param name="address">The ip ipAddress.</param>
        /// <param name="port">The port.</param>
        /// <param name="size"> </param>
        public BabyBoy( IPAddress address, int port = 5000, int size = 1024 )
        {
            _count = size;
            _port = port;
            _data = new byte[ size ];
            _address = address;
            _endPoint = new IPEndPoint( address, port );
            _socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            _isConnected = false;
            _busy = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BabyBoy"/> class.
        /// </summary>
        /// <param name="endPoint">The ip address.</param>
        /// <param name="size">Size of the buffer.</param>
        public BabyBoy( IPEndPoint endPoint, int size = 1024 )
        {
            _count = size;
            _port = endPoint.Port;
            _data = new byte[ size ];
            _address = endPoint.Address;
            _endPoint = endPoint;
            _socket = new Socket( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
            _isConnected = false;
            _busy = false;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BabyBoy"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public BabyBoy( BabyBoy client )
        {
            _count = client.Count;
            _port = client.Port;
            _data = client.Data;
            _address = client.Address;
            _endPoint = client.EndPoint;
            _socket = client.Socket;
            _isConnected = client.IsConnected;
            _busy = client.IsBusy;
        }

        /// <summary>
        /// Connects this instance.
        /// </summary>
        public void Connect( )
        {
            try
            {
                _message = "You look like a baby!";
                _data = Encoding.ASCII.GetBytes( _message );
                _socket.Connect( _endPoint );
                _isConnected = _socket.Connected;
                _socket.Send( _data );
                SendNotification( _message );
            }
            catch( Exception ex )
            {
                _socket?.Dispose( );
                Fail( ex );
            }
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        public void SendMessage( )
        {
            try
            {
                _message = "You look like a baby!";
                _data = Encoding.ASCII.GetBytes( _message );
                if( _socket.Connected )
                {
                    _socket.Send( _data );
                    SendNotification( _message );
                }
                else
                {
                    _socket.Connect( _endPoint );
                    _isConnected = _socket.Connected;
                    _socket.Send( _data );
                }
            }
            catch( Exception ex )
            {
                _socket?.Dispose( );
                Fail( ex );
            }
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SendMessage( string message )
        {
            try
            {
                ThrowIf.Null( message, nameof( message ) );
                _message = message;
                _data = Encoding.ASCII.GetBytes( message );
                if( _socket.Connected )
                {
                    _socket.Send( _data );
                }
                else
                {
                    _socket.Connect( _endPoint );
                    _isConnected = _socket.Connected;
                    _socket.Send( _data );
                }
            }
            catch( Exception ex )
            {
                _socket?.Dispose( );
                Fail( ex );
            }
        }

        /// <summary>
        /// Notifies this instance.
        /// </summary>
        private void Notify( string message )
        {
            try
            {
                ThrowIf.Null( message, nameof( message ) );
                var _notify = new SplashMessage( message );
                _notify.Show( );
            }
            catch( Exception ex )
            {
                Socket?.Dispose( );
                Fail( ex );
            }
        }

        /// <summary>
        /// Deconstructs the specified bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="port">The port.</param>
        /// <param name="data">The data.</param>
        /// <param name="address">The ip address.</param>
        /// <param name="endPoint">The end point.</param>
        /// <param name="socket">The socket.</param>
        /// <param name="message">The message.</param>
        public void Deconstruct( out int bytes, out int port, out byte[ ] data,
            out IPAddress address, out IPEndPoint endPoint, out Socket socket,
            out string message )
        {
            bytes = Count;
            port = Port;
            data = Data;
            address = Address;
            endPoint = EndPoint;
            socket = Socket;
            message = Message;
        }
    }
}