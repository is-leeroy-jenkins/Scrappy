// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="AsyncCore.cs" company="Terry D. Eppler">
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
//   AsyncCore.cs
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

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ValueParameterNotUsed" ) ]
    [ SuppressMessage( "ReSharper", "MergeConditionalExpression" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    public abstract class AsyncCore : ISource, IProvider, IDisposable
    {
        /// <summary>
        /// The locked object
        /// </summary>
        private object _path;

        /// <summary>
        /// The busy
        /// </summary>
        private bool _busy;

        /// <summary>
        /// The source
        /// </summary>
        private protected Source _source;

        /// <summary>
        /// The provider
        /// </summary>
        private protected Provider _provider;

        /// <summary>
        /// The command type
        /// </summary>
        private protected Command _commandType;

        /// <summary>
        /// The data connection
        /// </summary>
        private protected DbConnection _connection;

        /// <summary>
        /// The SQL statement
        /// </summary>
        private protected ISqlStatement _sqlStatement;

        /// <summary>
        /// The criteria
        /// </summary>
        private protected IDictionary<string, object> _criteria;

        /// <summary>
        /// The data adapter
        /// </summary>
        private protected Task<DbDataAdapter> _dataAdapter;

        /// <summary>
        /// The data reader
        /// </summary>
        private protected DbDataReader _dataReader;

        /// <summary>
        /// The is disposed
        /// </summary>
        private protected bool _disposed;

        /// <summary>
        /// The data columns
        /// </summary>
        private protected Task<IList<DataColumn>> _dataColumns;

        /// <summary>
        /// The column names
        /// </summary>
        private protected Task<IList<string>> _columnNames;

        /// <summary>
        /// The dates
        /// </summary>
        private protected Task<IList<string>> _dates;

        /// <summary>
        /// The fields
        /// </summary>
        private protected Task<IList<string>> _fields;

        /// <summary>
        /// The numerics
        /// </summary>
        private protected Task<IList<string>> _numerics;

        /// <summary>
        /// The data set
        /// </summary>
        private protected Task<DataSet> _dataSet;

        /// <summary>
        /// The data table
        /// </summary>
        private protected Task<DataTable> _dataTable;

        /// <inheritdoc />
        /// <summary>
        /// Gets the source.
        /// </summary>
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
        /// </summary>
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
        /// Gets or sets the criteria.
        /// </summary>
        /// <value>
        /// The criteria.
        /// </value>
        public IDictionary<string, object> Criteria
        {
            get
            {
                return _criteria;
            }
            private protected set
            {
                _criteria = value;
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

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the data adapter.
        /// </summary>
        /// <value>
        /// The data adapter.
        /// </value>
        public Task<DbDataAdapter> DataAdapter
        {
            get
            {
                return _dataAdapter;
            }
            private protected set
            {
                _dataAdapter = value;
            }
        }

        /// <summary> Gets or sets a value indicating
        /// whether this instance is disposed. </summary>
        /// <value>
        /// <c> true </c>
        /// if this instance is disposed; otherwise,
        /// <c> false </c>
        /// .
        /// </value>
        public bool IsDisposed
        {
            get
            {
                return _disposed;
            }
            private protected set
            {
                _disposed = true;
            }
        }

        /// <summary>
        /// Gets or sets the data reader.
        /// </summary>
        /// <value>
        /// The data reader.
        /// </value>
        public DbDataReader DataReader
        {
            get
            {
                return _dataReader;
            }
            private protected set
            {
                _dataReader = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the data set.
        /// </summary>
        /// <value>
        /// The data set.
        /// </value>
        public Task<DataSet> DataSet
        {
            get
            {
                return _dataSet;
            }
            private protected set
            {
                _dataSet = value;
            }
        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <value>
        /// The data table.
        /// </value>
        public Task<DataTable> DataTable
        {
            get
            {
                return _dataTable;
            }

            private protected set
            {
                _dataTable = value;
            }
        }

        /// <summary>
        /// Gets or sets the data columns.
        /// </summary>
        /// <value>
        /// The data columns.
        /// </value>
        public Task<IList<DataColumn>> DataColumns
        {
            get
            {
                return _dataColumns;
            }
            private protected set
            {
                _dataColumns = value;
            }
        }

        /// <summary>
        /// Gets or sets the column names.
        /// </summary>
        /// <value>
        /// The column names.
        /// </value>
        public Task<IList<string>> ColumnNames
        {
            get
            {
                return _columnNames;
            }
            private protected set
            {
                _columnNames = value;
            }
        }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        public Task<IList<string>> Fields
        {
            get
            {
                return _fields;
            }
            private protected set
            {
                _fields = value;
            }
        }

        /// <summary>
        /// Gets or sets the dates.
        /// </summary>
        /// <value>
        /// The dates.
        /// </value>
        public Task<IList<string>> Dates
        {
            get
            {
                return _dates;
            }
            private protected set
            {
                _dates = value;
            }
        }

        /// <summary>
        /// Gets or sets the numerics.
        /// </summary>
        /// <value>
        /// The numerics.
        /// </value>
        public Task<IList<string>> Numerics
        {
            get
            {
                return _numerics;
            }
            private protected set
            {
                _columnNames = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is busy.
        /// </summary>
        /// <value>
        /// <c> true </c>
        /// if this instance is busy; otherwise,
        /// <c> false </c>
        /// </value>
        public bool IsBusy
        {
            get
            {
                if( _path == null )
                {
                    _path = new object( );
                    lock( _path )
                    {
                        _busy = true;
                        return _busy;
                    }
                }
                else
                {
                    lock( _path )
                    {
                        _busy = true;
                        return _busy;
                    }
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose( )
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        /// <summary> Releases unmanaged and -
        /// optionally - managed resources. </summary>
        /// <param name="disposing">
        /// <c> true </c>
        /// to release both managed and unmanaged resources;
        /// <c> false </c>
        /// to release only unmanaged resources.
        /// </param>
        private protected virtual void Dispose( bool disposing )
        {
            if( disposing )
            {
                _connection?.Dispose( );
                _dataAdapter?.Dispose( );
                _dataReader?.Dispose( );
                _disposed = true;
            }
        }

        /// <summary>
        /// Fails the specified _ex.
        /// </summary>
        /// <param name="_ex">The _ex.</param>
        private protected static void Fail( Exception _ex )
        {
            var _error = new ErrorWindow( _ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}