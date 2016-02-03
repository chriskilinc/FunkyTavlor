using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ProjectArtStone
{
    /// <summary>
    /// Interaction logic for uploadimagejam.xaml
    /// </summary>
    public partial class uploadimagejam : Window
    {
        

        public uploadimagejam()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            

            
        }

        private void btnnext_Click(object sender, RoutedEventArgs e)
        {
         
            uploadimagejamwindow2 obj = new uploadimagejamwindow2();
            obj.Show();
            this.Close();
        }

        private void LoadImg_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);

            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, System.Convert.ToInt32(fs.Length));

            fs.Close();

            SqlConnection sqlCon = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ProjektArtstoneJammingDb;Integrated Security=True");

            sqlCon.Open();
            SqlCommand sc = new SqlCommand("insert into picture(pic, name) values(@p, @n)", sqlCon);

            sc.Parameters.AddWithValue("@p", data);
            sc.Parameters.AddWithValue("@n", tbname.Text);
            sc.ExecuteNonQuery();
            sqlCon.Close();


            ImageSourceConverter imgs = new ImageSourceConverter();
            imagebox.SetValue(Image.SourceProperty, imgs.
            ConvertFromString(dlg.FileName.ToString()));

            tbname.Text = "";
        }
    }
}













































//        private byte[] _imageBytes = null;

//        // Browse for an image on your computer
//        private void BrowseButton_OnClick(object sender, RoutedEventArgs e)
//        {
//            var dialog = new OpenFileDialog
//            {
//                CheckFileExists = true,
//                Multiselect = false,
//                Filter = "Images (*.jpg,*.png)|*.jpg;*.png|All Files(*.*)|*.*"
//            };

//            if (dialog.ShowDialog() != true) { return; }

//            ImagePath.Text = dialog.FileName;
//            MyImage.Source = new BitmapImage(new Uri(ImagePath.Text));

//            using (var fs = new FileStream(ImagePath.Text, FileMode.Open, FileAccess.Read))
//            {
//                _imageBytes = new byte[fs.Length];
//                fs.Read(_imageBytes, 0, System.Convert.ToInt32(fs.Length));
//            }
//        }

//        // Save the selected image to your database
//        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
//        {
//            if (!String.IsNullOrEmpty(ImagePath.Text))
//            {
//                var db = new Artwork();
//                var uploadedImg = new Artwork
//                {
//                    ArtId = 0,
//                    ImageContent = _imageBytes,
//                    Title = ImagePath.Text
//                };
                
                

               
//            }
//        }

//        // Load an image from the database
//        private void LoadButton_OnClick(object sender, RoutedEventArgs e)
//        {
//            // Load 1 image from the database and display it
//            var db = new Artwork();
//            var img = db.ImageContent.FirstOrDefault();


//            //if (img != null)
//            //{
//            //    // Display the loaded image
//            //    ImageFile.Source = new BitmapImage(new Uri(img.ImageName));
//            //}
//        }

//    }
//}


