namespace Scrappy
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Media;
    using Syncfusion.Windows.Controls.Input;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Syncfusion.Windows.Controls.Input.SfTextBoxExt" />
    [SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Local" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class MetroTextBox : SfTextBoxExt
    {
        /// <summary>
        /// The theme
        /// </summary>
        private protected readonly DarkMode _theme = new DarkMode( );

        /// <summary>
        /// The input text
        /// </summary>
        private protected string _inputText;

        /// <summary>
        /// The temporary text
        /// </summary>
        private protected string _tempText;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Scrappy.MetroTextBox" /> class.
        /// </summary>
        public MetroTextBox( )
            : base( )
        {
            SetResourceReference( StyleProperty, typeof( SfTextBoxExt ) );
            Width = 100;
            Height = 24;
            FontFamily = _theme.FontFamily;
            FontSize = _theme.FontSize;
            Padding = new Thickness( 1 );
            Background = _theme.ControlBackground;
            Foreground = _theme.LightBlueBrush;
            BorderBrush = _theme.BorderBrush;
            SelectionBrush = _theme.SteelBlueBrush;
            _inputText = "";
            _tempText = "";

            // Event Wiring
            MouseEnter += OnMouseEnter;
            MouseLeave += OnMouseLeave;
            TextChanged += OnTextChanged;
            LostFocus += OnFocusLost;
        }

        /// <summary>
        /// Gets or sets the input text.
        /// </summary>
        /// <value>
        /// The input text.
        /// </value>
        public string InputText
        {
            get
            {
                return _inputText;
            }
            set
            {
                _inputText = value;
            }
        }

        /// <summary>
        /// Called when [mouse enter].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private protected void OnMouseEnter(object sender, RoutedEventArgs e )
        {
            try
            {
                Background = _theme.DarkBlueBrush;
                BorderBrush = _theme.LightBlueBrush;
                Foreground = _theme.WhiteForeground;
            }
            catch( Exception ex )
            {
                Fail(ex);
            }
        }

        /// <summary>
        /// Called when [mouse leave].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private protected void OnMouseLeave( object sender, RoutedEventArgs e )
        {
            try
            {
                Background = _theme.ControlInterior;
                BorderBrush = _theme.SteelBlueBrush;
                Foreground = _theme.LightBlueBrush;
            }
            catch(Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// Called when [un focused].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/>
        /// instance containing the event data.
        /// </param>
        private protected void OnTextChanged( object sender, RoutedEventArgs e )
        {
            try
            {
                if( !string.IsNullOrEmpty( Text ) 
                    && Text != "" )
                {
                    _tempText = Text;
                }
            }
            catch(Exception ex)
            {
                Fail(ex);
            }
        }

        /// <summary>
        /// Called when [focus lost].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs" />
        /// instance containing the event data.</param>
        private protected void OnFocusLost(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(_tempText) 
                    && _tempText != _inputText ) 
                {
                    _tempText = _inputText;
                }
            }
            catch(Exception ex)
            {
                Fail(ex);
            }
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="_ex">The ex.</param>
        private protected void Fail( Exception _ex )
        {
            var _error = new ErrorWindow( _ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}