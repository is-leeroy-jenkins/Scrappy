// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 07-28-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        07-28-2024
// ******************************************************************************************
// <copyright file="DataConfig.cs" company="Terry D. Eppler">
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
//   DataConfig.cs
// </summary>
// ******************************************************************************************

namespace Scrappy
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc/>
    /// <summary> </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToAutoPropertyWhenPossible" ) ]
    [ SuppressMessage( "ReSharper", "ClassNeverInstantiated.Global" ) ]
    public class DataConfig : ISource, IProvider
    {
        /// <summary>
        /// 
        /// </summary>
        private Source _source;

        /// <summary>
        /// 
        /// </summary>
        private Provider _provider;

        /// <inheritdoc/>
        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        /// <value> The provider. </value>
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

        /// <inheritdoc/>
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value> The source.
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

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataConfig"/>
        /// class.
        /// </summary>
        public DataConfig( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DataConfig"/>
        /// class.
        /// </summary>
        /// <param name="source"> The source. </param>
        /// <param name="provider"> The provider. </param>
        public DataConfig( Source source, Provider provider )
        {
            _source = source;
            _provider = provider;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataConfig"/> class.
        /// </summary>
        /// <param name="_dataConfig">The data arguments.</param>
        public DataConfig( DataConfig _dataConfig )
        {
            _source = _dataConfig.Source;
            _provider = _dataConfig.Provider;
        }

        /// <summary>
        /// Deconstructs the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        public void Deconstruct( out Source source, out Provider provider )
        {
            source = _source;
            provider = _provider;
        }

        /// <summary> Converts to string. </summary>
        /// <returns>
        /// A
        /// <see cref="System.String"/>
        /// that represents this instance.
        /// </returns>
        public override string ToString( )
        {
            try
            {
                return $"{_provider}";
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected void Fail( Exception ex )
        {
            var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}