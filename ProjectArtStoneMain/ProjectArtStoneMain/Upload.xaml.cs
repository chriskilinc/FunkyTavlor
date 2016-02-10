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
        //OGArtworkDB Z = new OGArtworkDB();

        public Upload()
        {
            InitializeComponent();
            Refresh();
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
                if (bytedata == null)
                {
                    label1.Content = $"Byte: Null";

                }


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
                OGArtworkDB.Artlist.Add(new OGArtwork(1, tbxArtist.Text, tbxTitle.Text, tbxDesc.Text, 3, true));
                MessageBox.Show("Works!");
            }
            //OGArtworkDB.Artlist.Add(new OGArtwork() { ArtId = 1, Title ="Ny titel", Artist ="Gunnilla Person", Description = "Fin bild", Rum=0,Visible=true});
            //OGArtworkDB.Artlist.Add(new OGArtwork() { ArtId = 1, Title = tbxTitle.Text, Artist = tbxArtist.Text, Description = tbxDesc.Text, Rum = 0, Visible = true });
            //this.Close();
            //MainWindow m2 = new MainWindow();
            //m2.Show();
            Refresh();

        }

        public void Refresh()
        {
            foreach (var item in OGArtworkDB.Artlist)
            {
                listBox.Items.Clear();
                if (item.Visible == true)
                {
                    listBox.Items.Add(item.Title);
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
    }
}
