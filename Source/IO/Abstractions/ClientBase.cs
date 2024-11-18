// ******************************************************************************************
//     Assembly:                Bubba
//     Author:                  Terry D. Eppler
//     Created:                 11-15-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        11-15-2024
// ******************************************************************************************
// <copyright file="ClientBase.cs" company="Terry D. Eppler">
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
//   ClientBase.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Text;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    public abstract class ClientBase : PropertyChangedBase
    {
        /// <summary>
        /// The busy
        /// </summary>
        private protected bool _busy;

        /// <summary>
        /// The is connected
        /// </summary>
        private protected bool _isConnected;

        /// <summary>
        /// The bytes
        /// </summary>
        private protected int _count;

        /// <summary>
        /// The data
        /// </summary>
        private protected byte[ ] _data;

        /// <summary>
        /// The ip address
        /// </summary>
        private protected IPAddress _address;

        /// <summary>
        /// The ip end point
        /// </summary>
        private protected IPEndPoint _endPoint;

        /// <summary>
        /// The message
        /// </summary>
        private protected string _message;

        /// <summary>
        /// The locked object
        /// </summary>
        private protected object _entry;

        /// <summary>
        /// The port
        /// </summary>
        private protected int _port;

        /// <summary>
        /// The socket
        /// </summary>
        private protected Socket _socket;

        /// <summary>
        /// Pings the network.
        /// </summary>
        /// <param name="ipAddress">
        /// The host name or address.
        /// </param>
        /// <returns>
        /// bool
        /// </returns>
        private protected virtual bool PingNetwork( string ipAddress )
        {
            var _status = false;
            try
            {
                ThrowIf.Null( ipAddress, nameof( ipAddress ) );
                using var _ping = new Ping( );
                var _buffer = Encoding.ASCII.GetBytes( "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" );
                var _timeout = 5000;// 5 sec
                var _reply = _ping.Send( ipAddress, _timeout, _buffer );
                if( _reply != null )
                {
                    _status = _reply.Status == IPStatus.Success;
                }
            }
            catch( Exception ex )
            {
                _status = false;
                Fail( ex );
            }

            return _status;
        }

        /// <summary>
        /// Notifies this instance.
        /// </summary>
        private protected virtual void SendNotification( string message )
        {
            try
            {
                ThrowIf.Null( message, nameof( message ) );
                var _notify = new SplashMessage( message );
                _notify.Show( );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Begins the initialize.
        /// </summary>
        private protected virtual void Busy( )
        {
            try
            {
                lock( _entry )
                {
                    _busy = true;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Ends the initialize.
        /// </summary>
        private protected virtual void Chill( )
        {
            try
            {
                lock( _entry )
                {
                    _busy = false;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is busy.
        /// </summary>
        /// <value>
        /// <c> true </c>
        /// if this instance is busy; otherwise,
        /// <c> false </c>
        /// </value>
        public virtual bool IsBusy
        {
            get
            {
                lock( _entry )
                {
                    return _busy;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// this instance is connected.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is connected;
        /// otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                if( _isConnected != value )
                {
                    _isConnected = value;
                    OnPropertyChanged( nameof( IsConnected ) );
                }
            }
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public virtual byte[ ] Data
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

        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>
        /// The ip address.
        /// </value>
        public virtual IPAddress Address
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

        /// <summary>
        /// Gets or sets the end point.
        /// </summary>
        /// <value>
        /// The end point.
        /// </value>
        public virtual IPEndPoint EndPoint
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
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public virtual string Message
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

        /// <summary>
        /// Gets or sets the socket.
        /// </summary>
        /// <value>
        /// The socket.
        /// </value>
        public virtual Socket Socket
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

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public virtual int Port
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

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected void Fail(Exception ex)
        {
            var _error = new ErrorWindow(ex);
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}