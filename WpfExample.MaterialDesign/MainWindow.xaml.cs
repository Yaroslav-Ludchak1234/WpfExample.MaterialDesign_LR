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

namespace WpfExample.MaterialDesign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();               
            db = new ApplicationContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string password = PassBox.Password.Trim();
            string password_2 = PassBox2.Password.Trim();
            string mail = TextBoxMail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Дані введено не коректно";
                TextBoxLogin.Background = Brushes.Red;
            }
            else if (password.Length < 5)
            {
                PassBox.ToolTip = "Дані введено не коректно";
                PassBox.Background = Brushes.Red;
            }
            else if (password != password_2)
            {
                PassBox2.ToolTip = "Дані введено не коректно";
                PassBox2.Background = Brushes.Red;
            }
            else if (mail.Length < 5 || !mail.Contains("@") ||
           !mail.Contains("."))
            {
                TextBoxMail.ToolTip = "Дані введено не коректно";
                TextBoxMail.Background = Brushes.Red;
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;
                PassBox.ToolTip = "";
                PassBox.Background = Brushes.Transparent;
                PassBox2.ToolTip = "";
                PassBox2.Background = Brushes.Transparent;
                TextBoxMail.ToolTip = "";
                TextBoxMail.Background = Brushes.Transparent;

                MessageBox.Show("Реєстрація пройшла успішно");

                User user = new User(login, password, mail);
                db.Users.Add(user);
                db.SaveChanges();
                Kabinet w = new Kabinet();
                w.Show();
                Hide();
            }
        }

        //private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}

        //private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    DragMove();
        //}

        //private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    int index = ListViewMenu.SelectedIndex;
        //    MoveCursorMenu(index);
        //}

        //private void MoveCursorMenu(int index)
        //{
        //    TransitioningContentSlide.OnApplyTemplate();
        //    GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        //}
    }
}
