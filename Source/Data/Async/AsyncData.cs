// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="AsyncData.cs" company="Terry D. Eppler">
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
//   AsyncData.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.AsyncState" />
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "LocalVariableHidesMember" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public abstract class AsyncData : AsyncSchema
    {
        /// <inheritdoc />
        /// <summary>
        /// Gets the query asynchronous.
        /// </summary>
        /// <param name="sqlStatement">The SQL statement.</param>
        /// <returns>
        /// Task(Query)
        /// </returns>
        private protected Task<IQuery> GetQueryAsync( SqlStatement sqlStatement )
        {
            var _async = new TaskCompletionSource<IQuery>( );
            try
            {
                ThrowIf.Null( sqlStatement, nameof( sqlStatement ) );
                var _query = new BudgetQuery( sqlStatement );
                _async.SetResult( _query );
                return _query != null
                    ? _async.Task
                    : default( Task<IQuery> );
            }
            catch( Exception ex )
            {
                _async.SetException( ex );
                Fail( ex );
                return default( Task<IQuery> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the ordinals asynchronous.
        /// </summary>
        /// <returns>
        /// Task(List)
        /// </returns>
        public Task<IList<int>> GetOrdinalsAsync( )
        {
            var _async = new TaskCompletionSource<IList<int>>( );
            try
            {
                var _table = GetDataTable( );
                var _ordinals = new List<int>( );
                if( _table != null )
                {
                    foreach( DataColumn _column in _table?.Columns )
                    {
                        _ordinals?.Add( _column.Ordinal );
                    }
                }

                _async.SetResult( _ordinals );
                return _ordinals?.Any( ) == true
                    ? _async.Task
                    : default( Task<IList<int>> );
            }
            catch( Exception ex )
            {
                _async.SetException( ex );
                Fail( ex );
                return default( Task<IList<int>> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the map asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task<IDictionary<string, object>> GetMapAsync( )
        {
            var _async = new TaskCompletionSource<IDictionary<string, object>>( );
            try
            {
                var _table = GetDataTable( );
                var _rows = _table?.AsEnumerable( );
                var _record = _rows?.FirstOrDefault( );
                var _map = _record.ToDictionary( );
                _async.SetResult( _map );
                return _map?.Any( ) == true
                    ? _async.Task
                    : default( Task<IDictionary<string, object>> );
            }
            catch( Exception ex )
            {
                _async.SetException( ex );
                Fail( ex );
                return default( Task<IDictionary<string, object>> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the schema asynchronous.
        /// </summary>
        /// <returns>
        /// Task(IDictionary(string, Type))
        /// </returns>
        public Task<IDictionary<string, Type>> GetSchemaAsync( )
        {
            var _async = new TaskCompletionSource<IDictionary<string, Type>>( );
            try
            {
                var _table = GetDataTable( );
                if( _table != null )
                {
                    var _schema = new Dictionary<string, Type>( );
                    foreach( DataColumn _col in _table.Columns )
                    {
                        _schema.Add( _col.ColumnName, _col.DataType );
                    }

                    _async.SetResult( _schema );
                    return _schema?.Any( ) == true
                        ? _async.Task
                        : default( Task<IDictionary<string, Type>> );
                }
                else
                {
                    _async.SetResult( default( IDictionary<string, Type> ) );
                    return _async.Task ?? default( Task<IDictionary<string, Type>> );
                }
            }
            catch( Exception ex )
            {
                _async.SetException( ex );
                Fail( ex );
                return default( Task<IDictionary<string, Type>> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the columns asynchronous.
        /// </summary>
        /// <returns>
        /// </returns>
        public Task<IList<DataColumn>> GetColumnsAsync( )
        {
            var _async = new TaskCompletionSource<IList<DataColumn>>( );
            try
            {
                var _table = GetDataTable( );
                if( _table != null )
                {
                    var _columns = new List<DataColumn>( );
                    foreach( DataColumn _column in _table.Columns )
                    {
                        if( _column != null )
                        {
                            _columns.Add( _column );
                        }
                    }

                    _async.SetResult( _columns );
                    return _columns?.Any( ) == true
                        ? _async.Task
                        : default( Task<IList<DataColumn>> );
                }
                else
                {
                    _async.SetResult( default( IList<DataColumn> ) );
                    return default( Task<IList<DataColumn>> );
                }
            }
            catch( Exception ex )
            {
                _async.SetException( ex );
                Fail( ex );
                return default( Task<IList<DataColumn>> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the names asynchronous.
        /// </summary>
        /// <returns>
        /// Task( List( string ) )
        /// </returns>
        public Task<IList<string>> GetNamesAsync( )
        {
            var _async = new TaskCompletionSource<IList<string>>( );
            try
            {
                var _table = GetDataTable( );
                if( _table != null )
                {
                    var _names = new List<string>( );
                    foreach( DataColumn _column in _table.Columns )
                    {
                        if( !string.IsNullOrEmpty( _column?.ColumnName ) )
                        {
                            _names.Add( _column.ColumnName );
                        }
                    }

                    _async.SetResult( _names );
                    return _names?.Any( ) == true
                        ? _async.Task
                        : default( Task<IList<string>> );
                }
                else
                {
                    _async.SetResult( default( IList<string> ) );
                    return default( Task<IList<string>> );
                }
            }
            catch( Exception ex )
            {
                _async.SetException( ex );
                Fail( ex );
                return default( Task<IList<string>> );
            }
        }
    }
}