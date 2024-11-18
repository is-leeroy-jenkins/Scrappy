// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-28-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-28-2024
// ******************************************************************************************
// <copyright file="BudgetQuery.cs" company="Terry D. Eppler">
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
//   BudgetQuery.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc/>
    /// <summary> </summary>
    /// <seealso cref="T:System.IDisposable"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ValueParameterNotUsed" ) ]
    public class BudgetQuery : Query
    {
        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Query"/>
        /// class.
        /// </summary>
        public BudgetQuery( )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="commandType"> The commandType. </param>
        public BudgetQuery( Source source, Provider provider = Provider.Access,
            Command commandType = Command.SELECTALL )
        {
            _source = source;
            _provider = provider;
            _dataConnection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, commandType );
            _dataAdapter = new BudgetAdapter( _sqlStatement ).Create( );
            _isDisposed = false;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source Data. </param>
        /// <param name="provider"> The provider used. </param>
        /// <param name="where"> The dictionary of parameters. </param>
        /// <param name="commandType"> The type of sql command. </param>
        public BudgetQuery( Source source, Provider provider, IDictionary<string, object> where,
            Command commandType = Command.SELECTALL )
        {
            _source = source;
            _provider = provider;
            _criteria = where;
            _dataConnection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, where, commandType );
            _dataAdapter = new BudgetAdapter( _sqlStatement ).Create( );
            _isDisposed = false;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="updates"> </param>
        /// <param name="where"> The where. </param>
        /// <param name="commandType"> Type of the command. </param>
        public BudgetQuery( Source source, Provider provider, IDictionary<string, object> updates,
            IDictionary<string, object> where, Command commandType = Command.UPDATE )
        {
            _source = source;
            _provider = provider;
            _criteria = where;
            _dataConnection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, updates, where,
                commandType );

            _dataAdapter = new BudgetAdapter( _sqlStatement ).Create( );
            _isDisposed = false;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="columns"> The columns. </param>
        /// <param name="where"> The criteria. </param>
        /// <param name="commandType"> Type of the command. </param>
        public BudgetQuery( Source source, Provider provider, IEnumerable<string> columns,
            IDictionary<string, object> where, Command commandType = Command.SELECT )
        {
            _source = source;
            _provider = provider;
            _criteria = where;
            _commandType = commandType;
            _dataConnection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, columns, where, commandType );
            _dataAdapter = new BudgetAdapter( _sqlStatement ).Create( );
            _isDisposed = false;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="columns"> The columns. </param>
        /// <param name="numerics"> The numeric field. </param>
        /// <param name="having"> The having. </param>
        /// <param name="commandType"> Type of the command. </param>
        public BudgetQuery( Source source, Provider provider, IEnumerable<string> columns,
            IEnumerable<string> numerics, IDictionary<string, object> having,
            Command commandType = Command.SELECT )
        {
            _source = source;
            _provider = provider;
            _criteria = having;
            _dataConnection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, columns, numerics,
                having, commandType );

            _dataAdapter = new BudgetAdapter( _sqlStatement ).Create( );
            _isDisposed = false;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetQuery"/>
        /// class.
        /// </summary>
        /// <param name="sqlStatement"> The sqlStatement. </param>
        public BudgetQuery( ISqlStatement sqlStatement )
        {
            _sqlStatement = sqlStatement;
            _source = sqlStatement.Source;
            _provider = sqlStatement.Provider;
            _criteria = sqlStatement.Criteria;
            _dataConnection = new BudgetConnection( _source, _provider ).Create( );
            _dataAdapter = new BudgetAdapter( sqlStatement ).Create( );
            _isDisposed = false;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="sqlText"> The SQL text. </param>
        public BudgetQuery( Source source, Provider provider, string sqlText )
        {
            _source = source;
            _provider = provider;
            _dataConnection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, sqlText );
            _dataAdapter = new BudgetAdapter( _sqlStatement ).Create( );
            _criteria = null;
            _isDisposed = false;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetQuery"/>
        /// class.
        /// </summary>
        /// <param name="fullPath"> The fullpath. </param>
        /// <param name="sqlText"> </param>
        /// <param name="commandType"> The commandType. </param>
        public BudgetQuery( string fullPath, string sqlText, Command commandType = Command.SELECT )
        {
            _criteria = null;
            _provider = Provider.Access;
            _source = Source.External;
            _dataConnection = new BudgetConnection( fullPath ).Create( );
            _sqlStatement = new SqlStatement( _source, _provider, sqlText );
            _dataAdapter = new BudgetAdapter( _sqlStatement ).Create( );
            _isDisposed = false;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BudgetQuery"/>
        /// class.
        /// </summary>
        /// <param name="fullPath"> The fullpath. </param>
        /// <param name="commandType"> The commandType. </param>
        /// <param name="where"> The dictionary. </param>
        public BudgetQuery( string fullPath, Command commandType,
            IDictionary<string, object> where )
        {
            _criteria = where;
            _commandType = commandType;
            _provider = Provider.Access;
            _source = Source.External;
            _dataConnection = new BudgetConnection( fullPath ).Create( );
            _sqlStatement = new SqlStatement( _source, _provider, where, commandType );
            _dataAdapter = new BudgetAdapter( _sqlStatement ).Create( );
            _isDisposed = false;
        }
    }
}