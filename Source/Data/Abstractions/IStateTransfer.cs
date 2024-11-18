// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="IStateTransfer.cs" company="Terry D. Eppler">
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
//   IStateTransfer.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Scrappy.ISource" />
    /// <seealso cref="T:Scrappy.IProvider" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public interface IStateTransfer : ISource, IProvider
    {
        /// <summary>
        /// Gets the selected table.
        /// </summary>
        /// <value>
        /// The selected table.
        /// </value>
        string SelectedTable { get; }

        /// <summary>
        /// Gets the selected fields.
        /// </summary>
        /// <value>
        /// The selected fields.
        /// </value>
        IList<string> SelectedFields { get; }

        /// <summary>
        /// Gets the selected numerics.
        /// </summary>
        /// <value>
        /// The selected numerics.
        /// </value>
        IList<string> SelectedNumerics { get; }

        /// <summary>
        /// Gets the selected dates.
        /// </summary>
        /// <value>
        /// The selected dates.
        /// </value>
        IList<DateTime> SelectedDates { get; }

        /// <summary>
        /// Gets the SQL query.
        /// </summary>
        /// <value>
        /// The SQL query.
        /// </value>
        string SqlQuery { get; }

        /// <summary>
        /// Gets the data filter.
        /// </summary>
        /// <value>
        /// The data filter.
        /// </value>
        IDictionary<string, object> Filter { get; }
    }
}