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
        List<OGArtwork> Artlista = new List<OGArtwork>();
        OGArtworkDB x = new OGArtworkDB();

     
        //List<OGArtworkDB> X = new List<OGArtworkDB>();
         
        public MainWindow()
        {
            InitializeComponent();
            //listBox.ItemsSource = Artlist;
            
            

        }



        //----------------Chris button :) ha så kul------------\\



        private void button_Click(object sender, RoutedEventArgs e)
        {
            Upload u1 = new Upload();
            u1.Show();
        }

        //----- end of chris avsnitt---------------\\


  
        //--------------------Peters del--------------------------\\



        public void updateListbox()
        {
            
            foreach (var item in OGArtworkDB.Artlist)
            {
                if(item.Visible== true)
                {
                    listBox.Items.Add(item.Title);
                }
            }
        }

        private void Testknapp_Click(object sender, RoutedEventArgs e)
        {
            updateListbox();
        }


        //----------Slut på peters del-------------\\



    }
}
