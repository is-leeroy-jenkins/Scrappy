// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="IBudgetConnection.cs" company="Terry D. Eppler">
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
//   IBudgetConnection.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Data.Common;
    using System.Threading.Tasks;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    public interface IBudgetConnection : ISource, IProvider
    {
        /// <inheritdoc />
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        DbConnection Create( );

        /// <inheritdoc />
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        Task<DbConnection> CreateAsync( );

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        DbConnection Connection { get; }

        /// <summary>
        /// Gets or sets the client path.
        /// </summary>
        /// <value>
        /// The client path.
        /// </value>
        string DataPath { get; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>
        /// The extension.
        /// </value>
        EXT Extension { get; }

        /// <summary>
        /// Gets or sets the path extension.
        /// </summary>
        /// <value>
        /// The path extension.
        /// </value>
        string PathExtension { get; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        string FilePath { get; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        string FileName { get; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        string TableName { get; }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        string ConnectionString { get; }
    }
}