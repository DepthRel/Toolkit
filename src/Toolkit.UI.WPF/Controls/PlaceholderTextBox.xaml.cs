using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Toolkit.Contracts;

namespace Toolkit.UI.WPF.Controls
{
    public partial class PlaceholderTextBox : UserControl
    {
        #region Dependency properties

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(PlaceholderTextBox), new PropertyMetadata(default));

        public static readonly DependencyProperty CaretBrushProperty =
            DependencyProperty.Register("CaretBrush", typeof(Brush), typeof(PlaceholderTextBox), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty ClearButtonForegroundProperty =
            DependencyProperty.Register("ClearButtonForeground", typeof(Brush), typeof(PlaceholderTextBox), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(PlaceholderTextBox), new PropertyMetadata(false));

        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register("PlaceholderText", typeof(string), typeof(PlaceholderTextBox), new PropertyMetadata(string.Empty));

        public static new readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(Brush), typeof(PlaceholderTextBox), new PropertyMetadata(Brushes.Black));

        public static new readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(PlaceholderTextBox), new PropertyMetadata(Brushes.White));

        public static new readonly DependencyProperty PaddingProperty =
            DependencyProperty.Register("Padding", typeof(Thickness), typeof(PlaceholderTextBox), new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty MaxLengthProperty =
            DependencyProperty.Register("MaxLength", typeof(int), typeof(PlaceholderTextBox), new PropertyMetadata(0));

        public static readonly DependencyProperty SpellCheckEnableProperty =
            DependencyProperty.Register("SpellCheckEnable", typeof(bool), typeof(PlaceholderTextBox), new PropertyMetadata(false));

        public static readonly DependencyProperty AcceptsReturnProperty =
            DependencyProperty.Register("AcceptsReturn", typeof(bool), typeof(PlaceholderTextBox), new PropertyMetadata(false));

        public static readonly DependencyProperty ClearButtonEnableProperty =
            DependencyProperty.Register("ClearButtonEnable", typeof(bool), typeof(PlaceholderTextBox), new PropertyMetadata(true));

        public static readonly DependencyProperty ClearButtonVisibilityProperty =
            DependencyProperty.Register("ClearButtonVisibility", typeof(Visibility), typeof(PlaceholderTextBox), new PropertyMetadata(Visibility.Visible));

        #endregion

        #region Properties

        public string Text
        {
            get
            {
                if (IsPlaceholderActivated)
                {
                    return string.Empty;
                }

                return (string)GetValue(TextProperty);
            }

            set => SetValue(TextProperty, value);
        }

        public Brush CaretBrush
        {
            get => (Brush)GetValue(CaretBrushProperty);
            set => SetValue(CaretBrushProperty, value);
        }

        public Brush ClearButtonForeground
        {
            get => (Brush)GetValue(ClearButtonForegroundProperty);
            set => SetValue(ClearButtonForegroundProperty, value);
        }

        public bool IsReadOnly
        {
            get => (bool)GetValue(IsReadOnlyProperty);
            set => SetValue(IsReadOnlyProperty, value);
        }

        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set => SetValue(PlaceholderTextProperty, value);
        }

        public new Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        public new Brush Background
        {
            get => (Brush)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        public new Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        public bool SpellCheckEnable
        {
            get => (bool)GetValue(SpellCheckEnableProperty);
            set => SetValue(SpellCheckEnableProperty, value);
        }

        public bool AcceptsReturn
        {
            get => (bool)GetValue(AcceptsReturnProperty);
            set => SetValue(AcceptsReturnProperty, value);
        }

        public bool ClearButtonEnable
        {
            get => (bool)GetValue(ClearButtonEnableProperty);
            set => SetValue(ClearButtonEnableProperty, value);
        }

        public Visibility ClearButtonVisibility
        {
            get => (Visibility)GetValue(ClearButtonVisibilityProperty);
            set => SetValue(ClearButtonVisibilityProperty, value);
        }

        private Brush oldForeground;
        private bool oldSpellCheckValue;

        private bool isPlaceholderActivated;

        private bool IsPlaceholderActivated
        {
            get => isPlaceholderActivated;
            set
            {
                isPlaceholderActivated = value;
                if (isPlaceholderActivated)
                {
                    TextBoxControl.Text = PlaceholderText;

                    oldForeground = TextBoxControl.Foreground;
                    TextBoxControl.Foreground = Brushes.Gray;

                    oldSpellCheckValue = SpellCheckEnable;
                    SpellCheckEnable = false;
                }
                else
                {
                    TextBoxControl.Foreground = oldForeground;
                    SpellCheckEnable = oldSpellCheckValue;
                    TextBoxControl.Text = string.Empty;
                }
            }
        }

        #endregion

        public PlaceholderTextBox()
        {
            InitializeComponent();
        }

        private void ClearText(object sender, RoutedEventArgs e)
        {
            if (!IsPlaceholderActivated)
            {
                TextBoxControl.Text = string.Empty;
                IsPlaceholderActivated = true;
            }
        }

        private void ControlGotFocus(object sender, RoutedEventArgs e)
        {
            if (IsPlaceholderActivated)
            {
                IsPlaceholderActivated = false;
            }
        }

        private void ControlLostFocus(object sender, RoutedEventArgs e)
        {
            if (!Check.StringNotNullOrWhiteSpace(TextBoxControl.Text))
            {
                IsPlaceholderActivated = true;
            }
        }

        private void TextBoxLoaded(object sender, RoutedEventArgs e)
        {
            if (!Check.StringNotNullOrWhiteSpace(TextBoxControl.Text))
            {
                IsPlaceholderActivated = true;
            }
        }
    }
}