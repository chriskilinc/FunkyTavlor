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

namespace ProjectArtStone
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            

        }

        List<User> Userlist = new List<User>();

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open edit page (Page 3)");
        }

        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Open preview page (Page 4)");
        }

        

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MainWindow login = new MainWindow();
            //login.Show();

            //Main main = new Main();
            //main.Close();

            //DONT TRY THIS AT HOME
        }

        private void image2_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
<<<<<<< HEAD
            MessageBox.Show("Open preview page (Page 5)");
=======
            MessageBox.Show("Open Account page (Page 6)");
>>>>>>> a2a01921b79a8117478b531389d2c8b0ffd11e73
        }
    }
}
