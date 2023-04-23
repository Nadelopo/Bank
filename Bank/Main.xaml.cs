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

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            Total.Text = App.user.total.ToString() + " руб";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int sum;
            if (int.TryParse(depositeSum.Text, out sum))
            {
                if (sum > App.user.total)
                {
                    depositeSum.Text = App.user.total.ToString();
                }
            }
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void periodChoice(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string[] arguments = button.Tag.ToString().Split(',');
            string period = arguments[0];
            string percentages = arguments[1];
            int deposite;
            if (int.TryParse(depositeSum.Text, out deposite))
            {
                int finailDepositeSum = (deposite + (deposite * int.Parse(percentages) / 100 * int.Parse(period) / 12));
                finalSum.Text = finailDepositeSum.ToString() + " руб";
            }


        }
    }
}
