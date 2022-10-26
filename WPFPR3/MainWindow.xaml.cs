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
using WPFPR3.Model;

namespace WPFPR3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAuthorization_Click(object sender, RoutedEventArgs e)
        {
            string login = txtBoxLogin.Text;
            string password = txtBoxPassword.Password;
            HashPasswords.Hash hash = new HashPasswords.Hash();
            password = hash.hashing(password);
            Helper helper = new Helper();
            loginEntities db = Helper.GetContext();
            if (helper.SearchUsers(login,password))
            {
                MessageBox.Show("Вы авторизировались");
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }
    }
}
