// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="BudgetCommand.cs" company="Terry D. Eppler">
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
//   BudgetCommand.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    /// <inheritdoc/>
    /// <summary> </summary>
    /// <seealso cref="T:Badger.ICommand"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertSwitchStatementToSwitchExpression" ) ]
    public class BudgetCommand : CommandBase, IBudgetCommand
    {
        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.BudgetCommand"/>
        /// class.
        /// </summary>
        public BudgetCommand( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetCommand"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="commandType">Type of the command.</param>
        public BudgetCommand( Source source, Provider provider,
            Command commandType = Scrappy.Command.SELECTALL )
        {
            _source = _sqlStatement.Source;
            _provider = provider;
            _commandType = commandType;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, commandType );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetCommand"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="sqlText"> The SQL text. </param>
        /// <param name="commandType"> Type of the command. </param>
        public BudgetCommand( Source source, Provider provider, string sqlText,
            Command commandType )
        {
            _source = source;
            _provider = provider;
            _commandType = commandType;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, sqlText, commandType );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetCommand"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="where"> The dictionary. </param>
        /// <param name="commandType"> </param>
        public BudgetCommand( Source source, Provider provider, IDictionary<string, object> where,
            Command commandType = Scrappy.Command.SELECTALL )
        {
            _source = source;
            _provider = provider;
            _commandType = commandType;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, where, commandType );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetCommand"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="update"> The updates. </param>
        /// <param name="where"> The criteria. </param>
        /// <param name="commandType"> </param>
        public BudgetCommand( Source source, Provider provider, IDictionary<string, object> update,
            IDictionary<string, object> where, Command commandType = Scrappy.Command.UPDATE )
        {
            _source = source;
            _provider = provider;
            _commandType = commandType;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, update, where,
                commandType );
        }

        /// <inheritdoc/>
        /// <summary> </summary>
        /// <param name="source"> </param>
        /// <param name="provider"> </param>
        /// <param name="columns"> </param>
        /// <param name="where"> </param>
        /// <param name="commandType"> </param>
        public BudgetCommand( Source source, Provider provider, IEnumerable<string> columns,
            IDictionary<string, object> where, Command commandType = Scrappy.Command.SELECT )
        {
            _source = source;
            _provider = provider;
            _commandType = commandType;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, columns, where,
                commandType );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetCommand"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="fields"> The fields. </param>
        /// <param name="numerics"> The numerics. </param>
        /// <param name="having"> The having. </param>
        /// <param name="commandType"> Type of the command. </param>
        public BudgetCommand( Source source, Provider provider, IEnumerable<string> fields,
            IEnumerable<string> numerics, IDictionary<string, object> having,
            Command commandType = Scrappy.Command.SELECT )
        {
            _source = source;
            _provider = provider;
            _commandType = commandType;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, fields, numerics,
                having, commandType );
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetCommand"/>
        /// class.
        /// </summary>
        /// <param name="sqlStatement"> The SQL statement. </param>
        public BudgetCommand( ISqlStatement sqlStatement )
        {
            _sqlStatement = sqlStatement;
            _source = sqlStatement.Source;
            _provider = sqlStatement.Provider;
            _commandType = sqlStatement.CommandType;
            _connection =
                new BudgetConnection( sqlStatement.Source, sqlStatement.Provider ).Create( );
        }

        /// <inheritdoc/>
        /// <summary> Sets the command. </summary>
        /// <returns> </returns>
        public DbCommand Create( )
        {
            try
            {
                switch( _sqlStatement.Provider )
                {
                    case Provider.SQLite:
                    {
                        return GetSQLiteCommand( );
                    }
                    case Provider.SqlCe:
                    {
                        return GetSqlCeCommand( );
                    }
                    case Provider.SqlServer:
                    {
                        return GetSqlCommand( );
                    }
                    case Provider.Excel:
                    case Provider.CSV:
                    case Provider.Access:
                    case Provider.Text:
                    case Provider.OleDb:
                    {
                        return GetOleDbCommand( );
                    }
                    default:
                    {
                        return default( DbCommand );
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DbCommand );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Creates the command asynchronously.
        /// </summary>
        /// <returns>
        /// Task( DbCommand )
        /// </returns>
        public Task<DbCommand> CreateAsync( )
        {
            var _async = new TaskCompletionSource<DbCommand>( );
            try
            {
                switch( _provider )
                {
                    case Provider.SQLite:
                    {
                        var _sqliteCommand = GetSQLiteCommand( );
                        _async.SetResult( _sqliteCommand );
                        return _async.Task;
                    }
                    case Provider.SqlCe:
                    {
                        var _sqlceCommand = GetSqlCeCommand( );
                        _async.SetResult( _sqlceCommand );
                        return _async.Task;
                    }
                    case Provider.SqlServer:
                    {
                        var _sqlCommand = GetSqlCommand( );
                        _async.SetResult( _sqlCommand );
                        return _async.Task;
                    }
                    case Provider.Excel:
                    case Provider.CSV:
                    case Provider.Access:
                    case Provider.Text:
                    case Provider.OleDb:
                    {
                        var _oledbCommand = GetOleDbCommand( );
                        _async.SetResult( _oledbCommand );
                        return _async.Task;
                    }
                    default:
                    {
                        var _oledbCommand = GetOleDbCommand( );
                        _async.SetResult( _oledbCommand );
                        return _async.Task;
                    }
                }
            }
            catch( Exception ex )
            {
                _async.SetException( ex );
                Fail( ex );
                return default( Task<DbCommand> );
            }
        }
    }
}