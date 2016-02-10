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
            foreach (OGArtwork art in OGArtworkDB.Artlist)
            {
                Artlista.Add(new OGArtwork(art.ArtId, art.Artist, art.Title, art.Description, art.Rum, true));
            }
            updateListbox();
        }



        //----------------Chris button :) ha så kul------------\\



        private void button_Click(object sender, RoutedEventArgs e)
        {
            //OGArtworkDB.Artlist.Add(new OGArtwork(1, "Peter", "Peters Tavla", "Holahola", 3, true));


            updateListbox();
            
            Upload u1 = new Upload();
            u1.Show();
        }

        //----- end of chris avsnitt---------------\\


  
        //--------------------Peters del--------------------------\\



        public void updateListbox()
        {
            listBox.Items.Clear();   
            foreach (var item in Artlista)
            {
                if(item.Visible== true)
                {
                    listBox.Items.Add(item.Title);
                }
            }
        }

        private void Tabortknapp_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex > -1)
            {
                OGArtworkDB.Artlist.RemoveAt(listBox.SelectedIndex);
                updateListbox();
            }
            else
            {
                MessageBox.Show("Du måste välja vilken tavla du vill ta bort");
            }

            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //foreach (var item in Artlista)
            //{
            //    listBox.Items.Add(item.Title);
            //}
            updateListbox();
        }

        private void btnedit_Click(object sender, RoutedEventArgs e)
        {
            if(listBox.SelectedIndex > -1)
            {
                editwindow ew = new editwindow();
                ew.Show();
            }
            else
            {
                MessageBox.Show("you need to select what to edit");
            }
        }


        //----------Slut på peters del-------------\\



    }
}
