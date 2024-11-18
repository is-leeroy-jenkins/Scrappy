// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-28-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-28-2024
// ******************************************************************************************
// <copyright file="SQLiteQuery.cs" company="Terry D. Eppler">
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
//   SQLiteQuery.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SQLite;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;

    /// <inheritdoc/>
    /// <summary> </summary>
    /// <seealso cref="T:Badger.Query"/>
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeRedundantParentheses" ) ]
    public class SQLiteQuery : BudgetQuery
    {
        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.SQLiteQuery"/>
        /// class.
        /// </summary>
        public SQLiteQuery( )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.SQLiteQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        public SQLiteQuery( Source source )
            : base( source, Provider.SQLite, Command.SELECT )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.SQLiteQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="updates"> The updates. </param>
        public SQLiteQuery( Source source, IDictionary<string, object> updates )
            : base( source, Provider.SQLite, updates, Command.SELECT )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SQLiteQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="dict"> The dictionary. </param>
        /// <param name="commandType"> Type of the command. </param>
        public SQLiteQuery( Source source, IDictionary<string, object> dict, Command commandType )
            : base( source, Provider.SQLite, dict, commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SQLiteQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="updates"> The updates. </param>
        /// <param name="where"> The where. </param>
        /// <param name="commandType"> Type of the command. </param>
        public SQLiteQuery( Source source, IDictionary<string, object> updates,
            IDictionary<string, object> where, Command commandType = Command.UPDATE )
            : base( source, Provider.SQLite, updates, where, commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SQLiteQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="columns"> The columns. </param>
        /// <param name="criteria"> The criteria. </param>
        /// <param name="commandType"> Type of the command. </param>
        public SQLiteQuery( Source source, IEnumerable<string> columns,
            IDictionary<string, object> criteria, Command commandType = Command.SELECT )
            : base( source, Provider.SQLite, columns, criteria, commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the see cref="SQLiteQuery"/> class.
        /// </summary>
        /// <param name="sqlStatement"> The sqlStatement. </param>
        public SQLiteQuery( ISqlStatement sqlStatement )
            : base( sqlStatement )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SQLiteQuery"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="sqlText"> The SQL text. </param>
        public SQLiteQuery( Source source, string sqlText )
            : base( source, Provider.SQLite, sqlText )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SQLiteQuery"/>
        /// class.
        /// </summary>
        /// <param name="fullPath"> The fullpath. </param>
        /// <param name="sqlText"> </param>
        /// <param name="commandType"> The commandType. </param>
        public SQLiteQuery( string fullPath, string sqlText, Command commandType = Command.SELECT )
            : base( fullPath, sqlText, commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SQLiteQuery"/>
        /// class.
        /// </summary>
        /// <param name="fullPath"> The fullpath. </param>
        /// <param name="commandType"> The commandType. </param>
        /// <param name="dict"> </param>
        public SQLiteQuery( string fullPath, Command commandType, IDictionary<string, object> dict )
            : base( fullPath, commandType, dict )
        {
        }

        /// <summary> Gets the data adapter. </summary>
        /// <param name="command"> The command. </param>
        /// <returns> </returns>
        public SQLiteDataAdapter GetDataAdapter( SQLiteCommand command )
        {
            try
            {
                return command != null
                    ? new SQLiteDataAdapter( command )
                    : default( SQLiteDataAdapter );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( SQLiteDataAdapter );
            }
        }

        /// <summary> Creates the table from excel file. </summary>
        /// <param name="filePath"> The file path. </param>
        /// <param name="sheetName"> Name of the sheet. </param>
        /// <returns> </returns>
        public DataTable CreateTableFromExcelFile( string filePath, ref string sheetName )
        {
            if( !string.IsNullOrEmpty( filePath )
                && !string.IsNullOrEmpty( sheetName ) )
            {
                try
                {
                    var _dataSet = new DataSet( );
                    var _filePath = GetExcelFilePath( );
                    var _sql = $"SELECT * FROM [{sheetName}]";
                    var _msg = "Sheet Does Not Exist!";
                    var _excelQuery = new ExcelQuery( _filePath, _sql );
                    var _connection = _excelQuery.DataConnection as OleDbConnection;
                    _connection?.Open( );
                    var _table = _connection?.GetOleDbSchemaTable( OleDbSchemaGuid.Tables, null );
                    if( ( _table?.Rows.Count > 0 )
                        && CheckIfSheetNameExists( sheetName, _table ) )
                    {
                        var _message = new SplashMessage( _msg );
                        _message?.ShowDialog( );
                    }
                    else
                    {
                        sheetName = _table?.Rows[ 0 ][ "TABLENAME" ].ToString( );
                    }

                    var _adapter = new OleDbDataAdapter( _sql, _connection );
                    if( sheetName != null )
                    {
                        _adapter.Fill( _dataSet, sheetName );
                    }

                    return _dataSet.Tables[ 0 ];
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// Creates the table from CSV file.
        /// </summary>
        /// <param name="fileName"> Name of the file. </param>
        /// <param name="sheetName"> Name of the sheet. </param>
        /// <returns>
        /// DataTable
        /// </returns>
        public DataTable CreateTableFromCsvFile( string fileName, ref string sheetName )
        {
            if( !string.IsNullOrEmpty( fileName )
                && !string.IsNullOrEmpty( sheetName ) )
            {
                try
                {
                    var _name = Path.GetFileNameWithoutExtension( fileName );
                    var _dataSet = new DataSet( _name );
                    var _dataTable = new DataTable( sheetName );
                    _dataSet.DataSetName = _name;
                    _dataTable.TableName = sheetName;
                    _dataSet.Tables.Add( _dataTable );
                    var _sql = $"SELECT * FROM [{sheetName}]";
                    var _fullPath = GetExcelFilePath( );
                    if( !string.IsNullOrEmpty( _fullPath ) )
                    {
                        var _csvQuery = new CsvQuery( _fullPath, _sql );
                        var _connection = _csvQuery.DataConnection as OleDbConnection;
                        var _adapter = new OleDbDataAdapter( _sql, _connection );
                        _adapter?.Fill( _dataSet, sheetName );
                        return _dataTable.Columns.Count > 0
                            ? _dataTable
                            : default( DataTable );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <param name="dict"> The dictionary. </param>
        /// <returns>
        /// </returns>
        public IEnumerable<SQLiteParameter> GetParameters( Dictionary<string, object> dict )
        {
            if( dict?.Any( ) == true )
            {
                try
                {
                    var _parameters = dict.ToSqlDbParameters( Provider );
                    var _params = new List<SQLiteParameter>( );
                    foreach( var _prm in _parameters )
                    {
                        _params.Add( _prm as SQLiteParameter );
                    }

                    return _params?.Any( ) == true
                        ? _params
                        : default( IEnumerable<SQLiteParameter> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<SQLiteParameter> );
                }
            }

            return default( IEnumerable<SQLiteParameter> );
        }

        /// <summary>
        /// Gets the command builder.
        /// </summary>
        /// <param name="adapter"> The adapter. </param>
        /// <returns>
        /// </returns>
        private SQLiteCommandBuilder GetCommandBuilder( SQLiteDataAdapter adapter )
        {
            try
            {
                return !string.IsNullOrEmpty( adapter.SelectCommand.CommandText )
                    ? new SQLiteCommandBuilder( adapter )
                    : default( SQLiteCommandBuilder );
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return default( SQLiteCommandBuilder );
            }
        }

        /// <summary>
        /// Gets the excel file path.
        /// </summary>
        /// <returns>
        /// </returns>
        private string GetExcelFilePath( )
        {
            try
            {
                var _fileName = "";
                var _fileDialog = new OpenFileDialog
                {
                    Title = "Excel File Dialog",
                    InitialDirectory = @"C:\",
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
        /// Checks if sheet name exists.
        /// </summary>
        /// <param name="sheetName"> Name of the sheet. </param>
        /// <param name="dataSchema"> The data schema. </param>
        /// <returns>
        /// </returns>
        private bool CheckIfSheetNameExists( string sheetName, DataTable dataSchema )
        {
            try
            {
                ThrowIf.Null( sheetName, nameof( sheetName ) );
                ThrowIf.Empty( dataSchema, nameof( dataSchema ) );
                for( var _i = 0; _i < dataSchema.Rows.Count; _i++ )
                {
                    var _dataRow = dataSchema.Rows[ _i ];
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

        /// <summary>
        /// Creates the database.
        /// </summary>
        private void CreateDatabase( )
        {
            var _commandText = @"CREATE TABLE IF NOT EXISTS [MyTable] 
                                    ( [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                                      [Key] NVARCHAR(2048)  NULL,
                                      [Value] VARCHAR(2048)  NULL )";

            using var _connection = new SQLiteConnection( "Data source=Data.db" );
            var _command = new SQLiteCommand( _connection );
            _connection.Open( );
            _command.CommandText = _commandText;
            _command.ExecuteNonQuery( );
            _command.CommandText =
                "INSERT INTO MyTable ( Key,Value ) VALUES ( 'key one','value one' )";

            _command.ExecuteNonQuery( );
            _command.CommandText =
                "INSERT INTO MyTable ( Key,Value ) VALUES ( 'key two','value value' )";

            _command.ExecuteNonQuery( );
            _command.CommandText = "SELECT * FROM MyTable";
            _command.ExecuteReader( );
            _connection.Close( );
        }
    }
}