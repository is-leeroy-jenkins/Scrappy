// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="CommandBase.cs" company="Terry D. Eppler">
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
//   CommandBase.cs
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

    /// <inheritdoc/>
    /// <summary> </summary>
    /// <seealso cref="T:Scrappy.ISource"/>
    /// <seealso cref="T:Scrappy.IProvider"/>
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public abstract class CommandBase
    {
        /// <summary>
        /// The source
        /// </summary>
        private protected Source _source;

        /// <summary>
        /// The provider
        /// </summary>
        private protected Provider _provider;

        /// <summary>
        /// The command type
        /// </summary>
        private protected Command _commandType;

        /// <summary>
        ///  
        /// </summary>
        /// <value>
        ///  
        /// </value>
        private protected DbCommand _command;

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
        private protected ISqlStatement _sqlStatement;

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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
        /// Gets or sets the command.
        /// </summary>
        /// <value>
        /// command.
        /// </value>
        public DbCommand Command
        {
            get
            {
                return _command;
            }
            private protected set
            {
                _command = value;
            }
        }

        /// <summary>
        /// Gets or sets the connection factory.
        /// </summary>
        /// <value>
        /// The connection factory.
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
        /// Gets or sets the SQL statement.
        /// </summary>
        /// <value>
        /// The SQL statement.
        /// </value>
        public ISqlStatement SqlStatement
        {
            get
            {
                return _sqlStatement;
            }
            private protected set
            {
                _sqlStatement = value;
            }
        }

        /// <summary>
        /// Gets the sqlite command.
        /// </summary>
        /// <returns> </returns>
        private protected DbCommand GetSQLiteCommand( )
        {
            if( _sqlStatement != null
                && _connection != null )
            {
                try
                {
                    switch( _sqlStatement?.CommandType )
                    {
                        case Scrappy.Command.SELECTALL:
                        case Scrappy.Command.SELECT:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return !string.IsNullOrEmpty( _sql )
                                ? new SQLiteCommand( _sql, _connection as SQLiteConnection )
                                : default( SQLiteCommand );
                        }
                        case Scrappy.Command.INSERT:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return new SQLiteCommand( _sql, _connection as SQLiteConnection );
                        }
                        case Scrappy.Command.UPDATE:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return new SQLiteCommand( _sql, _connection as SQLiteConnection );
                        }
                        case Scrappy.Command.DELETE:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return new SQLiteCommand( _sql, _connection as SQLiteConnection );
                        }
                        default:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return new SQLiteCommand( _sql, _connection as SQLiteConnection );
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DbCommand );
                }
            }

            return default( DbCommand );
        }

        /// <summary>
        /// Gets the SQL ce command.
        /// </summary>
        /// <returns>
        /// </returns>
        private protected DbCommand GetSqlCeCommand( )
        {
            if( _sqlStatement != null
                && _connection != null )
            {
                try
                {
                    switch( _sqlStatement?.CommandType )
                    {
                        case Scrappy.Command.SELECTALL:
                        case Scrappy.Command.SELECT:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return !string.IsNullOrEmpty( _sql )
                                ? new SqlCeCommand( _sql, _connection as SqlCeConnection )
                                : default( DbCommand );
                        }
                        case Scrappy.Command.INSERT:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return !string.IsNullOrEmpty( _sql )
                                ? new SqlCeCommand( _sql, _connection as SqlCeConnection )
                                : default( DbCommand );
                        }
                        case Scrappy.Command.UPDATE:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return !string.IsNullOrEmpty( _sql )
                                ? new SqlCeCommand( _sql, _connection as SqlCeConnection )
                                : default( DbCommand );
                        }
                        case Scrappy.Command.DELETE:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return !string.IsNullOrEmpty( _sql )
                                ? new SqlCeCommand( _sql, _connection as SqlCeConnection )
                                : default( DbCommand );
                        }
                        default:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return !string.IsNullOrEmpty( _sql )
                                ? new SqlCeCommand( _sql, _connection as SqlCeConnection )
                                : default( DbCommand );
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DbCommand );
                }
            }

            return default( DbCommand );
        }

        /// <summary>
        /// Gets the SQL command.
        /// </summary>
        /// <returns>
        /// </returns>
        private protected DbCommand GetSqlCommand( )
        {
            if( _sqlStatement != null
                && _connection != null )
            {
                try
                {
                    switch( _sqlStatement?.CommandType )
                    {
                        case Scrappy.Command.SELECTALL:
                        case Scrappy.Command.SELECT:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return new SqlCommand( _sql, _connection as SqlConnection );
                        }
                        case Scrappy.Command.INSERT:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return new SqlCommand( _sql, _connection as SqlConnection );
                        }
                        case Scrappy.Command.UPDATE:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return new SqlCommand( _sql, _connection as SqlConnection );
                        }
                        case Scrappy.Command.DELETE:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return new SqlCommand( _sql, _connection as SqlConnection );
                        }
                        default:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return new SqlCommand( _sql, _connection as SqlConnection );
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DbCommand );
                }
            }

            return default( DbCommand );
        }

        /// <summary> Gets the OLE database command. </summary>
        /// <returns> </returns>
        private protected DbCommand GetOleDbCommand( )
        {
            if( _sqlStatement != null
                && Enum.IsDefined( typeof( Command ), _sqlStatement.CommandType )
                && _connection != null )
            {
                try
                {
                    switch( _sqlStatement?.CommandType )
                    {
                        case Scrappy.Command.SELECTALL:
                        case Scrappy.Command.SELECT:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return new OleDbCommand( _sql, _connection as OleDbConnection );
                        }
                        case Scrappy.Command.INSERT:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return new OleDbCommand( _sql, _connection as OleDbConnection );
                        }
                        case Scrappy.Command.UPDATE:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return new OleDbCommand( _sql, _connection as OleDbConnection );
                        }
                        case Scrappy.Command.DELETE:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return new OleDbCommand( _sql, _connection as OleDbConnection );
                        }
                        default:
                        {
                            var _sql = _sqlStatement?.CommandText;
                            return new OleDbCommand( _sql, _connection as OleDbConnection );
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DbCommand );
                }
            }

            return default( DbCommand );
        }

        /// <summary> Fails the specified ex. </summary>
        /// <param name="ex"> The ex. </param>
        protected static void Fail( Exception ex )
        {
            var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}