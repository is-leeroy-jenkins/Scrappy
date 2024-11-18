// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-28-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-28-2024
// ******************************************************************************************
// <copyright file="DataSchema.cs" company="Terry D. Eppler">
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
//   DataSchema.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Threading.Tasks;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.ISource" />
    /// <seealso cref="T:Badger.IProvider" />
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertIfStatementToNullCoalescingAssignment" ) ]
    [ SuppressMessage( "ReSharper", "PossibleNullReferenceException" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public abstract class DataSchema : DataCore
    {
        /// <summary>
        /// The locked object
        /// </summary>
        private object _path;

        /// <summary>
        /// The busy
        /// </summary>
        private protected bool _busy;

        /// <summary>
        /// The map
        /// </summary>
        private protected IDictionary<string, object> _map;

        /// <summary>
        /// The duration
        /// </summary>
        private protected TimeSpan _duration;

        /// <summary>
        /// The elements
        /// </summary>
        private protected IDictionary<string, IEnumerable<string>> _elements;

        /// <summary>
        /// Gets or sets the SQL statement.
        /// </summary>
        /// <value>
        /// The SQL statement.
        /// </value>
        private protected ISqlStatement _sqlStatement;

        /// <summary>
        /// The keys
        /// </summary>
        private protected IList<int> _keys;

        /// <summary>
        /// Gets or sets the map.
        /// </summary>
        /// <value>
        /// The map.
        /// </value>
        public IDictionary<string, object> Map
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

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// IEnumerable{DataRow}
        /// </returns>
        public IEnumerable<DataRow> GetData( )
        {
            try
            {
                if( _dataTable == null )
                {
                    _dataTable = GetDataTable( );
                }

                var _data = _dataTable?.AsEnumerable( );
                return _data?.Any( ) == true
                    ? _data
                    : default( IEnumerable<DataRow> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<DataRow> );
            }
        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <returns>
        /// DataTable
        /// </returns>
        private protected DataTable GetDataTable( )
        {
            try
            {
                BeginInit( );
                var _clock = Stopwatch.StartNew( );
                _dataSet = new DataSet( $"{_source}" );
                _dataTable = new DataTable( $"{_source}" );
                _dataTable.TableName = _source.ToString( );
                _dataSet.Tables.Add( _dataTable );
                using var _query = new BudgetQuery( _sqlStatement );
                using var _adapter = _query.DataAdapter;
                _adapter.FillSchema( _dataSet, System.Data.SchemaType.Source,
                    _dataTable.TableName );

                _adapter.Fill( _dataSet, _dataTable.TableName );
                SetColumnCaptions( _dataTable );
                _duration = _clock.Elapsed;
                EndInit( );
                return _dataTable?.Rows?.Count > 0
                    ? _dataTable
                    : default( DataTable );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataTable );
            }
        }

        /// <summary>
        /// Gets the table asynchronous.
        /// </summary>
        /// <returns>
        /// </returns>
        private protected Task<DataTable> GetTableAsync( )
        {
            var _tcs = new TaskCompletionSource<DataTable>( );
            try
            {
                BeginInit( );
                var _clock = Stopwatch.StartNew( );
                _dataSet = new DataSet( $"{_provider}" );
                _dataTable = new DataTable( $"{_source}" );
                _dataTable.TableName = _source.ToString( );
                _dataSet.Tables.Add( _dataTable );
                using var _query = new BudgetQuery( _sqlStatement );
                using var _adapter = _query.DataAdapter;
                _adapter.Fill( _dataSet, _dataTable.TableName );
                SetColumnCaptions( _dataTable );
                _tcs.SetResult( _dataTable );
                _duration = _clock.Elapsed;
                EndInit( );
                return _tcs?.Task;
            }
            catch( Exception ex )
            {
                _tcs.SetException( ex );
                Fail( ex );
                return default( Task<DataTable> );
            }
        }

        /// <summary>
        /// Sets the column captions.
        /// </summary>
        /// <param name="dataTable">
        /// The data table.
        /// </param>
        private protected void SetColumnCaptions( DataTable dataTable )
        {
            try
            {
                ThrowIf.Null( dataTable, nameof( dataTable ) );
                foreach( DataColumn _column in dataTable?.Columns )
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

        /// <summary>
        /// Gets the fields.
        /// </summary>
        /// <returns></returns>
        private protected IList<string> GetFields( )
        {
            try
            {
                var _list = new List<string>( );
                if( _dataTable == null )
                {
                    _dataTable = GetDataTable( );
                }

                foreach( DataColumn _col in _dataTable.Columns )
                {
                    if( _col.DataType == typeof( string ) )
                    {
                        _list.Add( _col.ColumnName );
                    }
                }

                return _list?.Any( ) == true
                    ? _list
                    : default( IList<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Gets the numerics.
        /// </summary>
        /// <returns></returns>
        private protected IList<string> GetNumerics( )
        {
            try
            {
                var _list = new List<string>( );
                if( _dataTable == null )
                {
                    _dataTable = GetDataTable( );
                }

                foreach( DataColumn _col in _dataTable.Columns )
                {
                    if( ( !_col.ColumnName.EndsWith( "Id" )
                            && _col.DataType == typeof( double ) )
                        || _col.DataType == typeof( short )
                        || _col.DataType == typeof( ushort )
                        || _col.DataType == typeof( long )
                        || _col.DataType == typeof( decimal )
                        || _col.DataType == typeof( float ) )
                    {
                        _list.Add( _col.ColumnName );
                    }
                }

                return _list?.Any( ) == true
                    ? _list
                    : default( IList<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Gets the dates.
        /// </summary>
        /// <returns></returns>
        private protected IList<string> GetDates( )
        {
            try
            {
                var _list = new List<string>( );
                if( _dataTable == null )
                {
                    _dataTable = GetDataTable( );
                }

                foreach( DataColumn _col in _dataTable.Columns )
                {
                    if( _col.Ordinal > 0
                        && ( _col.DataType == typeof( DateTime )
                            || _col.DataType == typeof( DateTimeOffset )
                            || ( _col.ColumnName.EndsWith( "Day" )
                                && _col.DataType == typeof( string ) )
                            || ( _col.ColumnName.EndsWith( "Date" )
                                && _col.DataType == typeof( string ) ) ) )
                    {
                        _list.Add( _col.ColumnName );
                    }
                }

                return _list?.Any( ) == true
                    ? _list
                    : default( IList<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<string> );
            }
        }

        /// <summary>
        /// Gets the primary keys.
        /// </summary>
        /// <returns>
        /// </returns>
        private protected IList<int> GetPrimaryKeys( )
        {
            try
            {
                if( _dataTable == null )
                {
                    _dataTable = GetDataTable( );
                }

                var _values = _dataTable.GetIndexValues( );
                return _values?.Any( ) == true
                    ? _values.ToList( )
                    : default( IList<int> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IList<int> );
            }
        }

        /// <summary>
        /// Begins the initialize.
        /// </summary>
        private protected void BeginInit( )
        {
            try
            {
                if( _path == null )
                {
                    _path = new object( );
                    lock( _path )
                    {
                        _busy = true;
                    }
                }
                else
                {
                    lock( _path )
                    {
                        _busy = true;
                    }
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
        private protected void EndInit( )
        {
            try
            {
                if( _path == null )
                {
                    _path = new object( );
                    lock( _path )
                    {
                        _busy = false;
                    }
                }
                else
                {
                    lock( _path )
                    {
                        _busy = false;
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }
    }
}