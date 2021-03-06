﻿using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using ProjectArtStone;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        
        CloudTable table;
        CloudTableClient tableClient;

        public Upload()
        {
            InitializeComponent();
            PopulateList();

            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.AppSettings["StorageConnectionString"]);

            //Create the table client
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            //Create the CloudTable object that represents the "people" table
            table = tableClient.GetTableReference("funkytavlor");

        }

        private void PopulateList()
        {
            CloudStorageAccount acc = CloudStorageAccount.Parse(
                ConfigurationManager.AppSettings["StorageConnectionString"]);
            var tableClient = acc.CreateCloudTableClient();
            var table = tableClient.GetTableReference("funkytavlor");
            var entities = table.ExecuteQuery(new TableQuery()).ToList();
            listBox.Items.Clear();
            foreach (var item in entities)
            {
                listBox.Items.Add(item.PartitionKey);
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
                //Create a new Customer Entity
                Artwork artwork1 = new Artwork(tbxTitle.Text, 1);
                artwork1.Artist = tbxArtist.Text;
                artwork1.Visible = true;
                artwork1.Description = tbxDesc.Text;
                artwork1.Room = tbxRoom.Text;
                


                //create the tableoperation object that inserts the customer entity
                TableOperation insertOperation = TableOperation.Insert(artwork1);

                //execute the insert operation,
                table.Execute(insertOperation);
            }
         
        }







        private void button_Click(object sender, RoutedEventArgs e)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
              ConfigurationManager.AppSettings["StorageConnectionString"]);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference("funky");

            // Create the container if it doesn't already exist.
            container.CreateIfNotExists();

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("myblob");

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            if (dlg.FileName != null)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                MessageBox.Show(fs.Name);

                // Create or overwrite the "myblob" blob with contents from a local file.
                using (var fileStream = System.IO.File.OpenRead(fs.Name))
                {
                    blockBlob.UploadFromStream(fileStream);
                }
            }

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
