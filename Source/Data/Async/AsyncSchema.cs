// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="AsyncSchema.cs" company="Terry D. Eppler">
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
//   AsyncSchema.cs
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
    using Exception = System.Exception;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.ISource" />
    /// <seealso cref="T:Badger.IProvider" />
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class AsyncSchema : AsyncCore
    {
        /// <summary>
        /// The query
        /// </summary>
        private protected IQuery _query;

        /// <summary>
        /// The record
        /// </summary>
        private protected Task<DataRow> _record;

        /// <summary>
        /// The keys
        /// </summary>
        private protected Task<IList<int>> _keys;

        /// <summary>
        /// The map
        /// </summary>
        private protected Task<IDictionary<string, object>> _map;

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>
        /// The query.
        /// </value>
        public IQuery Query
        {
            get
            {
                return _query;
            }
            private protected set
            {
                _query = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public Task<DataRow> Record
        {
            get
            {
                return _record;
            }
            private protected set
            {
                _record = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the keys.
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        public Task<IList<int>> Keys
        {
            get
            {
                return _keys;
            }
            private protected set
            {
                _keys = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the map.
        /// </summary>
        /// <value>
        /// The map.
        /// </value>
        public Task<IDictionary<string, object>> Map
        {
            get
            {
                return _map;
            }
            private protected set
            {
                _map = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable( )
        {
            if( _query != null )
            {
                try
                {
                    var _set = new DataSet( $"{_source}" );
                    var _table = new DataTable( $"{_source}" );
                    _table.TableName = _source.ToString( );
                    _set.Tables.Add( _table );
                    var _adapter = _query.DataAdapter;
                    _adapter.Fill( _set, _table.TableName );
                    SetColumnCaptions( _table );
                    return _table?.Rows?.Count > 0
                        ? _table
                        : default( DataTable );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the data table asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task<DataTable> GetDataTableAsync( )
        {
            if( _query != null )
            {
                var _async = new TaskCompletionSource<DataTable>( );
                try
                {
                    var _set = new DataSet( $"{_source}" );
                    var _table = new DataTable( $"{_source}" );
                    _table.TableName = _source.ToString( );
                    _set.Tables.Add( _table );
                    var _adapter = _query.DataAdapter;
                    _adapter.Fill( _set, _table.TableName );
                    SetColumnCaptions( _table );
                    _async.SetResult( _table );
                    return _table.Rows.Count > 0
                        ? _async.Task
                        : default( Task<DataTable> );
                }
                catch( Exception ex )
                {
                    _async.SetException( ex );
                    Fail( ex );
                    return default( Task<DataTable> );
                }
            }

            return default( Task<DataTable> );
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the record asynchronous.
        /// </summary>
        /// <returns></returns>
        public DataRow GetRecord( )
        {
            try
            {
                var _table = GetDataTable( );
                var _data = _table.AsEnumerable( );
                var _row = _data.FirstOrDefault( );
                return _row?.ItemArray?.Length > 0
                    ? _row
                    : default( DataRow );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataRow );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the record asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task<DataRow> GetRecordAsync( )
        {
            var _async = new TaskCompletionSource<DataRow>( );
            try
            {
                var _table = GetDataTable( );
                var _data = _table.AsEnumerable( );
                var _row = _data.FirstOrDefault( );
                _async.SetResult( _row );
                return _row?.ItemArray?.Length > 0
                    ? _async.Task
                    : default( Task<DataRow> );
            }
            catch( Exception ex )
            {
                _async.SetException( ex );
                Fail( ex );
                return default( Task<DataRow> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the data set asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task<DataSet> GetDataSetAsync( )
        {
            if( _query != null )
            {
                var _task = new TaskCompletionSource<DataSet>( );
                try
                {
                    var _set = new DataSet( $"{_source}" );
                    var _table = new DataTable( $"{_source}" );
                    _table.TableName = _source.ToString( );
                    _set.Tables.Add( _table );
                    var _adapter = _query.DataAdapter;
                    _adapter.Fill( _set, _table.TableName );
                    SetColumnCaptions( _table );
                    _task.SetResult( _set );
                    return _set.Tables?.Count > 0
                        ? _task.Task
                        : default( Task<DataSet> );
                }
                catch( Exception ex )
                {
                    _task.SetException( ex );
                    Fail( ex );
                    return default( Task<DataSet> );
                }
            }

            return default( Task<DataSet> );
        }

        /// <inheritdoc />
        /// <summary>
        /// Sets the column captions.
        /// </summary>
        /// <param name="dataTable"> The data table.
        /// </param>
        public void SetColumnCaptions( DataTable dataTable )
        {
            try
            {
                ThrowIf.Null( dataTable, nameof( dataTable ) );
                foreach( DataColumn _column in dataTable.Columns )
                {
                    if( _column != null )
                    {
                        var _caption = _column.ColumnName.SplitPascal( );
                        _column.Caption = _caption;
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the fields asynchronous.
        /// </summary>
        /// <returns>
        /// Task of IList of string
        /// </returns>
        public Task<IList<string>> GetFieldsAsync( )
        {
            var _async = new TaskCompletionSource<IList<string>>( );
            try
            {
                var _list = new List<string>( );
                var _table = GetDataTable( );
                foreach( DataColumn _col in _table.Columns )
                {
                    if( _col.DataType == typeof( string ) )
                    {
                        _list.Add( _col.ColumnName );
                    }
                }

                _async.SetResult( _list );
                return _list?.Any( ) == true
                    ? _async.Task
                    : default( Task<IList<string>> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Task<IList<string>> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the numerics asynchronous.
        /// </summary>
        /// <returns>
        /// Task of IList of string
        /// </returns>
        public Task<IList<string>> GetNumericsAsync( )
        {
            var _async = new TaskCompletionSource<IList<string>>( );
            try
            {
                var _list = new List<string>( );
                var _table = GetDataTable( );
                foreach( DataColumn _col in _table.Columns )
                {
                    if( ( !_col.ColumnName.EndsWith( "Id" ) && _col.Ordinal > 0
                            && _col.DataType == typeof( double ) )
                        || _col.DataType == typeof( short )
                        || _col.DataType == typeof( long )
                        || _col.DataType == typeof( decimal )
                        || _col.DataType == typeof( float ) )
                    {
                        _list.Add( _col.ColumnName );
                    }
                }

                _async.SetResult( _list );
                return _list?.Any( ) == true
                    ? _async.Task
                    : default( Task<IList<string>> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Task<IList<string>> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the dates asynchronous.
        /// </summary>
        /// <returns>
        /// Task of IList of string
        /// </returns>
        public Task<IList<string>> GetDatesAsync( )
        {
            var _async = new TaskCompletionSource<IList<string>>( );
            try
            {
                var _list = new List<string>( );
                var _table = GetDataTable( );
                foreach( DataColumn _col in _table.Columns )
                {
                    if( _col.Ordinal > 0
                        && ( _col.DataType == typeof( DateTime )
                            || _col.DataType == typeof( DateTimeOffset )
                            || _col.ColumnName.EndsWith( nameof( Day ) )
                            || _col.ColumnName.EndsWith( "Date" ) ) )
                    {
                        _list.Add( _col.ColumnName );
                    }
                }

                _async.SetResult( _list );
                return _list?.Any( ) == true
                    ? _async.Task
                    : default( Task<IList<string>> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Task<IList<string>> );
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the primary keys asynchronous.
        /// </summary>
        /// <returns>
        /// Task of IList of int
        /// </returns>
        public Task<IList<int>> GetKeysAsnyc( )
        {
            var _async = new TaskCompletionSource<IList<int>>( );
            try
            {
                var _table = GetDataTable( );
                var _values = _table?.AsEnumerable( )?.Select( c => c.Field<int>( 0 ) )
                    ?.Distinct( );

                var _list = _values?.ToList( );
                _async.SetResult( _list );
                return _list?.Any( ) == true
                    ? _async.Task
                    : default( Task<IList<int>> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Task<IList<int>> );
            }
        }
    }
}