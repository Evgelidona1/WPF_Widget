using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WPFFrameworkControlExample
{
    public partial class UserControl1 : UserControl
    {
        int value;
        public static readonly RoutedEvent ClickBEvent = EventManager.RegisterRoutedEvent("ClickB", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserControl1));

        public event RoutedEventHandler ClickB;
        public UserControl1()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                indicator.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#FF5B5757");
                Int32.TryParse(txtMessage.Text, out value);
                var rotation = new RotateTransform(value*(1.125)-135);
                if (value >= 110 && value<=240)
                {
                    indicator.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#db5353");
                    
                }
                else
                {
                    if(value > 240 || value < 0)
                    {
                        rotation = new RotateTransform(225);

                    }
                }
                rotation.CenterX = 32;
                rotation.CenterY = 228;
                needle.RenderTransform = rotation;
                txtMessage.Text = "";
            }
        }

        private void txtMessage_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
