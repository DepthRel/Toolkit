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
            Toolkit.UI.WPF.Controls.DialogBox box = new Toolkit.UI.WPF.Controls.DialogBox()
            {
                // Positioning the title within the top block vertically. Default value is Center
                HeaderVerticalAlignment = VerticalAlignment.Center,
                // Positioning the title within the top block horizontally. Default value is Left
                HeaderHorizontalAlignment = HorizontalAlignment.Left,
                // Whole window background color. Default value is White
                Background = Brushes.White,
                // The content of the header can contain any control. Default font size is 28
                Header = new TextBlock() { Text = "The header!" },
                // Header content color. Default value is Black
                HeaderForeground = Brushes.Black,
                // Padding of the header from edges. Default value is 0
                HeaderMargin = new Thickness(20, 0, 20, 0),
                // The main content of the message. Can contain any control
                Content = new TextBlock() { Text = "It's content!", FontSize = 20 },
                // Main content color. Default value is Black
                ContentForeground = Brushes.Red,
                // Padding content from edges. Default value is 0
                ContentMargin = new Thickness(20),
                // The color of the dialog box border. Default value is Black
                // Attention, the frame is implemented as a symmetrical shadow on all sides.
                BorderBrush = Brushes.YellowGreen.Color,
                // The color of all buttons located on the dialog box. Default value is White
                ButtonsBackground = Brushes.Black,
                // The color of the contents of the buttons located on the dialog box. Default value is Black
                ButtonsForeground = Brushes.BlueViolet,
                // A variation of the buttons to be placed on the dialog box.
                // Implemented as flags so can be configured based on preference.
                // However, there are predefined options such as DialogBoxButtons.PrimaryAndClose and DialogBoxButtons.All.
                // Default value is DialogBoxButtons.PrimaryAndClose
                ButtonsConfiguration = DialogBoxButtons.Close | DialogBoxButtons.Primary,
                // A way of putting content on a button. Likewise for the Close and Secondary buttons.
                // Default value for primary is "Apply";
                // Default value for secondary is "Secondary";
                // Default value for primary is "Close"
                PrimaryButtonContent = "Apply",
                // Font size for buttons. Default value is 12
                ButtonsFontSize = 15,
                // The font family used for the buttons. Default value is "Segoe UI"
                ButtonsFontFamily = new FontFamily("Arial")
            };

            // Show the window and wait for the exit from the dialog.
            // The result is a DialogBoxResult enum, and can be Primary, Secondary, or Close
            var result = box.ShowDialog();

            // Simple display of a dialog box without waiting for the user's decision.
            // box.Show();
        }
    }
}