using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Toolkit.Contracts;

namespace Toolkit.UI.WPF.Controls
{
    public partial class NumberBox : UserControl
    {
        #region Dependency properties

        public static readonly DependencyProperty CaretBrushProperty =
            DependencyProperty.Register("CaretBrush", typeof(Brush), typeof(NumberBox), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty ClearButtonForegroundProperty =
            DependencyProperty.Register("ClearButtonForeground", typeof(Brush), typeof(NumberBox), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(NumberBox), new PropertyMetadata(false));

        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register("PlaceholderText", typeof(string), typeof(NumberBox), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(Brush), typeof(NumberBox), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.Register("Background", typeof(Brush), typeof(NumberBox), new PropertyMetadata(Brushes.White));

        public static readonly DependencyProperty PaddingProperty =
            DependencyProperty.Register("Padding", typeof(Thickness), typeof(NumberBox), new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty MaxLengthProperty =
            DependencyProperty.Register("MaxLength", typeof(int), typeof(NumberBox), new PropertyMetadata(0));

        public static readonly DependencyProperty ClearButtonEnableProperty =
            DependencyProperty.Register("ClearButtonEnable", typeof(bool), typeof(NumberBox), new PropertyMetadata(true));

        public static readonly DependencyProperty ClearButtonVisibilityProperty =
            DependencyProperty.Register("ClearButtonVisibility", typeof(Visibility), typeof(NumberBox), new PropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int?), typeof(NumberBox), new PropertyMetadata(0));

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(int), typeof(NumberBox), new PropertyMetadata(int.MaxValue));

        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(int), typeof(NumberBox), new PropertyMetadata(int.MinValue));

        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register("Step", typeof(int), typeof(NumberBox), new PropertyMetadata(0));

        public static readonly DependencyProperty StepUpProperty =
            DependencyProperty.Register("StepUp", typeof(int), typeof(NumberBox), new PropertyMetadata(0));

        public static readonly DependencyProperty StepDownProperty =
            DependencyProperty.Register("StepDown", typeof(int), typeof(NumberBox), new PropertyMetadata(0));

        public static readonly DependencyProperty StepButtonsForegroundProperty =
            DependencyProperty.Register("StepButtonsForeground", typeof(Brush), typeof(NumberBox), new PropertyMetadata(Brushes.Black));

        public static readonly DependencyProperty StepButtonsEnableProperty =
            DependencyProperty.Register("StepButtonsEnable", typeof(bool), typeof(NumberBox), new PropertyMetadata(true));

        public static readonly DependencyProperty StepButtonsVisibilityProperty =
            DependencyProperty.Register("StepButtonsVisibility", typeof(Visibility), typeof(NumberBox), new PropertyMetadata(Visibility.Visible));

        #endregion

        #region Properties

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

        public Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        public Brush Background
        {
            get => (Brush)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
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

        public int? Value
        {
            get => (int?)GetValue(ValueProperty);
            set
            {
                CheckMinimumLessThanMaximum();
                if (value <= MaxValue && value >= MinValue)
                {
                    SetValue(ValueProperty, value);
                }
                else
                {
                    ResetValueToDefault();
                }
            }
        }

        public Range<int> NumbersRange { get; private set; }

        public int MaxValue
        {
            get => (int)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public int MinValue
        {
            get => (int)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        public int Step
        {
            get => (int)GetValue(StepProperty);
            set => SetValue(StepProperty, value);
        }

        public int StepUp
        {
            get => (int)GetValue(StepUpProperty);
            set => SetValue(StepUpProperty, value);
        }

        public int StepDown
        {
            get { return (int)GetValue(StepDownProperty); }
            set { SetValue(StepDownProperty, value); }
        }

        public Brush StepButtonsForeground
        {
            get => (Brush)GetValue(StepButtonsForegroundProperty);
            set => SetValue(StepButtonsForegroundProperty, value);
        }

        public bool StepButtonsEnable
        {
            get => (bool)GetValue(StepButtonsEnableProperty);
            set => SetValue(StepButtonsEnableProperty, value);
        }

        public Visibility StepButtonsVisibility
        {
            get => (Visibility)GetValue(StepButtonsVisibilityProperty);
            set => SetValue(StepButtonsVisibilityProperty, value);
        }

        private Brush oldForeground;

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
                }
                else
                {
                    TextBoxControl.Foreground = oldForeground;
                    TextBoxControl.Text = string.Empty;
                }
            }
        }

