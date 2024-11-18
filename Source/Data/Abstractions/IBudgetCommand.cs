// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="IBudgetCommand.cs" company="Terry D. Eppler">
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
//   IBudgetCommand.cs
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
    public interface IBudgetCommand : ISource, IProvider
    {
        /// <inheritdoc/>
        /// <summary>
        /// Sets the command.
        /// </summary>
        /// <returns> </returns>
        DbCommand Create( );

        /// <inheritdoc />
        /// <summary>
        /// Creates the command asynchronously.
        /// </summary>
        /// <returns>
        /// Task( DbCommand )
        /// </returns>
        Task<DbCommand> CreateAsync( );

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>
        /// command.
        /// </value>
        DbCommand Command { get; }

        /// <summary>
        /// Gets or sets the connection factory.
        /// </summary>
        /// <value>
        /// The connection factory.
        /// </value>
        DbConnection Connection { get; }

        /// <summary>
        /// Gets or sets the type of the command.
        /// </summary>
        /// <value>
        /// The type of the command.
        /// </value>
        Command CommandType { get; }

        /// <summary>
        /// Gets or sets the SQL statement.
        /// </summary>
        /// <value>
        /// The SQL statement.
        /// </value>
        ISqlStatement SqlStatement { get; }
    }
}