using PR6_2chast_422_Pushkina;
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

namespace PR6_chast2_422_Pushkina
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

        public bool Auth(string log, string pas)
        {
            if(string.IsNullOrEmpty(log) || string.IsNullOrEmpty(pas))
            {
                MessageBox.Show("Введите логин и пароль");
                return false;
            }
            using (var db = new ПользователиEntities1())
            {
                var user = db.User_
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Login == log && u.Password == pas);

                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден");
                    return false;
                }

                MessageBox.Show("Вход выполнен! Добро пожаловать, " + user.FIO + "!");
                return true;
            }
        }

        private void кнопка_Click(object sender, RoutedEventArgs e)
        {
            Auth(login.Text, parol.Password);
        }

        private void registraz_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RegPage(MainFrame));
        }
    }
}
