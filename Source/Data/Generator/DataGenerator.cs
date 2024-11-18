// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-28-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-28-2024
// ******************************************************************************************
// <copyright file="DataGenerator.cs" company="Terry D. Eppler">
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
//   DataGenerator.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.DataModel" />
    /// <seealso cref="T:Badger.IDataService" />
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeAccessorOwnerBody" ) ]
    [ SuppressMessage( "ReSharper", "PropertyCanBeMadeInitOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "ConvertSwitchStatementToSwitchExpression" ) ]
    public class DataGenerator : DataService, IDataService
    {
        /// <inheritdoc />
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
                return _busy;
            }
            private protected set
            {
                _busy = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public TimeSpan Duration
        {
            get
            {
                return _duration;
            }

            private set
            {
                _duration = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the record.
        /// </summary>
        /// <value>
        /// The record.
        /// </value>
        public DataRow Record
        {
            get
            {
                return _record;
            }

            private set
            {
                _record = value;
            }
        }

        /// <summary>
        /// Gets the data set.
        /// </summary>
        /// <value>
        /// The data set.
        /// </value>
        public DataSet DataSet
        {
            get
            {
                return _dataSet;
            }

            private set
            {
                _dataSet = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the data elements.
        /// </summary>
        /// <value>
        /// The data elements.
        /// </value>
        public IDictionary<string, IEnumerable<string>> DataElements
        {
            get
            {
                return _elements;
            }

            private set
            {
                _elements = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.DataGenerator" /> class.
        /// </summary>
        public DataGenerator( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.DataGenerator" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        public DataGenerator( Source source, Provider provider = Provider.Access )
            : base( source, provider )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.DataGenerator" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="where">The where.</param>
        public DataGenerator( Source source, Provider provider, IDictionary<string, object> where )
            : base( source, provider, where )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.DataGenerator" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="dict">The dictionary.</param>
        public DataGenerator( Source source, IDictionary<string, object> dict )
            : base( source, dict )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.DataGenerator" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="updates">The updates.</param>
        /// <param name="where">The where.</param>
        /// <param name="commandType">Type of the command.</param>
        public DataGenerator( Source source, Provider provider, IDictionary<string, object> updates,
            IDictionary<string, object> where, Command commandType = Command.UPDATE )
            : base( source, provider, updates, where, commandType )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.DataGenerator" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="where">The where.</param>
        /// <param name="commandType">Type of the command.</param>
        public DataGenerator( Source source, Provider provider, IEnumerable<string> columns,
            IDictionary<string, object> where, Command commandType = Command.SELECT )
            : base( source, provider, columns, where, commandType )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.DataGenerator" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="fields">The fields.</param>
        /// <param name="numerics">The numerics.</param>
        /// <param name="where">The where.</param>
        /// <param name="commandType">Type of the command.</param>
        public DataGenerator( Source source, Provider provider, IEnumerable<string> fields,
            IEnumerable<string> numerics, IDictionary<string, object> where, Command commandType )
            : base( source, provider, fields, numerics, where,
                commandType )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.DataGenerator" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="sqlText">The SQL text.</param>
        public DataGenerator( Source source, Provider provider, string sqlText )
            : base( source, provider, sqlText )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.DataGenerator" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public DataGenerator( IQuery query )
            : base( query )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.DataGenerator" /> class.
        /// </summary>
        /// <param name="fullPath">The full path.</param>
        /// <param name="sqlText">The SQL text.</param>
        /// <param name="commandType">Type of the command.</param>
        public DataGenerator( string fullPath, string sqlText,
            Command commandType = Command.SELECT )
            : base( fullPath, sqlText, commandType )
        {
        }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        public static Provider GetProvider( string provider )
        {
            try
            {
                ThrowIf.Null( provider, nameof( provider ) );
                if( Enum.IsDefined( typeof( Provider ), provider ) )
                {
                    return (Provider)Enum.Parse( typeof( Provider ), provider );
                }
                else if( Path.HasExtension( provider ) )
                {
                    var _path = Path.GetExtension( provider );
                    var _ext = (EXT)Enum.Parse( typeof( EXT ), _path );
                    switch( _ext )
                    {
                        case EXT.MDB:
                        case EXT.XLS:
                        case EXT.XLSX:
                        case EXT.CSV:
                        case EXT.ACCDB:
                        {
                            return Provider.Access;
                        }
                        case EXT.SDF:
                        {
                            return Provider.SqlCe;
                        }
                        case EXT.MDF:
                        {
                            return Provider.SqlServer;
                        }
                        case EXT.DB:
                        {
                            return Provider.SQLite;
                        }
                        default:
                        {
                            return Provider.Access;
                        }
                    }
                }
                else
                {
                    return Provider.Access;
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Provider );
            }
        }

        /// <summary>
        /// Gets the provider.
        /// </summary>
        /// <param name="ext">The provider</param>
        /// <returns></returns>
        public static Provider GetProvider( EXT ext )
        {
            try
            {
                switch( ext )
                {
                    case EXT.MDB:
                    case EXT.XLS:
                    case EXT.XLSX:
                    case EXT.CSV:
                    case EXT.ACCDB:
                    {
                        return Provider.Access;
                    }
                    case EXT.SDF:
                    {
                        return Provider.SqlCe;
                    }
                    case EXT.MDF:
                    {
                        return Provider.SqlServer;
                    }
                    case EXT.DB:
                    {
                        return Provider.SQLite;
                    }
                    default:
                    {
                        return Provider.Access;
                    }
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Provider );
            }
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <param name="tableName">
        /// Name of the table.
        /// </param>
        /// <returns>
        /// Source
        /// </returns>
        public static Source GetSource( string tableName )
        {
            try
            {
                ThrowIf.Null( tableName, nameof( tableName ) );
                var _names = Enum.GetNames( typeof( Source ) );
                foreach( var _name in _names )
                {
                    if( _name.Equals( tableName ) )
                    {
                        return (Source)Enum.Parse( typeof( Source ), tableName );
                    }
                }

                return default( Source );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Source );
            }
        }
    }
}