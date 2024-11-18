// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 08-25-2020
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        08-25-2024
// ******************************************************************************************
// <copyright file="Query.cs" company="Terry D. Eppler">
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
//   Query.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc/>
    /// <summary>
    /// </summary>
    /// <seealso cref="T:System.IDisposable"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ValueParameterNotUsed" ) ]
    [ SuppressMessage( "ReSharper", "UnassignedGetOnlyAutoProperty" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    public abstract class Query : QueryBase, IQuery
    {
        /// <inheritdoc />
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
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
        /// Gets the Provider
        /// </summary>
        /// <value>
        /// The provider.
        /// </value>
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
        /// Gets or sets the type of the command.
        /// </summary>
        /// <value>
        /// The type of the command.
        /// </value>
        public Command CommandType
        {
            get
            {
                return _commandType;
            }
            private protected set
            {
                _commandType = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
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
        /// Gets the SQL statement.
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
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public DbConnection DataConnection
        {
            get
            {
                return _dataConnection;
            }
            private protected set
            {
                _dataConnection = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the adapter.
        /// </summary>
        /// <value>
        /// The adapter.
        /// </value>
        public DbDataAdapter DataAdapter
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

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is disposed;
        /// otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed
        {
            get
            {
                return _isDisposed;
            }
            private protected set
            {
                _isDisposed = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the data reader.
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
    }
}