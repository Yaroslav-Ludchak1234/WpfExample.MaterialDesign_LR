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
using System.Windows.Shapes;

namespace WpfExample.MaterialDesign
{
    /// <summary>
    /// Interaction logic for Avtorizacia.xaml
    /// </summary>
    public partial class Avtorizacia : Window
    {
        public Avtorizacia()
        {
            InitializeComponent();
        }
        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string pass = PassBox.Password.Trim();
            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Дані введено не коректно";
                TextBoxLogin.Background = Brushes.Red;
            }
            else if (pass.Length < 5)
            {
                PassBox.ToolTip = "Дані введено не коректно";
                PassBox.Background = Brushes.Red;
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;
                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Password ==                   pass).FirstOrDefault();
                }
                if (authUser != null)
                {
                    MessageBox.Show("Авторизація пройшла успішно.");
                    Kabinet w = new Kabinet();
                    w.Show();
                    Hide();                    
                }
                else
                {
                    MessageBox.Show("Не правильний логін або пароль");
                }
            }
        }
        private void BtnReestr_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Hide();
        }
        private void Btn_Kab_Click(object sender, RoutedEventArgs e)
        {
            Kabinet w = new Kabinet();
            w.Show();
            Hide();
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
