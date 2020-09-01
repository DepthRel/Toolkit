using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Toolkit.UI.WPF.Controls;

namespace Toolkit.UI.WPF.Tests
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogBox box = new DialogBox()
            {
                HeaderVerticalAlignment = VerticalAlignment.Center,
                Background = Brushes.White,
                Header = new TextBlock() { Text = "The header!" },
                HeaderForeground = Brushes.Black,
                HeaderMargin = new Thickness(20, 0, 20, 0),
                Content = new TextBlock() { Text = "It's content!", FontSize = 20 },
                ContentForeground = Brushes.Red,
                ContentMargin = new Thickness(20),
                BorderBrush = Brushes.YellowGreen.Color,
                ButtonsBackground = Brushes.Black,
                ButtonsForeground = Brushes.BlueViolet,
                ButtonsConfiguration = DialogBoxButtons.Close | DialogBoxButtons.All,
                PrimaryButtonContent = "Apply",
                ButtonsFontSize = 15,
                ButtonsFontFamily = new FontFamily("Arial")
            };

            var result = box.ShowDialog();
            // box.Show();
        }
    }
}