        #endregion

        public NumberBox()
        {
            InitializeComponent();
        }

        private void ResetValueToDefault()
        {
            if (IsPlaceholderActivated)
            {
                IsPlaceholderActivated = false;
            }

            CheckMinimumLessThanMaximum();

            if (Value > MaxValue)
            {
                Value = MaxValue;
            }
            else if (Value < MinValue)
            {
                Value = MinValue;
            }
            else
            {
                int zero = 0;
                if (zero >= MinValue && zero <= MaxValue)
                {
                    Value = zero;
                }
                else
                {
                    Value = MinValue;
                }
            }

            TextBoxControl.Text = Value.ToString();
        }

        private void ClearText(object sender, RoutedEventArgs e)
        {
            ResetValueToDefault();
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
            if (NumbersRange == null)
            {
                CheckMinimumLessThanMaximum();
            }

            if (IsPlaceholderActivated || !NumbersRange.Inside(Value.Value))
            {
                ResetValueToDefault();
            }

        }

        private void TextBoxLoaded(object sender, RoutedEventArgs e)
        {
            if (!Check.StringNotNullOrWhiteSpace(TextBoxControl.Text))
            {
                IsPlaceholderActivated = true;
            }
        }

        private void ValueUp(object sender, RoutedEventArgs e)
        {
            CheckMinimumLessThanMaximum();

            var step = 0;
            if (Step != 0)
            {
                step = Step;
            }
            if (StepUp != 0)
            {
                step = StepUp;
            }

            if (Value + step <= MaxValue)
            {
                Value += step;
            }
        }

        private void ValueDown(object sender, RoutedEventArgs e)
        {
            CheckMinimumLessThanMaximum();

            var step = 0;
            if (Step != 0)
            {
                step = Step;
            }
            if (StepDown != 0)
            {
                step = StepDown;
            }

            if (Value - step >= MinValue)
            {
                Value -= step;
            }
        }

        private void CheckMinimumLessThanMaximum()
        {
            if (MaxValue < MinValue)
            {
                var temp = MaxValue;
                MaxValue = MinValue;
                MinValue = temp;
            }

            NumbersRange = new Range<int>(MinValue, MaxValue);
        }

        private void PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var keyCode = (int)e.Key;

            if (keyCode == 24) // Arrow up
            {
                ValueUp(this, new RoutedEventArgs());
            }
            if (keyCode == 26) // Arrow down
            {
                ValueDown(this, new RoutedEventArgs());
            }

            if (!IsReadOnly)
            {
                // Set placeholder if textbox will be empty
                if (keyCode == 2)
                {
                    if (TextBoxControl.Text.Length < 2 || TextBoxControl.Text.Length == TextBoxControl.SelectionLength)
                    {
                        IsPlaceholderActivated = true;
                    }
                    return;
                }
            }

            if (((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && keyCode == 44) // Ctrl+A
                || ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && keyCode == 46) // Ctrl+C
                || keyCode > 33 && keyCode < 44
                || keyCode > 73 && keyCode < 84
                || keyCode == 2   // Backspace
                || keyCode == 143 // Minus
                || keyCode == 87  // Numpad minus
                || keyCode == 23  // Arrow left
                || keyCode == 25) // Arrow right
            {
                if (!Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.RightShift)) // Disable Shift modificators to exclude characters !@#$ etc.
                {
                    // If not backspace pushed
                    if (keyCode != 2)
                    {
                        if (IsPlaceholderActivated)
                        {
                            IsPlaceholderActivated = false;
                        }
                    }
                    return;
                }
            }

            SetCaretPositionToEnd();

            e.Handled = true;
        }

        private void SetCaretPositionToEnd()
        {
            TextBoxControl.CaretIndex = TextBoxControl.Text.Length;
        }
    }
}