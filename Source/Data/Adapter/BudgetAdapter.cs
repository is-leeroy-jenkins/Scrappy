// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="BudgetAdapter.cs" company="Terry D. Eppler">
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
//   BudgetAdapter.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    /// <inheritdoc/>
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.AdapterBase"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertSwitchStatementToSwitchExpression" ) ]
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    public class BudgetAdapter : AdapterBase, IBudgetAdapter
    {
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

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the data connection.
        /// </summary>
        /// <value>
        /// The data connection.
        /// </value>
        public DbConnection DataConnection
        {
            get
            {
                return _dataConnection;
            }
            private protected set
            {
                _dataConnection = value;
            }
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the commands.
        /// </summary>
        /// <value>
        /// The commands.
        /// </value>
        public IDictionary<string, DbCommand> Commands
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

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the command factory.
        /// </summary>
        /// <value> The command factory.
        /// </value>
        public IBudgetCommand BudgetCommand
        {
            get
            {
                return _budgetCommand;
            }
            private protected set
            {
                _budgetCommand = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the command text.
        /// </summary>
        /// <value>
        /// The command text.
        /// </value>
        public string CommandText
        {
            get
            {
                return _commandText;
            }
            private protected set
            {
                _commandText = value;
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.BudgetAdapter"/>
        /// class.
        /// </summary>
        public BudgetAdapter( )
            : base( )
        {
            MissingSchemaAction = MissingSchemaAction.AddWithKey;
            MissingMappingAction = MissingMappingAction.Passthrough;
            ContinueUpdateOnError = true;
            AcceptChangesDuringFill = true;
            AcceptChangesDuringUpdate = true;
            ReturnProviderSpecificTypes = true;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.BudgetAdapter" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="commandType">Type of the command.</param>
        public BudgetAdapter( Source source, Provider provider,
            Command commandType = Command.SELECTALL )
            : this( )
        {
            _source = source;
            _provider = provider;
            _sqlStatement = new SqlStatement( source, provider, commandType );
            _dataConnection = new BudgetConnection( source, provider )?.Create( );
            _commandText = _sqlStatement.CommandText;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.BudgetAdapter" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="sqlText">The SQL text.</param>
        /// <param name="commandType">Type of the command.</param>
        public BudgetAdapter( Source source, Provider provider, string sqlText,
            Command commandType )
            : this( )
        {
            _source = source;
            _provider = provider;
            _sqlStatement = new SqlStatement( source, provider, commandType );
            _dataConnection = new BudgetConnection( source, provider )?.Create( );
            _commandText = _sqlStatement.CommandText;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Scrappy.BudgetAdapter" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="where">The where.</param>
        /// <param name="commandType">Type of the command.</param>
        public BudgetAdapter( Source source, Provider provider, IDictionary<string, object> where,
            Command commandType = Command.SELECTALL )
            : this( )
        {
            _source = source;
            _provider = provider;
            _sqlStatement = new SqlStatement( source, provider, where, commandType );
            _dataConnection = new BudgetConnection( source, provider )?.Create( );
            _commandText = _sqlStatement.CommandText;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Scrappy.BudgetAdapter" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="update">The update.</param>
        /// <param name="where">The where.</param>
        /// <param name="commandType">Type of the command.</param>
        public BudgetAdapter( Source source, Provider provider, IDictionary<string, object> update,
            IDictionary<string, object> where, Command commandType = Command.UPDATE )
            : this( )
        {
            _source = source;
            _provider = provider;
            _sqlStatement = new SqlStatement( source, provider, update, where,
                commandType );

            _dataConnection = new BudgetConnection( source, provider )?.Create( );
            _commandText = _sqlStatement.CommandText;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.BudgetAdapter" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="where">The where.</param>
        /// <param name="commandType">Type of the command.</param>
        public BudgetAdapter( Source source, Provider provider, IEnumerable<string> columns,
            IDictionary<string, object> where, Command commandType = Command.SELECT )
            : this( )
        {
            _source = source;
            _provider = provider;
            _sqlStatement = new SqlStatement( source, provider, columns, where,
                commandType );

            _dataConnection = new BudgetConnection( source, provider )?.Create( );
            _commandText = _sqlStatement.CommandText;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.BudgetAdapter" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="numerics">The numerics.</param>
        /// <param name="having">The having.</param>
        /// <param name="commandType">Type of the command.</param>
        public BudgetAdapter( Source source, Provider provider, IEnumerable<string> fields,
            IEnumerable<string> numerics, IDictionary<string, object> having,
            Command commandType = Command.SELECT )
            : this( )
        {
            _source = source;
            _provider = provider;
            _sqlStatement = new SqlStatement( source, provider, fields, numerics,
                having, commandType );

            _dataConnection = new BudgetConnection( source, provider )?.Create( );
            _commandText = _sqlStatement.CommandText;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.BudgetAdapter"/>
        /// class.
        /// </summary>
        /// <param name="sqlStatement"> The SQL statement. </param>
        public BudgetAdapter( ISqlStatement sqlStatement )
            : this( )
        {
            _source = sqlStatement.Source;
            _provider = sqlStatement.Provider;
            _sqlStatement = sqlStatement;
            _commandText = sqlStatement.CommandText;
            _dataConnection = new BudgetConnection( sqlStatement.Source, sqlStatement.Provider )
                ?.Create( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.BudgetAdapter" /> class.
        /// </summary>
        /// <param name="command">The command.</param>
        public BudgetAdapter( IBudgetCommand command )
            : this( )
        {
            _source = command.Source;
            _provider = command.Provider;
            _sqlStatement = command.SqlStatement;
            _dataConnection = command.Connection;
            _commandText = command.SqlStatement.CommandText;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the adapter.
        /// </summary>
        /// <returns> DbDataAdapter </returns>
        public DbDataAdapter Create( )
        {
            try
            {
                switch( _provider )
                {
                    case Provider.SQLite:
                    {
                        return CreateSQLiteAdapter( );
                    }
                    case Provider.SqlCe:
                    {
                        return CreateSqlCompactAdapter( );
                    }
                    case Provider.SqlServer:
                    {
                        return CreateSqlDataAdapter( );
                    }
                    case Provider.Excel:
                    case Provider.CSV:
                    case Provider.Access:
                    case Provider.OleDb:
                    {
                        return CreateOleDbAdapter( );
                    }
                    default:
                    {
                        return CreateOleDbAdapter( );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbDataAdapter );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <returns>
        /// Task(DbDataAdapter)
        /// </returns>
        public Task<DbDataAdapter> CreateAsync( )
        {
            if( !string.IsNullOrEmpty( _commandText ) )
            {
                var _async = new TaskCompletionSource<DbDataAdapter>( );
                try
                {
                    switch( _provider )
                    {
                        case Provider.SQLite:
                        {
                            var _adapter = CreateSQLiteAdapter( );
                            _async.SetResult( _adapter );
                            return _async.Task;
                        }
                        case Provider.SqlCe:
                        {
                            var _adapter = CreateSqlCompactAdapter( );
                            _async.SetResult( _adapter );
                            return _async.Task;
                        }
                        case Provider.SqlServer:
                        {
                            var _adapter = CreateSqlDataAdapter( );
                            _async.SetResult( _adapter );
                            return _async.Task;
                        }
                        case Provider.Excel:
                        case Provider.CSV:
                        case Provider.Access:
                        case Provider.OleDb:
                        {
                            var _adapter = CreateOleDbAdapter( );
                            _async.SetResult( _adapter );
                            return _async.Task;
                        }
                        default:
                        {
                            var _adapter = CreateOleDbAdapter( );
                            _async.SetResult( _adapter );
                            return _async.Task;
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( Task<DbDataAdapter> );
                }
            }

            return default( Task<DbDataAdapter> );
        }
    }
}