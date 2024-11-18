// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-28-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-28-2024
// ******************************************************************************************
// <copyright file="CsvQuery.cs" company="Terry D. Eppler">
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
//   CsvQuery.cs
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

    /// <inheritdoc/>
    /// <summary> </summary>
    /// <seealso cref="T:Badger.Query"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class CsvQuery : BudgetQuery
    {
        /// <inheritdoc/>
        /// <summary>
        /// Gets the Provider
        /// </summary>
        public new Provider Provider { get; set; } = Provider.CSV;

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CsvQuery"/>
        /// class.
        /// </summary>
        public CsvQuery( )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CsvQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        public CsvQuery( Source source )
            : base( source, Provider.Access, Command.SELECT )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CsvQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="dict"> The dictionary. </param>
        public CsvQuery( Source source, IDictionary<string, object> dict )
            : base( source, Provider.Access, dict, Command.SELECT )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CsvQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source Data. </param>
        /// <param name="provider"> The provider used. </param>
        /// <param name="dict"> </param>
        /// <param name="commandType"> The type of sql command. </param>
        public CsvQuery( Source source, Provider provider, IDictionary<string, object> dict,
            Command commandType )
            : base( source, provider, dict, commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CsvQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="updates"> </param>
        /// <param name="where"> The where. </param>
        /// <param name="commandType"> Type of the command. </param>
        public CsvQuery( Source source, Provider provider, IDictionary<string, object> updates,
            IDictionary<string, object> where, Command commandType = Command.UPDATE )
            : base( source, provider, updates, where, commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CsvQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="columns"> The columns. </param>
        /// <param name="criteria"> </param>
        /// <param name="commandType"> Type of the command. </param>
        public CsvQuery( Source source, Provider provider, IEnumerable<string> columns,
            IDictionary<string, object> criteria, Command commandType = Command.SELECT )
            : base( source, provider, columns, criteria, commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CsvQuery"/>
        /// class.
        /// </summary>
        /// <param name="sqlStatement"> The sqlStatement. </param>
        public CsvQuery( ISqlStatement sqlStatement )
            : base( sqlStatement )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CsvQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="sqlText"> The SQL text. </param>
        public CsvQuery( Source source, Provider provider, string sqlText )
            : base( source, provider, sqlText )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CsvQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="dict"> </param>
        public CsvQuery( Source source, Provider provider, IDictionary<string, object> dict )
            : base( source, provider, dict )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CsvQuery"/>
        /// class.
        /// </summary>
        /// <param name="fullPath"> The fullpath. </param>
        /// <param name="sqlText"> </param>
        /// <param name="commandType"> The commandType. </param>
        public CsvQuery( string fullPath, string sqlText, Command commandType = Command.SELECT )
            : base( fullPath, sqlText, commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="CsvQuery"/>
        /// class.
        /// </summary>
        /// <param name="fullPath"> The fullpath. </param>
        /// <param name="commandType"> The commandType. </param>
        /// <param name="dict"> </param>
        public CsvQuery( string fullPath, Command commandType, IDictionary<string, object> dict )
            : base( fullPath, commandType, dict )
        {
        }

        /// <summary>
        /// CSVs the import.
        /// </summary>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <returns></returns>
        public DataTable CsvImport( ref string sheetName )
        {
            try
            {
                ThrowIf.Null( sheetName, nameof( sheetName ) );
                using var _dataSet = new DataSet( );
                var _sql = "SELECT * FROM [" + sheetName + "]";
                var _connstring =
                    $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Path.GetDirectoryName( sheetName )};"
                    + "Extended Properties='Text;HDR=YES;FMT=Delimited'";

                using var _connection = new OleDbConnection( _connstring );
                var _schema = _connection.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );
                if( !string.IsNullOrEmpty( sheetName ) )
                {
                    if( !SheetExists( sheetName, _schema ) )
                    {
                        var _msg = $"{sheetName} in {sheetName} Does Not Exist!";
                        var _message = new SplashMessage( _msg );
                        _message?.Show( );
                    }
                }
                else
                {
                    sheetName = _schema?.Rows[ 0 ][ "TABLENAME" ].ToString( );
                }

                using var _adapter = new OleDbDataAdapter( _sql, _connection );
                _adapter.Fill( _dataSet );
                return _dataSet.Tables[ 0 ];
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataTable );
            }
        }

        /// <summary> CSVs the import. </summary>
        /// <param name="filePath"> Name of the file. </param>
        /// <param name="sheetName"> Name of the sheet. </param>
        /// <returns> </returns>
        public DataTable CsvImport( string filePath, ref string sheetName )
        {
            try
            {
                ThrowIf.Null( filePath, nameof( filePath ) );
                ThrowIf.Null( sheetName, nameof( sheetName ) );
                using var _dataSet = new DataSet( );
                var _sql = "SELECT * FROM [" + sheetName + "]";
                var _connectionString =
                    $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={Path.GetDirectoryName( filePath )};Extended Properties='Text;HDR=YES;FMT=Delimited'";

                using var _connection = new OleDbConnection( _connectionString );
                var _schema = _connection.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );
                if( !string.IsNullOrEmpty( sheetName ) )
                {
                    if( !SheetExists( sheetName, _schema ) )
                    {
                        var _msg = $"{sheetName} in {filePath} Does Not Exist!";
                        var _message = new SplashMessage( _msg );
                        _message?.ShowDialog( );
                    }
                }
                else
                {
                    sheetName = _schema?.Rows[ 0 ][ "TABLENAME" ].ToString( );
                }

                using var _adapter = new OleDbDataAdapter( _sql, _connection );
                _adapter.Fill( _dataSet );
                return _dataSet.Tables[ 0 ];
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataTable );
            }
        }

        /// <summary> CSVs the export. </summary>
        /// <param name="dataTable"> The table. </param>
        /// <param name="filePath"> The file path. </param>
        public void CsvExport( DataTable dataTable, string filePath )
        {
            try
            {
                ThrowIf.Null( filePath, nameof( filePath ) );
                ThrowIf.Empty( dataTable, nameof( dataTable ) );
                using var _excel = CreateCsvFile( filePath );
                var _name = Path.GetFileNameWithoutExtension( filePath );
                var _sheet = _excel.Workbook.Worksheets.Add( _name );
                var _columns = dataTable.Columns.Count;
                var _rows = dataTable.Rows.Count;
                for( var _column = 1; _column <= _columns; _column++ )
                {
                    _sheet.Cells[ 1, _column ].Value = dataTable.Columns[ _column - 1 ].ColumnName;
                }

                for( var _row = 1; _row <= _rows; _row++ )
                {
                    for( var _col = 0; _col < _columns; _col++ )
                    {
                        _sheet.Cells[ _row + 1, _col + 1 ].Value =
                            dataTable.Rows[ _row - 1 ][ _col ];
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Creates the CSV file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public ExcelPackage CreateCsvFile( string filePath )
        {
            if( !string.IsNullOrEmpty( filePath ) )
            {
                try
                {
                    var _fileInfo = new FileInfo( filePath );
                    return new ExcelPackage( _fileInfo );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( ExcelPackage );
                }
            }

            return default( ExcelPackage );
        }

        /// <summary>
        /// Gets the CSV file path.
        /// </summary>
        /// <returns></returns>
        public string GetCsvFilePath( )
        {
            try
            {
                var _fileName = "";
                var _fileDialog = new OpenFileDialog
                {
                    Title = "CSV File Dialog",
                    InitialDirectory = @"c:\",
                    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if( _fileDialog.ShowDialog( ) == true )
                {
                    _fileName = _fileDialog.FileName;
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