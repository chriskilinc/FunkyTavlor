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

namespace ProjectArtStone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string SweUsername = "Användarnamn";

        public MainWindow()
        {
            InitializeComponent();
            Userlist = DataManager.GetUsers();
            
            textBox.Text = SweUsername;
        }

        List<User> Userlist = new List<User>();

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var index = Userlist.FindIndex(User => User.Username.Equals(textBox.Text, StringComparison.Ordinal) && User.Password.Equals(passwordBox.Password, StringComparison.Ordinal));
            if (index < 0)
            {
                MessageBox.Show("Uppgifterna du angav finns ej i systemet");
            }
            else
            {
                this.Hide();
                Main m1 = new Main();
                m1.Show();
            }
        }

        private void button_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

       

        private void textBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (textBox.Text == SweUsername)
            {
                textBox.Text = "";
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_selectionChanged(object sender, RoutedEventArgs e)
        {

            

            
        }
    }
}
