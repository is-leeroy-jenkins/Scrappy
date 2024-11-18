// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="IDataService.cs" company="Terry D. Eppler">
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
//   IDataService.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Scrappy.ISource" />
    /// <seealso cref="T:Scrappy.IProvider" />
    public interface IDataService : ISource, IProvider
    {
        /// <summary>
        /// Gets a value indicating whether this instance is busy.
        /// </summary>
        /// <value>
        /// <c> true </c>
        /// if this instance is busy; otherwise,
        /// <c> false </c>
        /// </value>
        bool IsBusy { get; }

        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        TimeSpan Duration { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        DataRow Record { get; }

        /// <summary>
        /// Gets the data private protected set.
        /// </summary>
        /// <value>
        /// The data private protected set.
        /// </value>
        DataSet DataSet { get; }

        /// <summary>
        /// Gets the data elements.
        /// </summary>
        /// <value>
        /// The data elements.
        /// </value>
        IDictionary<string, IEnumerable<string>> DataElements { get; }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <value>
        /// The data table.
        /// </value>
        DataTable DataTable { get; }

        /// <summary>
        /// Gets or sets the data columns.
        /// </summary>
        /// <value>
        /// The data columns.
        /// </value>
        IList<DataColumn> DataColumns { get; }

        /// <summary>
        /// Gets or sets the column names.
        /// </summary>
        /// <value>
        /// The column names.
        /// </value>
        IList<string> ColumnNames { get; }

        /// <summary>
        /// Gets or sets the fields.
        /// </summary>
        /// <value>
        /// The fields.
        /// </value>
        IList<string> Fields { get; }

        /// <summary>
        /// Gets or sets the dates.
        /// </summary>
        /// <value>
        /// The dates.
        /// </value>
        IList<string> Dates { get; }

        /// <summary>
        /// Gets or sets the numerics.
        /// </summary>
        /// <value>
        /// The numerics.
        /// </value>
        IList<string> Numerics { get; }

        /// <summary>
        /// Gets or sets the map.
        /// </summary>
        /// <value>
        /// The map.
        /// </value>
        IDictionary<string, object> Map { get; }

        /// <summary>
        /// Gets the SQL statement.
        /// </summary>
        /// <value>
        /// The SQL statement.
        /// </value>
        ISqlStatement SqlStatement { get; }

        /// <summary>
        /// Gets or sets the connection factory.
        /// </summary>
        /// <value>
        /// The connection factory.
        /// </value>
        DbConnection Connection { get; }

        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        IList<int> Keys { get; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>
        /// IEnumerable{DataRow}
        /// </returns>
        IEnumerable<DataRow> GetData( );
    }
}