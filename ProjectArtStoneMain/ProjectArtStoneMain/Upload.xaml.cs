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
        public Upload()
        {
            InitializeComponent();
        }
        byte[] bytedata;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            if (dlg.FileName != null)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);

                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
                bytedata = data;
                fs.Close();

                //Additem
                


                ImageSourceConverter imgs = new ImageSourceConverter();
                image.SetValue(Image.SourceProperty, imgs.
                ConvertFromString(dlg.FileName.ToString()));

                
                label1.Content = $"Byte: {bytedata}";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            OGArtworkDB.Artlist.Add(new OGArtwork() { ArtId = 1, Title = textBox.Text, Description = "Desctiprion", Rum = 0 ,Visible = true });
        }

        public void CheckDB()
        {
            
        }
    }
}
