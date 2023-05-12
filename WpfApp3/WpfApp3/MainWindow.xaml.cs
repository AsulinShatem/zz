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
using WpfApp3.Models;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            pxpass.IsEnabled = false;
        }
        public static class Globals
        {
            public static int UserRole;
            public static Users UserInfo { get; set; }
        }

        private void click1(object sender, RoutedEventArgs e)
        {
            var currentuser = AppData.ekzEntities.Users.FirstOrDefault(u => u.Login == txlogin.Text);
            if (currentuser != null)
            {
                Globals.UserInfo = currentuser;
                Globals.UserRole = currentuser.RoleId;
                pxpass.IsEnabled = true;
                btn1.Visibility = Visibility.Hidden;
                btn2.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("takogo net");
            }
        }

        private async void click2(object sender, RoutedEventArgs e)
        {
            var currentuser1 = AppData.ekzEntities.Users.FirstOrDefault(u => u.Login == txlogin.Text && u.Password == pxpass.Password);
            if (currentuser1 != null)
            {
                Globals.UserInfo = currentuser1;
                Globals.UserRole = currentuser1.RoleId;
                txlogin.IsEnabled = false;
                pxpass.IsEnabled = false;
                suckpan.Visibility = Visibility.Visible;
                while(true)
                {
                    Random x = new Random();
                    int a = x.Next(1000,9999);
                    tbcapt.Text = a.ToString();
                    await Task.Delay(10000);
                }    
            }
        }

        private void click3(object sender, RoutedEventArgs e)
        {
            if (tbcapt.Text == txcapt.Text)
            {
                Window1 window1 = new Window1();
                window1.Show();
                this.Close();
            }
        }
    }
}
