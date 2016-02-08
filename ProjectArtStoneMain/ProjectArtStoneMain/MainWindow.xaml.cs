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

namespace ProjectArtStoneMain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //List<OGArtwork> Artlist = new List<OGArtwork>();

        OGArtworkDB X = new OGArtworkDB();
        public MainWindow()
        {
            InitializeComponent();
            listBox.ItemsSource = OGArtworkDB.Artlist;
            
            
           
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Upload u1 = new Upload();
            u1.Show();
        }

        private void Testknapp_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in OGArtworkDB.Artlist)
            {
                
                listBox.Items.Add(item.Titel);
            }
            
        }
    }
}
