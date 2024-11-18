// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="AsyncGenerator.cs" company="Terry D. Eppler">
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
//   AsyncGenerator.cs
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
    /// <seealso cref="T:Badger.AsyncModel" />
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public class AsyncGenerator : AsyncService, IAsyncService
    {
        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.AsyncGenerator"/>
        /// class.
        /// </summary>
        public AsyncGenerator( )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.AsyncGenerator"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        public AsyncGenerator( Source source, Provider provider = Provider.Access )
            : base( source, provider )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.AsyncGenerator"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="where"> The where. </param>
        public AsyncGenerator( Source source, Provider provider, IDictionary<string, object> where )
            : base( source, provider, where )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.AsyncGenerator"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="dict"> </param>
        public AsyncGenerator( Source source, IDictionary<string, object> dict )
            : base( source, dict )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.AsyncGenerator"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="updates"> The updates. </param>
        /// <param name="where"> The where. </param>
        /// <param name="commandType"> Type of the command. </param>
        public AsyncGenerator( Source source, Provider provider,
            IDictionary<string, object> updates, IDictionary<string, object> where,
            Command commandType = Command.UPDATE )
            : base( source, provider, updates, where,
                commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.AsyncGenerator"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="columns"> The columns. </param>
        /// <param name="where"> The where. </param>
        /// <param name="commandType"> Type of the command. </param>
        public AsyncGenerator( Source source, Provider provider, IEnumerable<string> columns,
            IDictionary<string, object> where, Command commandType = Command.SELECT )
            : base( source, provider, columns, where,
                commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.AsyncGenerator"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="fields"> The fields. </param>
        /// <param name="numerics"> The numerics. </param>
        /// <param name="where"> The where. </param>
        /// <param name="commandType"> Type of the command. </param>
        public AsyncGenerator( Source source, Provider provider, IEnumerable<string> fields,
            IEnumerable<string> numerics, IDictionary<string, object> where, Command commandType )
            : base( source, provider, fields, numerics,
                where, commandType )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.AsyncGenerator"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        /// <param name="sqlText"> The SQL text. </param>
        public AsyncGenerator( Source source, Provider provider, string sqlText )
            : base( source, provider, sqlText )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.AsyncGenerator"/>
        /// class.
        /// </summary>
        /// <param name="query"> The query. </param>
        public AsyncGenerator( IQuery query )
            : base( query )
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.AsyncGenerator"/>
        /// class.
        /// </summary>
        /// <param name="fullPath"> The full path. </param>
        /// <param name="sqlText"> The SQL text. </param>
        /// <param name="commandType"> Type of the command. </param>
        public AsyncGenerator( string fullPath, string sqlText,
            Command commandType = Command.SELECT )
            : base( fullPath, sqlText, commandType )
        {
        }
    }
}