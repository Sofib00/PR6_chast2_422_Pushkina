using PR6_2chast_422_Pushkina;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PR6_chast2_422_Pushkina
{
    public partial class RegPage : Page
    {
        private Frame _mainFrame;

        public RegPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void otm_Click(object sender, RoutedEventArgs e)
        {
            if (_mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
            else
            {
                _mainFrame.Content = null;
            }
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        public bool Reg(string fio, string log, string par, string par2, string email)
        {
            if (string.IsNullOrEmpty(fio) || string.IsNullOrEmpty(log) || string.IsNullOrEmpty(par) || string.IsNullOrEmpty(par2) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Введите все данные");
                return false;
            }
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Некорректный email!");
                return false;
            }
            if (par != par2)
            {
                MessageBox.Show("Пароли не совпадают");
                return false;
            }
            using (var db = new ПользователиEntities1())
            {
                if (db.User_.Any(u => u.Email == email))
                {
                    MessageBox.Show("Пользователь с таким email уже зарегистрирован!");
                    return false;
                }

                if (db.User_.Any(u => u.Login == log))
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!");
                    return false;
                }
                User_ userObgect = new User_
                {
                    FIO = fio,
                    Login = log,
                    Password = par,
                    Email = email
                };
                db.User_.Add(userObgect);
                try
                {
                    db.SaveChanges();
                    var addedUser = db.User_.FirstOrDefault(u => u.Login == userObgect.Login);

                    if (addedUser != null)
                    {
                        MessageBox.Show("Регистрация прошла успешно! Добро пожаловать, " + addedUser.FIO);
                        fio = "";
                        log = "";
                        par = "";
                        par2 = "";
                        email = "";
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при регистрации, попробуйте снова.");
                        fio = "";
                        log = "";
                        par = "";
                        par2 = "";
                        email = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при сохранении данных: " + ex.Message);
                }
                return true;
            }
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            Reg(fio.Text, login.Text, parol.Password, parol2.Password, email.Text);
        }
    }
}