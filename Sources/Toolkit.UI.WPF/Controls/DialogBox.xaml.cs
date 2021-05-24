using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Toolkit.UI.WPF.Controls
{
    public partial class DialogBox : Window
    {
        #region Dependency properties

        #region Header

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(DialogBox), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty HeaderForegroundProperty =
            DependencyProperty.Register("HeaderForeground", typeof(Brush), typeof(DialogBox), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty HeaderVerticalAlignmentProperty =
            DependencyProperty.Register("HeaderVerticalAlignment", typeof(VerticalAlignment), typeof(DialogBox), new PropertyMetadata(VerticalAlignment.Center));

        public static readonly DependencyProperty HeaderHorizontalAlignmentProperty =
            DependencyProperty.Register("HeaderHorizontalAlignment", typeof(HorizontalAlignment), typeof(DialogBox), new PropertyMetadata(HorizontalAlignment.Left));

        public static readonly DependencyProperty HeaderMarginProperty =
            DependencyProperty.Register("HeaderMargin", typeof(Thickness), typeof(DialogBox), new PropertyMetadata(new Thickness(0)));

        #endregion

        #region Content

        public static new readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(DialogBox), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ContentForegroundProperty =
            DependencyProperty.Register("ContentForeground", typeof(Brush), typeof(DialogBox), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty ContentVerticalAlignmentProperty =
            DependencyProperty.Register("ContentVerticalAlignment", typeof(VerticalAlignment), typeof(DialogBox), new PropertyMetadata(VerticalAlignment.Top));

        public static readonly DependencyProperty ContentHorizontalAlignmentProperty =
            DependencyProperty.Register("ContentHorizontalAlignment", typeof(HorizontalAlignment), typeof(DialogBox), new PropertyMetadata(HorizontalAlignment.Left));

        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register("ContentMargin", typeof(Thickness), typeof(DialogBox), new PropertyMetadata(new Thickness(0)));

        #endregion

        #region Buttons

        public static readonly DependencyProperty ButtonsForegroundProperty =
            DependencyProperty.Register("ButtonsForeground", typeof(SolidColorBrush), typeof(DialogBox), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty ButtonsBackgroundProperty =
            DependencyProperty.Register("ButtonsBackground", typeof(SolidColorBrush), typeof(DialogBox), new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty ButtonsConfigurationProperty =
           DependencyProperty.Register("ButtonsConfiguration", typeof(DialogBoxButtons), typeof(DialogBox), new PropertyMetadata(DialogBoxButtons.PrimaryAndClose));

        public static readonly DependencyProperty PrimaryButtonContentProperty =
            DependencyProperty.Register("PrimaryButtonContent", typeof(object), typeof(DialogBox), new PropertyMetadata("Apply"));

        public static readonly DependencyProperty SecondaryButtonContentProperty =
            DependencyProperty.Register("SecondaryButtonContent", typeof(object), typeof(DialogBox), new PropertyMetadata("Secondary"));

        public static readonly DependencyProperty CloseButtonContentProperty =
            DependencyProperty.Register("CloseButtonContent", typeof(object), typeof(DialogBox), new PropertyMetadata("Close"));

        public static readonly DependencyProperty ButtonsHeightProperty =
            DependencyProperty.Register("ButtonsHeight", typeof(int), typeof(DialogBox), new PropertyMetadata(40));

        public static readonly DependencyProperty ButtonsWidthProperty =
            DependencyProperty.Register("ButtonsWidth", typeof(int), typeof(DialogBox), new PropertyMetadata(120));

        public static readonly DependencyProperty ButtonsMarginProperty =
            DependencyProperty.Register("ButtonsMargin", typeof(Thickness), typeof(DialogBox), new PropertyMetadata(new Thickness(0, 0, 10, 0)));

        public static readonly DependencyProperty ButtonsFontSizeProperty =
            DependencyProperty.Register("ButtonsFontSize", typeof(int), typeof(DialogBox), new PropertyMetadata(12));

        public static readonly DependencyProperty ButtonsFontFamilyProperty =
            DependencyProperty.Register("ButtonsFontFamily", typeof(FontFamily), typeof(DialogBox), new PropertyMetadata(new FontFamily("Segoe UI")));

        #endregion

        public static new readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.Register("BorderBrush", typeof(Color), typeof(DialogBox), new PropertyMetadata(new Color() { A = 0, R = 0, G = 0, B = 0 }));

        public static new readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(DialogBox), new PropertyMetadata(Brushes.White));

        #endregion

        #region Properties

        #region Header

        public object Header
        {
            get => GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public Brush HeaderForeground
        {
            get => (Brush)GetValue(HeaderForegroundProperty);
            set => SetValue(HeaderForegroundProperty, value);
        }

        public VerticalAlignment HeaderVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(HeaderVerticalAlignmentProperty);
            set => SetValue(HeaderVerticalAlignmentProperty, value);
        }

        public HorizontalAlignment HeaderHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(HeaderHorizontalAlignmentProperty);
            set => SetValue(HeaderHorizontalAlignmentProperty, value);
        }

        public Thickness HeaderMargin
        {
            get => (Thickness)GetValue(HeaderMarginProperty);
            set => SetValue(HeaderMarginProperty, value);
        }

        #endregion

        #region Content

        public new object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public Brush ContentForeground
        {
            get => (Brush)GetValue(ContentForegroundProperty);
            set => SetValue(ContentForegroundProperty, value);
        }

        public VerticalAlignment ContentVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(ContentVerticalAlignmentProperty);
            set => SetValue(ContentVerticalAlignmentProperty, value);
        }

        public HorizontalAlignment ContentHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(ContentHorizontalAlignmentProperty);
            set => SetValue(ContentHorizontalAlignmentProperty, value);
        }

        public Thickness ContentMargin
        {
            get => (Thickness)GetValue(ContentMarginProperty);
            set => SetValue(ContentMarginProperty, value);
        }

        #endregion

        #region Buttons

        public DialogBoxButtons ButtonsConfiguration
        {
            get => (DialogBoxButtons)GetValue(ButtonsConfigurationProperty);
            set => SetValue(ButtonsConfigurationProperty, value);
        }

        public SolidColorBrush ButtonsForeground
        {
            get => (SolidColorBrush)GetValue(ButtonsForegroundProperty);
            set => SetValue(ButtonsForegroundProperty, value);
        }

        public SolidColorBrush ButtonsBackground
        {
            get => (SolidColorBrush)GetValue(ButtonsBackgroundProperty);
            set => SetValue(ButtonsBackgroundProperty, value);
        }

        public object PrimaryButtonContent
        {
            get => GetValue(PrimaryButtonContentProperty);
            set => SetValue(PrimaryButtonContentProperty, value);
        }

        public object SecondaryButtonContent
        {
            get => GetValue(SecondaryButtonContentProperty);
            set => SetValue(SecondaryButtonContentProperty, value);
        }

        public object CloseButtonContent
        {
            get => GetValue(CloseButtonContentProperty);
            set => SetValue(CloseButtonContentProperty, value);
        }

        public int ButtonsHeight
        {
            get => (int)GetValue(ButtonsHeightProperty);
            set => SetValue(ButtonsHeightProperty, value);
        }

        public int ButtonsWidth
        {
            get => (int)GetValue(ButtonsWidthProperty);
            set => SetValue(ButtonsWidthProperty, value);
        }

        public Thickness ButtonsMargin
        {
            get => (Thickness)GetValue(ButtonsMarginProperty);
            set => SetValue(ButtonsMarginProperty, value);
        }

        public int ButtonsFontSize
        {
            get => (int)GetValue(ButtonsFontSizeProperty);
            set => SetValue(ButtonsFontSizeProperty, value);
        }

        public FontFamily ButtonsFontFamily
        {
            get => (FontFamily)GetValue(ButtonsFontFamilyProperty);
            set => SetValue(ButtonsFontFamilyProperty, value);
        }

        #endregion

        public new Color BorderBrush
        {
            get => (Color)GetValue(BorderBrushProperty);
            set => SetValue(BorderBrushProperty, value);
        }

        public new Brush Background
        {
            get => (Brush)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        #endregion

        #region Fields

        private DialogBoxButtons DialogBoxButtonsPreviewResult;

        #endregion

        public DialogBox()
        {
            InitializeComponent();

            // Default value if will be pressed Esc button on keyboard
            DialogBoxButtonsPreviewResult = DialogBoxButtons.Close;

            // Blocking Alt+Tab for make owner windows unavailable
            this.Owner = Application.Current.MainWindow;
        }

        /// <summary>
        /// Show dialog box and wait for result
        /// </summary>
        /// <returns><strong>Selected button available in <seealso cref="DialogBoxResult"/></strong></returns>
        public new DialogBoxResult ShowDialog()
        {
            base.ShowDialog();

            var types = Enum.GetValues(typeof(DialogBoxButtons));

            foreach (DialogBoxButtons item in types)
            {
                if ((DialogBoxButtonsPreviewResult & item) == item)
                {
                    switch (item)
                    {
                        case DialogBoxButtons.Primary:
                            return DialogBoxResult.Primary;

                        case DialogBoxButtons.Secondary:
                            return DialogBoxResult.Secondary;

                        default:
                            return DialogBoxResult.Close;
                    }
                }
            }

            return DialogBoxResult.Close;
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if ((string)button.Tag == "Primary")
                {
                    DialogBoxButtonsPreviewResult = DialogBoxButtons.Primary;
                }

                if ((string)button.Tag == "Secondary")
                {
                    DialogBoxButtonsPreviewResult = DialogBoxButtons.Secondary;
                }

                Close();
            }
        }

        private void WindowDragAndDrop(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        /// <summary>
        /// Need for dialog.Show() because IsCancel doesn't work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DialogClose(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}