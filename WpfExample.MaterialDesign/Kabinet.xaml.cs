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
    /// Interaction logic for Kabinet.xaml
    /// </summary>
    public partial class Kabinet : Window
    {
        public Kabinet()
        {
            InitializeComponent();
            ApplicationContext db = new ApplicationContext();
            List<User> users = db.Users.ToList();
            ListOfUsers.ItemsSource = users;
        }

        private void ButtonAvt_Click(object sender, RoutedEventArgs e)
        {
            Avtorizacia w = new Avtorizacia();
            w.Show();
            Hide();
        }
    }
}
