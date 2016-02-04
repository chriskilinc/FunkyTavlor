using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;


namespace ProjectArtStone
{
    /// <summary>
    /// Interaction logic for uploadimagejamwindow2.xaml
    /// </summary>
    public partial class uploadimagejamwindow2 : Window
    {

        SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ProjektArtstoneJammingDb;Integrated Security=True");

        public uploadimagejamwindow2()
        {
            InitializeComponent();

            sqlCon.Open();
            DataSet ds = new DataSet();

            SqlDataAdapter sqa = new SqlDataAdapter("select name from picture", sqlCon);
            sqa.Fill(ds);

            sqlCon.Close();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                ListBoxItem lbItem = new ListBoxItem();
                lbItem.Content = dataRow[0].ToString();
                lbpics.Items.Add(lbItem);

            }
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lbpics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lb = (lbpics.SelectedItem as ListBoxItem);
            sqlCon.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sqa = new SqlDataAdapter("Select pic from picture where name='" + lb.Content.ToString() + "'", sqlCon);
            sqa.Fill(ds);
            sqlCon.Close();




            byte[] data = (byte[])ds.Tables[0].Rows[0][0];

            MemoryStream strm = new MemoryStream();

            System.Drawing.Image imgWinForms = System.Drawing.Image.FromStream(strm);



            strm.Write(data, 0, data.Length);

            strm.Position = 0;


            // ImageSource ...

            BitmapImage bi = new BitmapImage();

            bi.BeginInit();

            MemoryStream ms = new MemoryStream();

            // Save to a memory stream...

            imgWinForms.Save(ms, ImageFormat.Bmp);

            // Rewind the stream...

            ms.Seek(0, SeekOrigin.Begin);

            // Tell the WPF image to use this stream...

            bi.StreamSource = ms;

            bi.EndInit();

            imagebox.Source = bi;











            //byte[] data = (byte[])ds.Tables[0].Rows[0][0];

            //MemoryStream strm = new MemoryStream();

            //using (MemoryStream stream = strm)
            //{
            //    var imageSource = new BitmapImage();
            //    imageSource.BeginInit();
            //    imageSource.StreamSource = stream;

            //    strm.Write(data, 0, data.Length);

            //    strm.Position = 0;
            //                                                     //1

            //    BitmapImage bi = new BitmapImage();

            //    bi.BeginInit();

            //    MemoryStream ms = new MemoryStream();

            //                                                       //2 

            //    ms.Seek(0, SeekOrigin.Begin);

            //    bi.StreamSource = ms;

            //    bi.EndInit();

            //    imagebox.Source = bi;
        }

             
            //imagebox.Source = imageSource;   1

            //img.Save(ms, Image.ImageFormat.Bmp);   2




            ////System.Drawing.Image img = System.Drawing.Image.FromStream(strm);


            //  Image img; //= Image.FromStream(strm);


        }

        private static BitmapImage LoadImage(Stream stream)
        {
            // assumes that the streams position is at the beginning
            // for example if you use a memory stream you might need to point it to 0 first
            var image = new BitmapImage();

            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.StreamSource = stream;
            image.EndInit();

            image.Freeze();
            return image;
        }



    }
}
