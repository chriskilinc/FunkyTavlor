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
            this.Hide();
            page3 p3 = new page3();
            p3.Show();
        }

        private void image_MouseUp(object sender, MouseButtonEventArgs e)
        {            
            this.Hide();
            page4 p4 = new page4();
            p4.Show();
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
            Page5 p5 = new Page5();
            p5.Show();
        }
    }
}
