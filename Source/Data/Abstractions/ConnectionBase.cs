// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="ConnectionBase.cs" company="Terry D. Eppler">
//    Badger is budget execution and data analysis tool for EPA Analysts
//    based on WPF, NET6.0, and is written in C-Sharp.
// 
//     Copyright ©  2020, 2022, 2204 Terry D. Eppler
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
//   ConnectionBase.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using static System.Configuration.ConfigurationManager;
    using static System.IO.Path;

    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "PublicConstructorInAbstractClass" ) ]
    public abstract class ConnectionBase
    {
        /// <summary>
        /// The source
        /// </summary>
        /// <value>
        ///  
        /// </value>
        private protected Source _source;

        /// <summary>
        /// The provider
        /// </summary>
        /// <value>
        ///  
        /// </value>
        private protected Provider _provider;

        /// <summary>
        ///  
        /// </summary>
        /// <value>
        ///  
        /// </value>
        private protected DbConnection _connection;

        /// <summary>
        ///  
        /// </summary>
        /// <value>
        ///  
        /// </value>
        private protected string _dataPath;

        /// <summary>
        /// 
        /// </summary>
        /// <value>
        ///  
        /// </value>
        private protected EXT _extension;

        /// <summary>
        ///  
        /// </summary>
        /// <value>
        /// 
        /// </value>
        private protected ISqlStatement _sqlStatement;

        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// 
        /// </value>
        private protected string _pathExtension;

        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// 
        /// </value>
        private protected string _filePath;

        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// 
        /// </value>
        private protected string _fileName;

        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// 
        /// </value>
        private protected string _tableName;

        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// 
        /// </value>
        private protected string _connectionString;

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public DbConnection Connection
        {
            get
            {
                return _connection;
            }
            private protected set
            {
                _connection = value;
            }
        }

        /// <summary>
        /// Gets or sets the client path.
        /// </summary>
        /// <value>
        /// The client path.
        /// </value>
        public string DataPath
        {
            get
            {
                return _dataPath;
            }
            private protected set
            {
                _dataPath = value;
            }
        }

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
        /// Gets or sets the provider.
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
        public Provider Provider
        {
            get
            {
                return _provider;
            }
            private protected set
            {
                _provider = value;
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
        /// Gets or sets the path extension.
        /// </summary>
        /// <value>
        /// The path extension.
        /// </value>
        public string PathExtension
        {
            get
            {
                return _pathExtension;
            }
            private protected set
            {
                _pathExtension = value;
            }
        }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            private protected set
            {
                _filePath = value;
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
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public string TableName
        {
            get
            {
                return _tableName;
            }
            private protected set
            {
                _tableName = value;
            }
        }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            private protected set
            {
                _connectionString = value;
            }
        }

        /// <summary>
        /// Gets the database client path.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        private protected string GetClientPath( Provider provider )
        {
            if( Enum.IsDefined( typeof( Provider ), provider ) )
            {
                try
                {
                    return provider switch
                    {
                        Provider.Access => AppSettings[ "ACCDB" ],
                        Provider.SQLite => AppSettings[ "DB" ],
                        Provider.SqlCe => AppSettings[ "SDF" ],
                        Provider.Excel => AppSettings[ "XLSX" ],
                        Provider.SqlServer => AppSettings[ "MDF" ],
                        Provider.CSV => AppSettings[ "CSV" ],
                        Provider.Text => AppSettings[ "TXT" ],
                        _ => AppSettings[ "ACCDB" ]
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the database client path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        private protected string GetClientPath( string filePath )
        {
            try
            {
                ThrowIf.Null( filePath, nameof( filePath ) );
                var _file = GetExtension( filePath )?.Replace( ".", "" )?.ToUpper( );
                if( !string.IsNullOrEmpty( _file ) )
                {
                    _extension = ( EXT )Enum.Parse( typeof( EXT ), _file );
                    var _names = Enum.GetNames( typeof( EXT ) );
                    if( _names?.Contains( _extension.ToString( ) ) == true )
                    {
                        _dataPath = AppSettings[ $"{_extension}" ];
                        return !string.IsNullOrEmpty( _dataPath )
                            ? _dataPath
                            : string.Empty;
                    }
                }

                return string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Creates the connection string.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        private protected virtual string CreateConnectionString( Provider provider )
        {
            if( Enum.IsDefined( typeof( Provider ), provider ) )
            {
                try
                {
                    _connectionString = ConnectionStrings[ provider.ToString( ) ]?.ConnectionString;
                    return !string.IsNullOrEmpty( _connectionString )
                        ? _connectionString?.Replace( $"{_filePath}", _filePath )
                        : string.Empty;
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
        /// Creates the connection string.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        private protected virtual string CreateConnectionString( string filePath )
        {
            try
            {
                ThrowIf.Null( filePath, nameof( filePath ) );
                var _file = GetExtension( filePath );
                if( !string.IsNullOrEmpty( _file ) )
                {
                    var _ext = ( EXT )Enum.Parse( typeof( EXT ), _file.ToUpper( ) );
                    var _names = Enum.GetNames( typeof( EXT ) );
                    if( _names?.Contains( _ext.ToString( ) ) == true )
                    {
                        _connectionString = ConnectionStrings[ $"{_ext}" ]?.ConnectionString;
                        return !string.IsNullOrEmpty( _connectionString )
                            ? _connectionString
                            : string.Empty;
                    }

                    return string.Empty;
                }

                return string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected void Fail( Exception ex )
        {
            var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}