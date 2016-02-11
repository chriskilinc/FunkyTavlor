using ProjectArtStone;
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

        
        
        public MainWindow()
        {
            InitializeComponent();
            Inventory MyInventory = new Inventory();
            RefreshListbox(MyInventory);

            btnRemove.Click += new EventHandler((x, y) =>
            {
                if (listBox.SelectedItem != null)
                {
                    MyInventory.RemoveFromInventory(((Artwork)listBox.SelectedItem).Id);
                    //MessageBox.Show("Removed item Total items now: " + MyInventory.GetArtworkList.Count());
                    RefreshListbox(MyInventory);
                }

            });

        }

        private void RefreshListbox(Inventory MyInventory)
        {
            listBox.Items.Clear();
            foreach (var item in MyInventory.GetArtworkList)
            {
                listBox.Items.Add(item.Presentation);
            }
        }



        //public void PopulateList()
        //{
        //    foreach (var item in TheInventory.GetArtworkList)
        //    {
        //        listBox.Items.Add(item.Presentation);
        //    }
        //}

        //public void RefreshListbox(Inventory TheInventory)
        //{
        //    listBox.Items.Clear();
        //    foreach (var item in TheInventory.GetArtworkList)
        //    {
        //        listBox.Items.Add(item.Presentation);
        //    }
        //}

        ////Upload Button
        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //    Upload u1 = new Upload();
        //    u1.Show();
        //}

        ////Remove Button
        //private void Tabortknapp_Click(object sender, RoutedEventArgs e)
        //{
        //    if (listBox.SelectedItem != null)
        //    {
        //        //TheInventory.RemoveFromInventory(((Artwork)listBox.SelectedItem).Id);     //Doesnt work                
        //        //MessageBox.Show("Removed item Total items now: " + MyInventory.GetArtworkList.Count());

        //        TheInventory.RemoveFromInventory(((Artwork)listBox.SelectedItems).Id);
        //        RefreshListbox(TheInventory);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Du måste välja vilken tavla du vill ta bort");
        //    }
        //}



        ////
        ////?? Button
        //private void button1_Click(object sender, RoutedEventArgs e)
        //{

        //}

        ////Edit Button
        //private void btnedit_Click(object sender, RoutedEventArgs e)
        //{
        //    if (listBox.SelectedIndex > -1)
        //    {
        //        editwindow ew = new editwindow();
        //        ew.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("you need to select what to edit");
        //    }
        //}

        //private void button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    RefreshListbox(TheInventory);
        //}


        ////----------Slut på peters del-------------\\
    }
}
