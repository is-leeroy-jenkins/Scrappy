// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-28-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-28-2024
// ******************************************************************************************
// <copyright file="ExcelQuery.cs" company="Terry D. Eppler">
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
//   ExcelQuery.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using Microsoft.Win32;
    using OfficeOpenXml;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Runtime.InteropServices;

    /// <inheritdoc/>
    /// <summary> </summary>
    /// <seealso cref="T:Badger.Query"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeRedundantParentheses" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class ExcelQuery : BudgetQuery
    {
        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.ExcelQuery"/>
        /// class.
        /// </summary>
        public ExcelQuery( )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ExcelQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        public ExcelQuery( Source source )
            : base( source, Provider.Excel, Command.SELECT )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ExcelQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="dict"> The dictionary. </param>
        public ExcelQuery( Source source, IDictionary<string, object> dict )
            : base( source, Provider.Excel, dict, Command.SELECT )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ExcelQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="dict"> The dictionary. </param>
        /// <param name="commandType"> Type of the command. </param>
        public ExcelQuery( Source source, IDictionary<string, object> dict, Command commandType )
            : base( source, Provider.Excel, dict, commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ExcelQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="updates"> The updates. </param>
        /// <param name="where"> The where. </param>
        /// <param name="commandType"> Type of the command. </param>
        public ExcelQuery( Source source, IDictionary<string, object> updates,
            IDictionary<string, object> where, Command commandType = Command.UPDATE )
            : base( source, Provider.Excel, updates, where, commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ExcelQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="columns"> The columns. </param>
        /// <param name="criteria"> The criteria. </param>
        /// <param name="commandType"> Type of the command. </param>
        public ExcelQuery( Source source, IEnumerable<string> columns,
            IDictionary<string, object> criteria, Command commandType = Command.SELECT )
            : base( source, Provider.Excel, columns, criteria, commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ExcelQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="fields"> The fields. </param>
        /// <param name="numerics"> The numerics. </param>
        /// <param name="criteria"> The criteria. </param>
        /// <param name="commandType"> Type of the command. </param>
        public ExcelQuery( Source source, IEnumerable<string> fields, IEnumerable<string> numerics,
            IDictionary<string, object> criteria, Command commandType = Command.SELECT )
            : base( source, Provider.Excel, fields, numerics, criteria,
                commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ExcelQuery"/>
        /// class.
        /// </summary>
        /// <param name="sqlStatement"> The sqlStatement. </param>
        public ExcelQuery( ISqlStatement sqlStatement )
            : base( sqlStatement )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ExcelQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="sqlText"> The SQL text. </param>
        public ExcelQuery( Source source, string sqlText )
            : base( source, Provider.Excel, sqlText )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ExcelQuery"/>
        /// class.
        /// </summary>
        /// <param name="fullPath"> The fullpath. </param>
        /// <param name="sqlText"> </param>
        /// <param name="commandType"> The commandType. </param>
        public ExcelQuery( string fullPath, string sqlText, Command commandType = Command.SELECT )
            : base( fullPath, sqlText, commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ExcelQuery"/>
        /// class.
        /// </summary>
        /// <param name="fullPath"> The fullpath. </param>
        /// <param name="commandType"> The commandType. </param>
        /// <param name="dict"> </param>
        public ExcelQuery( string fullPath, Command commandType, IDictionary<string, object> dict )
            : base( fullPath, commandType, dict )
        {
        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="workBook">The work book.</param>
        public void SaveFile( ExcelPackage workBook )
        {
            try
            {
                ThrowIf.Null( workBook, nameof( workBook ) );
                var _dialog = new SaveFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    FilterIndex = 1
                };

                if( _dialog?.ShowDialog( ) == true )
                {
                    var _name = _dialog.FileName;
                    workBook.Save( _name );
                    var _msg = "Save Successful!";
                    var _message = new SplashMessage( _msg );
                    _message?.ShowDialog( );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Writes the excel file.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="filePath">The file path.</param>
        public void WriteExcelFile( DataTable dataTable, string filePath )
        {
            try
            {
                ThrowIf.Empty( dataTable, nameof( dataTable ) );
                ThrowIf.Null( filePath, nameof( filePath ) );
                using var _excelPackage = ReadExcelFile( filePath );
                var _name = Path.GetFileNameWithoutExtension( filePath );
                var _excelWorksheet = _excelPackage?.Workbook?.Worksheets?.Add( _name );
                var _columns = dataTable?.Columns?.Count;
                var _rows = dataTable?.Rows?.Count;
                for( var _column = 1; _column <= _columns; _column++ )
                {
                    if( _excelWorksheet != null )
                    {
                        var _colName = dataTable.Columns[ _column - 1 ].ColumnName;
                        _excelWorksheet.Cells[ 1, _column ].Value = _colName;
                    }
                }

                for( var _r = 1; _r <= _rows; _r++ )
                {
                    for( var _c = 0; _c < _columns; _c++ )
                    {
                        if( _excelWorksheet != null )
                        {
                            var _column = dataTable.Rows[ _r - 1 ][ _c ];
                            _excelWorksheet.Cells[ _r + 1, _c + 1 ].Value = _column;
                        }
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Gets the excel file.
        /// </summary>
        /// <returns></returns>
        public string GetFilePath( )
        {
            try
            {
                var _fileName = "";
                var _dialog = new OpenFileDialog
                {
                    Title = "Excel File Dialog",
                    InitialDirectory = @"c:\",
                    Filter = "Excel files (*.xlsx)|*.xls|*.csv",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if( _dialog.ShowDialog( ) == true )
                {
                    _fileName = _dialog.FileName;
                }

                return _fileName;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Imports the data.
        /// </summary>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <returns></returns>
        public DataTable ImportData( ref string sheetName )
        {
            try
            {
                ThrowIf.Null( sheetName, nameof( sheetName ) );
                var _dataSet = new DataSet( );
                var _connection = _dataConnection as OleDbConnection;
                _connection?.Open( );
                var _sql = $"SELECT * FROM ${sheetName}";
                var _schema = _connection?.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );
                if( ( _schema?.Columns?.Count > 0 )
                    && !SheetExists( sheetName, _schema ) )
                {
                    var _msg = "Sheet Does Not Exist!";
                    var _message = new SplashMessage( _msg );
                    _message?.ShowDialog( );
                }
                else
                {
                    sheetName = _schema?.Rows[ 0 ][ "TABLENAME" ].ToString( );
                }

                _dataAdapter = new OleDbDataAdapter( _sql, _connection );
                _dataAdapter?.Fill( _dataSet );
                return _dataSet?.Tables[ 0 ];
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataTable );
            }
        }

        /// <summary>
        /// CSVs the import.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <returns></returns>
        public DataTable CsvImport( string fileName, ref string sheetName )
        {
            try
            {
                ThrowIf.Null( fileName, nameof( fileName ) );
                ThrowIf.Null( sheetName, nameof( sheetName ) );
                var _data = new DataSet( );
                var _sql = $"SELECT * FROM {sheetName}";
                var _connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;"
                    + $"Data Source={Path.GetDirectoryName( fileName )} "
                    + "Extended Properties='Text;HDR=YES;FMT=Delimited'";

                var _connection = new OleDbConnection( _connectionString );
                var _schema = _connection.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );
                if( !string.IsNullOrEmpty( sheetName ) )
                {
                    if( !SheetExists( sheetName, _schema ) )
                    {
                        var _msg = $"{sheetName} in {fileName} Does Not Exist!";
                        var _message = new SplashMessage( _msg );
                        _message?.ShowDialog( );
                    }
                }
                else
                {
                    sheetName = _schema?.Rows[ 0 ][ "TABLENAME" ].ToString( );
                }

                _dataAdapter = new OleDbDataAdapter( _sql, _connection );
                _dataAdapter.Fill( _data );
                return _data.Tables[ 0 ];
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataTable );
            }
        }

        /// <summary>
        /// Releases the specified range.
        /// </summary>
        /// <param name="range">The range.</param>
        /// <param name="workSheet">The work sheet.</param>
        /// <param name="excel">The excel.</param>
        protected virtual void Release( ExcelRange range, ExcelWorksheet workSheet,
            ExcelPackage excel )
        {
            try
            {
                GC.Collect( );
                GC.WaitForPendingFinalizers( );
                Marshal.ReleaseComObject( range );
                Marshal.ReleaseComObject( workSheet );
                Marshal.ReleaseComObject( excel );
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Reads the excel file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public ExcelPackage ReadExcelFile( string filePath )
        {
            try
            {
                ThrowIf.Null( filePath, nameof( filePath ) );
                var _fileInfo = new FileInfo( filePath );
                return new ExcelPackage( _fileInfo );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ExcelPackage );
            }
        }

        /// <summary>
        /// Sheets the exists.
        /// </summary>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        private bool SheetExists( string sheetName, DataTable dataTable )
        {
            try
            {
                ThrowIf.Null( sheetName, nameof( sheetName ) );
                ThrowIf.Empty( dataTable, nameof( dataTable ) );
                for( var _i = 0; _i < dataTable.Rows.Count; _i++ )
                {
                    var _dataRow = dataTable.Rows[ _i ];
                    if( sheetName == _dataRow[ "TABLENAME" ].ToString( ) )
                    {
                        return true;
                    }
                }

                return false;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return false;
            }
        }
    }
}