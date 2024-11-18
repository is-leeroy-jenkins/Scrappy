// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-28-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-28-2024
// ******************************************************************************************
// <copyright file="SqlBuilder.cs" company="Terry D. Eppler">
//    Badger is data analysis and reporting tool for EPA Analysts.
//    Copyright ©  2024  Terry D. Eppler
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
//    You can contact me at: terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   SqlBuilder.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;

    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeRedundantParentheses" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWhenPossible" ) ]
    public class SqlBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        private EXT _extension;

        /// <summary>
        /// 
        /// </summary>
        private Source _source;

        /// <summary>
        /// 
        /// </summary>
        private Command _commandType;

        /// <summary>
        /// 
        /// </summary>
        private IList<string> _files;

        /// <summary>
        /// 
        /// </summary>
        private string _fileName;

        /// <summary>
        /// 
        /// </summary>
        private string _directoryPath;

        /// <summary>
        /// 
        /// </summary>
        private IDictionary<string, string> _commands;

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public Source Source
        {
            get
            {
                return _source;
            }
            private protected set
            {
                _source = value;
            }
        }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>
        /// The extension.
        /// </value>
        public EXT Extension
        {
            get
            {
                return _extension;
            }
            private protected set
            {
                _extension = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the command.
        /// </summary>
        /// <value>
        /// The type of the command.
        /// </value>
        public Command CommandType
        {
            get
            {
                return _commandType;
            }
            private protected set
            {
                _commandType = value;
            }
        }

        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        public IList<string> Files
        {
            get
            {
                return _files;
            }
            private protected set
            {
                _files = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName
        {
            get
            {
                return _fileName;
            }
            private protected set
            {
                _fileName = value;
            }
        }

        /// <summary>
        /// Gets or sets the directory path.
        /// </summary>
        /// <value>
        /// The directory path.
        /// </value>
        public string DirectoryPath
        {
            get
            {
                return _directoryPath;
            }
            private protected set
            {
                _directoryPath = value;
            }
        }

        /// <summary>
        /// Gets or sets the commands.
        /// </summary>
        /// <value>
        /// The commands.
        /// </value>
        public IDictionary<string, string> Commands
        {
            get
            {
                return _commands;
            }
            private protected set
            {
                _commands = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SqlBuilder"/>
        /// class.
        /// </summary>
        public SqlBuilder( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SqlBuilder"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="commandType"> Type of the command. </param>
        /// <param name="ext"> The ext. </param>
        public SqlBuilder( Source source, Command commandType, EXT ext )
        {
            _source = source;
            _commandType = commandType;
            _extension = ext;
            _directoryPath = CreateRepositoryPath( );
            _files = Directory.GetFiles( _directoryPath );
            _commands = GetCommands( );
        }

        /// <summary>
        /// Gets the command text.
        /// </summary>
        /// <param name="commandName">
        /// Name of the command.
        /// </param>
        /// <returns></returns>
        public string GetCommandText( string commandName )
        {
            if( !string.IsNullOrEmpty( commandName )
                && ( _commands?.Any( ) == true )
                && ( _commands.Keys?.Contains( commandName ) == true ) )
            {
                try
                {
                    return Commands[ commandName ];
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the command text.
        /// </summary>
        /// <param name="sqlCommand">
        /// The SQL command.
        /// </param>
        /// <returns></returns>
        public string GetCommandText( Command sqlCommand )
        {
            if( Enum.IsDefined( typeof( Command ), sqlCommand )
                && ( _commands?.Any( ) == true )
                && ( _commands.Keys?.Contains( $"{sqlCommand}" ) == true ) )
            {
                try
                {
                    return _commands[ $"{sqlCommand}" ];
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the SQL directory path.
        /// </summary>
        /// <returns></returns>
        private string CreateRepositoryPath( )
        {
            if( Enum.IsDefined( typeof( EXT ), _extension ) )
            {
                try
                {
                    var _path = ConfigurationManager.AppSettings[ $"{_extension}" ];
                    if( _path != null )
                    {
                        var _index = _path.LastIndexOf( @"\" );
                        var _size = _path.Length;
                        var _end = _size - _index;
                        var _folder = $@"\{_commandType}";
                        var _remove = _path?.Remove( _index, _end );
                        var _dirPath = _remove + _folder;
                        return Directory.Exists( _dirPath )
                            ? _dirPath
                            : string.Empty;
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the commands.
        /// </summary>
        /// <returns></returns>
        private IDictionary<string, string> GetCommands( )
        {
            if( Enum.IsDefined( typeof( Command ), _commandType )
                && ( _files?.Any( ) == true ) )
            {
                var _repository = new Dictionary<string, string>( );
                foreach( var _file in _files )
                {
                    string _output;
                    using( var _stream = File.OpenText( _file ) )
                    {
                        _output = _stream.ReadToEnd( );
                    }

                    if( !string.IsNullOrEmpty( _output ) )
                    {
                        var _name = Path.GetFileNameWithoutExtension( _file );
                        _repository.Add( _name, _output );
                    }
                }

                return _repository?.Any( ) == true
                    ? _repository
                    : default( IDictionary<string, string> );
            }

            return default( IDictionary<string, string> );
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private void Fail( Exception ex )
        {
            var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}