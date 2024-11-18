// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="IDataUnit.cs" company="Terry D. Eppler">
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
//   IDataUnit.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Scrappy.ISource" />
    /// <seealso cref="T:Scrappy.IProvider" />
    public interface IDataUnit : ISource, IProvider
    {
        /// <summary>
        /// </summary>
        /// <inheritdoc />
        int ID { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the field.
        /// </summary>
        string Code { get; }

        /// <inheritdoc />
        /// <summary>
        /// The name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        object Value { get; }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        DataRow Record { get; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        IDictionary<string, object> Map { get; }

        /// <inheritdoc />
        /// <summary>
        /// Determines whether the specified element is match.
        /// </summary>
        /// <param name="unit">The element.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified element is match; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        bool IsMatch( IDataUnit unit );

        /// <inheritdoc />
        /// <summary>
        /// Determines whether the specified dictionary is match.
        /// </summary>
        /// <param name="dict">The dictionary.</param>
        /// <returns>
        /// <c> true </c>
        /// if the specified dictionary is match; otherwise,
        /// <c> false </c>
        /// .
        /// </returns>
        bool IsMatch( IDictionary<string, object> dict );

        /// <summary>
        /// Determines whether the specified primary is match.
        /// </summary>
        /// <param name="primary">The primary.</param>
        /// <param name="secondary">The secondary.</param>
        /// <returns>
        ///   <c>true</c> if the specified primary is match;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool IsMatch( IDataUnit primary, IDataUnit secondary );

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <returns>
        /// Integer
        /// </returns>
        int GetId( );

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <returns>
        /// Integer
        /// </returns>
        int GetId( DataRow dataRow );
    }
}