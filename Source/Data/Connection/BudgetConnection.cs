// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="BudgetConnection.cs" company="Terry D. Eppler">
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
//   BudgetConnection.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using System.Data.SqlServerCe;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Threading.Tasks;
    using static System.Configuration.ConfigurationManager;

    /// <inheritdoc/>
    /// <summary> </summary>
    /// <seealso cref="T:Badger.ConnectionBase"/>
    /// <seealso cref="T:Badger.ISource"/>
    /// <seealso cref="T:Badger.IProvider"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertSwitchStatementToSwitchExpression" ) ]
    public class BudgetConnection : ConnectionBase, IBudgetConnection
    {
        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.BudgetConnection"/>
        /// class.
        /// </summary>
        public BudgetConnection( )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetConnection"/>
        /// class.
        /// </summary>
        /// <param name="fullPath"> The fullPath. </param>
        public BudgetConnection( string fullPath )
            : this( )
        {
            _source = Source.External;
            _filePath = fullPath;
            _fileName = Path.GetFileNameWithoutExtension( fullPath );
            _tableName = _fileName;
            _pathExtension = Path.GetExtension( fullPath )?.Replace( ".", "" );
            if( !string.IsNullOrEmpty( _pathExtension ) )
            {
                _extension = ( EXT )Enum.Parse( typeof( EXT ), _pathExtension.ToUpper( ) );
                _provider = ( Provider )Enum.Parse( typeof( Provider ), _pathExtension.ToUpper( ) );
                _dataPath = AppSettings[ _extension.ToString( ) ];
                _connectionString = CreateConnectionString( _provider );
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetConnection"/>
        /// class.
        /// </summary>
        /// <param name="fullPath"> The fullPath. </param>
        /// <param name="provider"> The provider. </param>
        public BudgetConnection( string fullPath, Provider provider = Provider.Access )
            : this( )
        {
            _source = Source.External;
            _provider = provider;
            _filePath = fullPath;
            _fileName = Path.GetFileNameWithoutExtension( fullPath );
            _tableName = _fileName;
            _pathExtension = Path.GetExtension( fullPath )?.Replace( ".", "" );
            if( !string.IsNullOrEmpty( _pathExtension ) )
            {
                _extension = ( EXT )Enum.Parse( typeof( EXT ), _pathExtension.ToUpper( ) );
                _dataPath = AppSettings[ _extension.ToString( ) ];
                _connectionString = CreateConnectionString( _provider );
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetConnection"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        public BudgetConnection( Source source, Provider provider = Provider.Access )
            : this( )
        {
            _source = source;
            _provider = provider;
            _tableName = source.ToString( );
            _filePath = GetClientPath( provider );
            _connectionString = CreateConnectionString( provider );
            _pathExtension = Path.GetExtension( _filePath )?.Replace( ".", "" );
            _fileName = Path.GetFileNameWithoutExtension( _filePath );
            if( !string.IsNullOrEmpty( _pathExtension ) )
            {
                _extension = ( EXT )Enum.Parse( typeof( EXT ), _pathExtension.ToUpper( ) );
                _dataPath = AppSettings[ _extension.ToString( ) ];
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        public DbConnection Create( )
        {
            try
            {
                _connectionString = ConnectionStrings[ $"{_provider}" ]?.ConnectionString;
                if( !string.IsNullOrEmpty( _connectionString ) )
                {
                    switch( _provider )
                    {
                        case Provider.SQLite:
                        {
                            return new SQLiteConnection( _connectionString );
                        }
                        case Provider.SqlCe:
                        {
                            return new SqlCeConnection( _connectionString );
                        }
                        case Provider.SqlServer:
                        {
                            return new SqlConnection( _connectionString );
                        }
                        case Provider.Excel:
                        case Provider.CSV:
                        case Provider.Text:
                        case Provider.Access:
                        case Provider.OleDb:
                        {
                            return new OleDbConnection( _connectionString );
                        }
                        default:
                        {
                            return new OleDbConnection( _connectionString );
                        }
                    }
                }

                return default( DbConnection );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbConnection );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        public Task<DbConnection> CreateAsync( )
        {
            var _async = new TaskCompletionSource<DbConnection>( );
            try
            {
                _connectionString = ConnectionStrings[ $"{_provider}" ]?.ConnectionString;
                if( !string.IsNullOrEmpty( _connectionString ) )
                {
                    switch( _provider )
                    {
                        case Provider.SQLite:
                        {
                            var _sqliteConnection = new SQLiteConnection( _connectionString );
                            _async.SetResult( _sqliteConnection );
                            return _async.Task;
                        }
                        case Provider.SqlCe:
                        {
                            var _sqlCeConnection = new SqlCeConnection( _connectionString );
                            _async.SetResult( _sqlCeConnection );
                            return _async.Task;
                        }
                        case Provider.SqlServer:
                        {
                            var _sqlConnection = new SqlConnection( _connectionString );
                            _async.SetResult( _sqlConnection );
                            return _async.Task;
                        }
                        case Provider.Excel:
                        case Provider.CSV:
                        case Provider.Text:
                        case Provider.Access:
                        case Provider.OleDb:
                        {
                            var _oleDbConnection = new OleDbConnection( _connectionString );
                            _async.SetResult( _oleDbConnection );
                            return _async.Task;
                        }
                        default:
                        {
                            var _oledbConnection = new OleDbConnection( _connectionString );
                            _async.SetResult( _oledbConnection );
                            return _async.Task;
                        }
                    }
                }

                return default( Task<DbConnection> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Task<DbConnection> );
            }
        }
    }
}