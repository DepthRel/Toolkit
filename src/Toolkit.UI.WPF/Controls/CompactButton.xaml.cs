using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Toolkit.UI.WPF.Controls
{
    public partial class CompactButton : UserControl
    {
        #region Dependency properties

        #region IconSettings

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Icon), typeof(CompactButton), new PropertyMetadata(Icon.Unknown));

        public static readonly DependencyProperty IconDropShadowEffectProperty =
            DependencyProperty.Register("IconDropShadowEffect", typeof(DropShadowEffect), typeof(CompactButton),
                new PropertyMetadata(new DropShadowEffect()
                {
                    BlurRadius = 10,
                    Opacity = 0.4,
                    ShadowDepth = 3
                }));

        public static readonly DependencyProperty IconMarginProperty =
            DependencyProperty.Register("IconMargin", typeof(Thickness), typeof(CompactButton), new PropertyMetadata(new Thickness(10, 0, 5, 0)));

        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register("IconSize", typeof(int), typeof(CompactButton), new PropertyMetadata(28));

        public static readonly DependencyProperty IconForegroundProperty =
            DependencyProperty.Register("IconForeground", typeof(Brush), typeof(CompactButton), new PropertyMetadata(Brushes.Black));


        #endregion

        #region ContentSettings

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CompactButton), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty TextMarginProperty =
            DependencyProperty.Register("TextMargin", typeof(Thickness), typeof(CompactButton), new PropertyMetadata(new Thickness(5, 0, 10, 0)));

        public static readonly DependencyProperty TextSizeProperty =
            DependencyProperty.Register("TextSize", typeof(int), typeof(CompactButton), new PropertyMetadata(20));

        public static readonly DependencyProperty TextForegroundProperty =
            DependencyProperty.Register("TextForeground", typeof(Brush), typeof(CompactButton), new PropertyMetadata(Brushes.Black));


        #endregion

        #region SeparatorSettings

        public static readonly DependencyProperty SeparatorVisibilityProperty =
            DependencyProperty.Register("SeparatorVisibility", typeof(Visibility), typeof(CompactButton), new PropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty SeparatorForegroundProperty =
            DependencyProperty.Register("SeparatorForeground", typeof(Brush), typeof(CompactButton), new PropertyMetadata(Brushes.Gray));

        public static readonly DependencyProperty SeparatorMarginProperty =
            DependencyProperty.Register("SeparatorMargin", typeof(Thickness), typeof(CompactButton), new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty SeparatorHeightProperty =
            DependencyProperty.Register("SeparatorHeight", typeof(int), typeof(CompactButton), new PropertyMetadata(35));

        #endregion

        #region DescriptionSettings

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(CompactButton), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty DescriptionSizeProperty =
            DependencyProperty.Register("DescriptionSize", typeof(int), typeof(CompactButton), new PropertyMetadata(12));

        public static readonly DependencyProperty DescriptionForegroundProperty =
            DependencyProperty.Register("DescriptionForeground", typeof(Brush), typeof(CompactButton), new PropertyMetadata(Brushes.Gray));

        #endregion

        public static new readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(CompactButton), new PropertyMetadata(Brushes.Gray));

        public static new readonly DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(CompactButton), new PropertyMetadata(new Thickness(1)));

        public static new readonly DependencyProperty HorizontalContentAlignmentProperty =
            DependencyProperty.Register("HorizontalContentAlignment", typeof(HorizontalAlignment), typeof(CompactButton), new PropertyMetadata(HorizontalAlignment.Left));

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(CompactButton), new PropertyMetadata(null));

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(CompactButton), new PropertyMetadata(null));

        public static readonly DependencyProperty DescriptionMarginProperty =
            DependencyProperty.Register("DescriptionMargin", typeof(Thickness), typeof(CompactButton), new PropertyMetadata(new Thickness(5, 0, 10, 0)));

        public static readonly DependencyProperty ExpandWidthProperty =
            DependencyProperty.Register("ExpandWidth", typeof(double), typeof(CompactButton),
                new FrameworkPropertyMetadata(guaranteedExpandWidth,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback((d, e) => { }),
                    new CoerceValueCallback((d, obj) =>
                    {
                        if (obj is double value)
                        {
                            if (value > (double)d.GetValue(MinimizeWidthProperty))
                            {
                                return value;
                            }
                        }

                        return guaranteedExpandWidth;
                    })));

        public static readonly DependencyProperty MinimizeWidthProperty =
            DependencyProperty.Register("MinimizeWidth", typeof(double), typeof(CompactButton),
                new FrameworkPropertyMetadata(guaranteedMinimizeWidth,
                    new PropertyChangedCallback((d, e) => { }),
                    new CoerceValueCallback((d, obj) =>
                    {
                        if (obj is double value)
                        {
                            if (value > 0 && value < (double)d.GetValue(ExpandWidthProperty))
                            {
                                var currentWidth = (double)d.GetValue(WidthProperty);
                                if (double.IsNaN(currentWidth) || value > currentWidth)
                                {
                                    d.SetValue(WidthProperty, value);
                                }

                                return value;
                            }
                        }

                        return guaranteedMinimizeWidth;
                    })));

        public ExpandMode ExpandMode { get; set; }

        #endregion

        #region Properties

        #region IconSettings

        public Icon Icon
        {
            get => (Icon)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public DropShadowEffect IconDropShadowEffect
        {
            get => (DropShadowEffect)GetValue(IconDropShadowEffectProperty);
            set => SetValue(IconDropShadowEffectProperty, value);
        }

        public Thickness IconMargin
        {
            get => (Thickness)GetValue(IconMarginProperty);
            set => SetValue(IconMarginProperty, value);
        }

        public int IconSize
        {
            get => (int)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }

        public Brush IconForeground
        {
            get => (Brush)GetValue(IconForegroundProperty);
            set => SetValue(IconForegroundProperty, value);
        }

        #endregion

        #region ContentSettings

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public Thickness TextMargin
        {
            get => (Thickness)GetValue(TextMarginProperty);
            set => SetValue(TextMarginProperty, value);
        }

        public int TextSize
        {
            get => (int)GetValue(TextSizeProperty);
            set => SetValue(TextSizeProperty, value);
        }

        public Brush TextForeground
        {
            get => (Brush)GetValue(TextForegroundProperty);
            set => SetValue(TextForegroundProperty, value);
        }

        #endregion

        #region SeparatorSettings

        public Visibility SeparatorVisibility
        {
            get => (Visibility)GetValue(SeparatorVisibilityProperty);
            set => SetValue(SeparatorVisibilityProperty, value);
        }

        public Brush SeparatorForeground
        {
            get => (Brush)GetValue(SeparatorForegroundProperty);
            set => SetValue(SeparatorForegroundProperty, value);
        }

        public Thickness SeparatorMargin
        {
            get => (Thickness)GetValue(SeparatorMarginProperty);
            set => SetValue(SeparatorMarginProperty, value);
        }

        public int SeparatorHeight
        {
            get => (int)GetValue(SeparatorHeightProperty);
            set => SetValue(SeparatorHeightProperty, value);
        }

        #endregion

        #region DescriptionSettings

        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public int DescriptionSize
        {
            get => (int)GetValue(DescriptionSizeProperty);
            set => SetValue(DescriptionSizeProperty, value);
        }

        public Brush DescriptionForeground
        {
            get => (Brush)GetValue(DescriptionForegroundProperty);
            set => SetValue(DescriptionForegroundProperty, value);
        }

        public Thickness DescriptionMargin
        {
            get => (Thickness)GetValue(DescriptionMarginProperty);
            set => SetValue(DescriptionMarginProperty, value);
        }

        #endregion

        public new Thickness BorderThickness
        {
            get => (Thickness)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        public new Brush BorderBrush
        {
            get => (Brush)GetValue(BorderBrushProperty);
            set => SetValue(BorderBrushProperty, value);
        }

        public new HorizontalAlignment HorizontalContentAlignment
        {
            get => (HorizontalAlignment)GetValue(HorizontalContentAlignmentProperty);
            set => SetValue(HorizontalContentAlignmentProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public double ExpandWidth
        {
            get => (double)GetValue(ExpandWidthProperty);
            set => SetValue(ExpandWidthProperty, value);
        }

        public double MinimizeWidth
        {
            get => (double)GetValue(MinimizeWidthProperty);
            set => SetValue(MinimizeWidthProperty, value);
        }

        public ExpandStatus ExpandStatus
        {
            get
            {
                if (expandStatus == ExpandStatus.Minimized && UCContent.Visibility != Visibility.Collapsed)
                {
                    UCContent.Visibility = Visibility.Collapsed;
                }

                return expandStatus;
            }
            set
            {
                var currentWidth = Width;
                if (double.IsNaN(currentWidth))
                {
                    currentWidth = guaranteedMinimizeWidth;
                }

                expandStatus = value;
                if (expandStatus == ExpandStatus.Expanded)
                {
                    DoubleAnimation animation = new DoubleAnimation()
                    {
                        From = currentWidth,
                        To = ExpandWidth,
                        Duration = AnimationDuration
                    };
                    uc.BeginAnimation(UserControl.WidthProperty, animation);

                    DoubleAnimation appearAnimation = new DoubleAnimation()
                    {
                        From = 0,
                        To = 1,
                        Duration = AnimationDuration
                    };

                    UCContent.BeginAnimation(OpacityProperty, appearAnimation);
                }
                if (expandStatus == ExpandStatus.Minimized)
                {
                    DoubleAnimation animation = new DoubleAnimation()
                    {
                        From = currentWidth,
                        To = MinimizeWidth,
                        Duration = AnimationDuration
                    };
                    uc.BeginAnimation(UserControl.WidthProperty, animation);

                    DoubleAnimation disappearAnimation = new DoubleAnimation()
                    {
                        From = 1,
                        To = 0,
                        Duration = AnimationDuration
                    };

                    UCContent.BeginAnimation(OpacityProperty, disappearAnimation);
                }
            }
        }

        private Duration animationDuration;

        public Duration AnimationDuration
        {
            get => animationDuration;
            set => animationDuration = value;
        }

        #endregion

        #region Fields

        private ExpandStatus expandStatus;
        private const double guaranteedMinimizeWidth = 50.0;
        private const double guaranteedExpandWidth = 200.0;

        #endregion

        public CompactButton()
        {
            InitializeComponent();

            ExpandMode = ExpandMode.Auto;
            //ExpandStatus = ExpandStatus.Minimized;
        }

        private new void MouseEnter(object sender, MouseEventArgs e)
        {
            if (ExpandMode == ExpandMode.Auto)
            {
                ExpandStatus = ExpandStatus.Expanded;
            }
        }

        private new void MouseLeave(object sender, MouseEventArgs e)
        {
            if (ExpandMode == ExpandMode.Auto)
            {
                ExpandStatus = ExpandStatus.Minimized;
            }
        }
    }
}