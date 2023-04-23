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

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        string loginText = "номер телефона без 7";
        string btnText = "войти";
        bool authState = true;

        public Login()
        {
            InitializeComponent();
            btnAuth.Content = btnText;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void onFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;

            if (text == loginText)
            {
                textBox.Text = "";
            }

        }

        private void onChange(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            authState = true;
            btnAuth.Content = "войти";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            authState = false;
            btnAuth.Content = "зарегестрироваться ";
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (phone.Text == "" || phone.Text == loginText || phone.Text.Length != 10 || password.Password.Length < 4) return;

            int number;
            if (!authState)
            {
                if (int.TryParse(phone.Text, out number))
                {
                    UserType user = App.users.Find(u => u.phone == number);
                    if (user == null)
                    {
                        App.user.createUser(App.users.Count, new Random().Next(40000, 70000), number, password.Password);
                        App.users.Add(App.user);
                        MessageBox.Show("1");
                        NavigationService.Navigate(new Main());
                    }
                    else
                    {
                        MessageBox.Show("пользователь уже существует");

                    }
                }
            }
            else
            {
                if (int.TryParse(phone.Text, out number))
                {
                    UserType user = App.users.Find(u => u.phone == number);
                    if (user != null)
                    {
                        if (user.passsword == password.Password)
                        {
                            NavigationService.Navigate(new Main());
                        }
                        else
                        {
                            MessageBox.Show("не верный пароль");
                        }
                    }
                    else
                    {
                        MessageBox.Show("такого пользователя не существует");
                    }
                }
            }

        }
    }
}
