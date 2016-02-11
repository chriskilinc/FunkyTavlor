using ProjectArtStone;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ProjectArtStoneMain
{
    /// <summary>
    /// Interaction logic for Upload.xaml
    /// </summary>
    public partial class Upload : Window
    {
        Inventory invent = new Inventory();
        
        public Upload()
        {
            InitializeComponent();
            Refresh();
            
        }

        public void Refresh()
        {
            foreach (var item in invent.GetArtworkList)
            {
                listBox.Items.Add(item);
            }
        }

        byte bytedata;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            if (dlg.FileName != null)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);

                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, System.Convert.ToInt32(fs.Length)); //Storlek?

                fs.Close();

                //Additem
                //bytedata =       //Bytedata skall inehålla bildens bitekod, villket vi ej kan ta fram än
                //if (bytedata == null)
                //{
                //    label1.Content = $"Byte: Null";

                //}


                ImageSourceConverter imgs = new ImageSourceConverter();
                image.SetValue(Image.SourceProperty, imgs.
                ConvertFromString(dlg.FileName.ToString()));

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Check Textboxes
            if (tbxTitle.Text == "")
            {

                lblTitle.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                invent.AddArtwork(5, tbxTitle.Text, tbxArtist.Text, tbxRoom.Text, tbxDesc.Text);  // add this when the first two work, Artist = tbxArtist.Text, Room = tbxRoom.Text, Description = tbxDesc.Text
            }
            Refresh();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
