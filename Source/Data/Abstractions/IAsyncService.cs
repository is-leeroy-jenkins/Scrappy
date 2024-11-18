// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="IAsyncService.cs" company="Terry D. Eppler">
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
//   IAsyncService.cs
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

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public interface IAsyncService
    {
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the criteria.
        /// </summary>
        /// <value>
        /// The criteria.
        /// </value>
        IDictionary<string, object> Criteria { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the SQL statement.
        /// </summary>
        /// <value>
        /// The SQL statement.
        /// </value>
        ISqlStatement SqlStatement { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the connection factory.
        /// </summary>
        /// <value>
        /// The connection factory.
        /// </value>
        DbConnection Connection { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the data adapter.
        /// </summary>
        /// <value>
        /// The data adapter.
        /// </value>
        Task<DbDataAdapter> DataAdapter { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the data private protected set.
        /// </summary>
        /// <value>
        /// The data private protected set.
        /// </value>
        Task<DataSet> DataSet { get; }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <value>
        /// The data table.
        /// </value>
        Task<DataTable> DataTable { get; }

        /// <summary>
        /// Gets or sets the data columns.
        /// </summary>
        /// <value>
        /// The data columns.
        /// </value>
        Task<IList<DataColumn>> DataColumns { get; }

        /// <summary>
        /// Gets or sets the column names.
        /// </summary>
        /// <value>
        /// The column names.
        /// </value>
        Task<IList<string>> ColumnNames { get; }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        Task<IList<string>> Fields { get; }

        /// <summary>
        /// Gets or sets the dates.
        /// </summary>
        /// <value>
        /// The dates.
        /// </value>
        Task<IList<string>> Dates { get; }

        /// <summary>
        /// Gets or sets the numerics.
        /// </summary>
        /// <value>
        /// The numerics.
        /// </value>
        Task<IList<string>> Numerics { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is busy.
        /// </summary>
        /// <value>
        /// <c> true </c>
        /// if this instance is busy; otherwise,
        /// <c> false </c>
        /// </value>
        bool IsBusy { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>
        /// The query.
        /// </value>
        IQuery Query { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        Task<DataRow> Record { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the keys.
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        Task<IList<int>> Keys { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the map.
        /// </summary>
        /// <value>
        /// The map.
        /// </value>
        Task<IDictionary<string, object>> Map { get; }

        /// <inheritdoc/>
        /// <summary>
        /// Gets the data elements.
        /// </summary>
        /// <value>
        /// The data elements.
        /// </value>
        Task<IDictionary<string, IEnumerable<string>>> DataElements { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <returns></returns>
        DataTable GetDataTable( );

        /// <inheritdoc />
        /// <summary>
        /// Gets the data table asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<DataTable> GetDataTableAsync( );

        /// <inheritdoc />
        /// <summary>
        /// Gets the record asynchronous.
        /// </summary>
        /// <returns></returns>
        DataRow GetRecord( );

        /// <inheritdoc />
        /// <summary>
        /// Gets the record asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<DataRow> GetRecordAsync( );

        /// <inheritdoc />
        /// <summary>
        /// Gets the data private protected set asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<DataSet> GetDataSetAsync( );

        /// <inheritdoc />
        /// <summary>
        /// Sets the column captions.
        /// </summary>
        /// <param name="dataTable"> The data table.
        /// </param>
        void SetColumnCaptions( DataTable dataTable );

        /// <inheritdoc />
        /// <summary>
        /// Gets the fields asynchronous.
        /// </summary>
        /// <returns>
        /// Task of IList of string
        /// </returns>
        Task<IList<string>> GetFieldsAsync( );

        /// <inheritdoc />
        /// <summary>
        /// Gets the numerics asynchronous.
        /// </summary>
        /// <returns>
        /// Task of IList of string
        /// </returns>
        Task<IList<string>> GetNumericsAsync( );

        /// <inheritdoc />
        /// <summary>
        /// Gets the dates asynchronous.
        /// </summary>
        /// <returns>
        /// Task of IList of string
        /// </returns>
        Task<IList<string>> GetDatesAsync( );

        /// <inheritdoc />
        /// <summary>
        /// Gets the primary keys asynchronous.
        /// </summary>
        /// <returns>
        /// Task of IList of int
        /// </returns>
        Task<IList<int>> GetKeysAsnyc( );

        /// <inheritdoc />
        /// <summary>
        /// Gets the ordinals asynchronous.
        /// </summary>
        /// <returns>
        /// Task(List)
        /// </returns>
        Task<IList<int>> GetOrdinalsAsync( );

        /// <inheritdoc />
        /// <summary>
        /// Gets the map asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IDictionary<string, object>> GetMapAsync( );

        /// <inheritdoc />
        /// <summary>
        /// Gets the schema asynchronous.
        /// </summary>
        /// <returns>
        /// Task(IDictionary(string, Type))
        /// </returns>
        Task<IDictionary<string, Type>> GetSchemaAsync( );

        /// <inheritdoc />
        /// <summary>
        /// Gets the columns asynchronous.
        /// </summary>
        /// <returns>
        /// </returns>
        Task<IList<DataColumn>> GetColumnsAsync( );

        /// <inheritdoc />
        /// <summary>
        /// Gets the names asynchronous.
        /// </summary>
        /// <returns>
        /// </returns>
        Task<IList<string>> GetNamesAsync( );

        /// <summary> Gets the values asynchronous. </summary>
        /// <param name="dataRows"> The data rows. </param>
        /// <param name="name"> The name. </param>
        /// <param name="value"> The value. </param>
        /// <returns> </returns>
        Task<IList<string>> GetValuesAsync( IEnumerable<DataRow> dataRows, string name,
            string value );

        /// <summary> Gets the values. </summary>
        /// <param name="dataRows"> The data rows. </param>
        /// <param name="name"> The column. </param>
        /// <returns> </returns>
        Task<IList<string>> GetValuesAsync( IEnumerable<DataRow> dataRows, string name );

        /// <summary>
        /// Creates the series asynchronous.
        /// </summary>
        /// <returns>
        /// </returns>
        Task<IDictionary<string, IEnumerable<string>>> GetSeriesAsync( );
    }
}