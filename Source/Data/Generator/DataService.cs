// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-28-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-28-2024
// ******************************************************************************************
// <copyright file="DataService.cs" company="Terry D. Eppler">
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
//   DataService.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using OfficeOpenXml;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using static System.IO.File;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.ModelBase" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeRedundantParentheses" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    public class DataService : DataScaffold
    {
        /// <summary>
        /// Gets the SQL statement.
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
        /// Gets the keys.
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        public IList<int> Keys
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

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataService"/> class.
        /// </summary>
        public DataService( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataService"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        public DataService( Source source, Provider provider = Provider.Access )
        {
            _source = source;
            _provider = provider;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, Command.SELECTALL );
            _dataTable = GetDataTable( );
            _elements = CreateSeries( _dataTable );
            _dataColumns = GetDataColumns( );
            _columnNames = GetColumnNames( );
            _keys = GetPrimaryKeys( );
            _fields = GetFields( );
            _numerics = GetNumerics( );
            _dates = GetDates( );
            _record = GetData( )?.FirstOrDefault( );
            _map = _record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="where">The where.</param>
        public DataService( Source source, Provider provider, IDictionary<string, object> where )
        {
            _source = source;
            _provider = provider;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, where );
            _dataTable = GetDataTable( );
            _elements = CreateSeries( _dataTable );
            _dataColumns = GetDataColumns( );
            _columnNames = GetColumnNames( );
            _keys = GetPrimaryKeys( );
            _fields = GetFields( );
            _numerics = GetNumerics( );
            _dates = GetDates( );
            _record = GetData( )?.FirstOrDefault( );
            _map = _record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="updates">The updates.</param>
        /// <param name="where">The where.</param>
        /// <param name="commandType">Type of the command.</param>
        public DataService( Source source, Provider provider, IDictionary<string, object> updates,
            IDictionary<string, object> where, Command commandType = Command.UPDATE )
        {
            _source = source;
            _provider = provider;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, updates, where, commandType );
            _dataTable = GetDataTable( );
            _dataColumns = GetDataColumns( );
            _columnNames = GetColumnNames( );
            _keys = GetPrimaryKeys( );
            _fields = GetFields( );
            _numerics = GetNumerics( );
            _dates = GetDates( );
            _elements = CreateSeries( _dataTable );
            _record = GetData( )?.FirstOrDefault( );
            _map = _record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="where">The where.</param>
        /// <param name="commandType">Type of the command.</param>
        public DataService( Source source, Provider provider, IEnumerable<string> columns,
            IDictionary<string, object> where, Command commandType = Command.SELECT )
        {
            _source = source;
            _provider = provider;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, columns, where, commandType );
            _dataTable = GetDataTable( );
            _dataColumns = GetDataColumns( );
            _columnNames = GetColumnNames( );
            _keys = GetPrimaryKeys( );
            _fields = GetFields( );
            _numerics = GetNumerics( );
            _dates = GetDates( );
            _elements = CreateSeries( _dataTable );
            _record = GetData( )?.FirstOrDefault( );
            _map = _record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataService"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="numerics">The numerics.</param>
        /// <param name="where">The where.</param>
        /// <param name="commandType">Type of the command.</param>
        public DataService( Source source, Provider provider, IEnumerable<string> fields,
            IEnumerable<string> numerics, IDictionary<string, object> where,
            Command commandType )
        {
            _source = source;
            _provider = provider;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, fields, numerics, where,
                commandType );

            _dataTable = GetDataTable( );
            _dataColumns = GetDataColumns( );
            _columnNames = GetColumnNames( );
            _keys = GetPrimaryKeys( );
            _fields = GetFields( );
            _numerics = GetNumerics( );
            _dates = GetDates( );
            _elements = CreateSeries( _dataTable );
            _record = GetData( )?.FirstOrDefault( );
            _map = _record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataService"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="where">The where.</param>
        public DataService( Source source, IDictionary<string, object> where )
        {
            _source = source;
            _provider = Provider.Access;
            _connection = new BudgetConnection( source, _provider ).Create( );
            _sqlStatement = new SqlStatement( source, Provider.Access, where );
            _dataTable = GetDataTable( );
            _dataColumns = GetDataColumns( );
            _columnNames = GetColumnNames( );
            _keys = GetPrimaryKeys( );
            _fields = GetFields( );
            _numerics = GetNumerics( );
            _dates = GetDates( );
            _elements = CreateSeries( _dataTable );
            _record = GetData( )?.FirstOrDefault( );
            _map = _record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataService"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="sqlText">The SQL text.</param>
        public DataService( Source source, Provider provider, string sqlText )
        {
            _source = source;
            _provider = provider;
            _connection = new BudgetConnection( source, provider ).Create( );
            _sqlStatement = new SqlStatement( source, provider, sqlText );
            _dataTable = GetDataTable( );
            _dataColumns = GetDataColumns( );
            _columnNames = GetColumnNames( );
            _keys = GetPrimaryKeys( );
            _fields = GetFields( );
            _numerics = GetNumerics( );
            _dates = GetDates( );
            _elements = CreateSeries( _dataTable );
            _record = GetData( )?.FirstOrDefault( );
            _map = _record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataService"/> class.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <param name="sqlText">The SQL text.</param>
        /// <param name="commandType">Type of the command.</param>
        public DataService( string fullPath, string sqlText, Command commandType = Command.SELECT )
        {
            _connection = new BudgetConnection( fullPath ).Create( );
            _source = Source.External;
            _provider = Provider.Access;
            _sqlStatement = new SqlStatement( _source, _provider, sqlText, commandType );
            _dataTable = GetDataTable( );
            _dataColumns = GetDataColumns( );
            _columnNames = GetColumnNames( );
            _keys = GetPrimaryKeys( );
            _fields = GetFields( );
            _numerics = GetNumerics( );
            _dates = GetDates( );
            _elements = CreateSeries( _dataTable );
            _record = GetData( )?.FirstOrDefault( );
            _map = _record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataService"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public DataService( IQuery query )
        {
            _source = query.Source;
            _provider = query.Provider;
            _sqlStatement = query.SqlStatement;
            _connection = new BudgetConnection( _source, _provider ).Create( );
            _dataTable = GetDataTable( );
            _dataColumns = GetDataColumns( );
            _columnNames = GetColumnNames( );
            _keys = GetPrimaryKeys( );
            _fields = GetFields( );
            _numerics = GetNumerics( );
            _dates = GetDates( );
            _elements = CreateSeries( _dataTable );
            _record = GetData( )?.FirstOrDefault( );
            _map = _record?.ToDictionary( );
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <param name="dataRows">The data rows.</param>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetValues( IEnumerable<DataRow> dataRows, string column )
        {
            try
            {
                ThrowIf.Null( dataRows, nameof( dataRows ) );
                ThrowIf.Null( column, nameof( column ) );
                var _query = dataRows
                    ?.Select( v => v.Field<string>( column ) )
                    ?.Distinct( );

                return _query?.Any( ) == true
                    ? _query
                    : default( IEnumerable<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<string> );
            }
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <param name="dataRows">The data rows.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetValues( IEnumerable<DataRow> dataRows, string name,
            string value )
        {
            try
            {
                ThrowIf.Null( dataRows, nameof( dataRows ) );
                ThrowIf.Null( value, nameof( value ) );
                var _query = dataRows
                    ?.Where( v => v.Field<string>( $"{name}" ).Equals( value ) )
                    ?.Select( v => v.Field<string>( $"{name}" ) )
                    ?.Distinct( );

                return _query?.Any( ) == true
                    ? _query
                    : default( IEnumerable<string> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IEnumerable<string> );
            }
        }

        /// <summary>
        /// Creates the table from worksheet.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="header">if set to
        /// <c>true</c> [header].</param>
        /// <returns></returns>
        public static DataTable CreateTableFromWorksheet( string filePath, bool header = true )
        {
            try
            {
                ThrowIf.Null( filePath, nameof( filePath ) );
                using var _excelPackage = new ExcelPackage( );
                using var _fileStream = OpenRead( filePath );
                _excelPackage.Load( _fileStream );
                var _worksheet = _excelPackage?.Workbook
                    ?.Worksheets?.First( );

                var _dataTable = new DataTable( _worksheet?.Name );
                if( _worksheet?.Cells != null )
                {
                    var _lastColumn = _worksheet.Dimension.End.Column;
                    var _lastRow = _worksheet.Dimension.End.Row;
                    foreach( var _cell in _worksheet?.Cells[ 1, 1, 1, _lastColumn ] )
                    {
                        _dataTable?.Columns?.Add( header
                            ? _cell.Text
                            : $"Column {_cell.Start.Column}" );
                    }

                    var _start = header
                        ? 2
                        : 1;

                    for( var _row = _start; _row <= _lastRow; _row++ )
                    {
                        var _range = _worksheet.Cells[ _row, 1, _row, _lastColumn ];
                        var _data = _dataTable.Rows?.Add( );
                        foreach( var _cell in _range )
                        {
                            _data[ _cell.Start.Column - 1 ] = _cell?.Text;
                        }
                    }

                    return _dataTable?.Rows?.Count > 0
                        ? _dataTable
                        : default( DataTable );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataTable );
            }

            return default( DataTable );
        }

        /// <summary>
        /// Creates the series.
        /// </summary>
        /// <param name="dataTable">
        /// The data table.
        /// </param>
        /// <returns>
        /// Dictionary
        /// </returns>
        private static IDictionary<string, IEnumerable<string>> CreateSeries( DataTable dataTable )
        {
            try
            {
                ThrowIf.Null( dataTable, nameof( dataTable ) );
                var _dict = new Dictionary<string, IEnumerable<string>>( );
                var _columns = dataTable?.Columns;
                var _rows = dataTable?.AsEnumerable( );
                for( var _i = 0; _i < _columns?.Count; _i++ )
                {
                    if( !string.IsNullOrEmpty( _columns[ _i ]?.ColumnName )
                        && ( _columns[ _i ]?.DataType == typeof( string ) ) )
                    {
                        var _name = GetValues( _rows, _columns[ _i ]?.ColumnName );
                        _dict?.Add( _columns[ _i ]?.ColumnName, _name );
                    }
                }

                return _dict?.Any( ) == true
                    ? _dict
                    : default( Dictionary<string, IEnumerable<string>> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, IEnumerable<string>> );
            }
        }
    }
}