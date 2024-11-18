// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-28-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-28-2024
// ******************************************************************************************
// <copyright file="SqlServerQuery.cs" company="Terry D. Eppler">
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
//   SqlServerQuery.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary> </summary>
    /// <seealso cref="T:Badger.Query" />
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class SqlServerQuery : BudgetQuery
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.SqlServerQuery" />
        /// class.
        /// </summary>
        public SqlServerQuery( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.SqlServerQuery" />
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        public SqlServerQuery( Source source )
            : base( source, Provider.SqlServer )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.SqlServerQuery" />
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="dict"> The dictionary. </param>
        public SqlServerQuery( Source source, IDictionary<string, object> dict )
            : base( source, Provider.SqlServer, dict, Command.SELECT )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.SqlServerQuery" />
        /// class.
        /// </summary>
        /// <param name="source"> The source Data. </param>
        /// <param name="dict"> The dictionary of parameters. </param>
        /// <param name="commandType"> The type of sql command. </param>
        public SqlServerQuery( Source source, IDictionary<string, object> dict,
            Command commandType )
            : base( source, Provider.SqlServer, dict, commandType )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.SqlServerQuery" />
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="updates"> </param>
        /// <param name="where"> The where. </param>
        /// <param name="commandType"> Type of the command. </param>
        public SqlServerQuery( Source source, IDictionary<string, object> updates,
            IDictionary<string, object> where, Command commandType = Command.UPDATE )
            : base( source, Provider.SqlServer, updates, where, commandType )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.SqlServerQuery" />
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="columns"> The columns. </param>
        /// <param name="criteria"> The criteria. </param>
        /// <param name="commandType"> Type of the command. </param>
        public SqlServerQuery( Source source, IEnumerable<string> columns,
            IDictionary<string, object> criteria, Command commandType = Command.SELECT )
            : base( source, Provider.SqlServer, columns, criteria, commandType )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.SqlServerQuery" />
        /// class.
        /// </summary>
        /// <param name="sqlStatement"> The sqlStatement. </param>
        public SqlServerQuery( ISqlStatement sqlStatement )
            : base( sqlStatement )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.SqlServerQuery" />
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="sqlText"> The SQL text. </param>
        public SqlServerQuery( Source source, string sqlText )
            : base( source, Provider.SqlServer, sqlText )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.SqlServerQuery" />
        /// class.
        /// </summary>
        /// <param name="fullPath"> The fullpath. </param>
        /// <param name="sqlText"> </param>
        /// <param name="commandType"> The commandType. </param>
        public SqlServerQuery( string fullPath, string sqlText,
            Command commandType = Command.SELECT )
            : base( fullPath, sqlText, commandType )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.SqlServerQuery" />
        /// class.
        /// </summary>
        /// <param name="fullPath"> The full path. </param>
        /// <param name="commandType"> The commandType. </param>
        /// <param name="dict"> The dictionary. </param>
        public SqlServerQuery( string fullPath, Command commandType,
            IDictionary<string, object> dict )
            : base( fullPath, commandType, dict )
        {
        }
    }
}