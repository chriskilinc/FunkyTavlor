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
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace ProjectArtStoneMain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        


        CloudTable table;
        CloudTableClient tableClient;

        
        
        public MainWindow()
        {
            InitializeComponent();
            PopulateList();

            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.AppSettings["StorageConnectionString"]);

                       
            
        }

        public void PopulateList()
        {
            GetAllPaintingsData();
        }

        

        //Upload Button
        private void button_Click(object sender, RoutedEventArgs e)
        {
            addpainting();
            //Upload u1 = new Upload();
            //u1.Show();
        }

        //Remove Button
        private void Tabortknapp_Click(object sender, RoutedEventArgs e)
        {

            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.AppSettings["StorageConnectionString"]); 

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve reference to a previously created container.
            var container = blobClient.GetContainerReference("funky").ListBlobs();

            var urls = new List<string>();
            foreach (var blob in container)
            {
                string url = "funky" + blob.uri.AbsoluteUri;
                urls.Add(url);
            }

            //// Loop over items within the container and output the length and URI.
            //foreach (IListBlobItem item in container.ListBlobs(null, false))
            //{
            //    if (item.GetType() == typeof(CloudBlockBlob))
            //    {
            //        CloudBlockBlob blob = (CloudBlockBlob)item;


            //        txbDescription.Text = ($"Block blob of length {0}: {1}" + blob.Properties.Length + blob.Uri);
            //        //Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Uri);

            //    }
            //    else if (item.GetType() == typeof(CloudPageBlob))
            //    {
            //        CloudPageBlob pageBlob = (CloudPageBlob)item;

            //        Console.WriteLine("Page blob of length {0}: {1}", pageBlob.Properties.Length, pageBlob.Uri);

            //    }
            //    else if (item.GetType() == typeof(CloudBlobDirectory))
            //    {
            //        CloudBlobDirectory directory = (CloudBlobDirectory)item;

            //        txbDescription.Text=($"Directory: {0}" + directory.Uri);

            //        Console.WriteLine("Directory: {0}", directory.Uri);
            //    }
            //}






        }




        //
        //?? Button
        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        //Edit Button
        private void btnedit_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex > -1)
            {
                editwindow ew = new editwindow();
                ew.Show();
            }
            else
            {
                MessageBox.Show("you need to select what to edit");
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            GetAllPaintingsData();
        }


        private void addpainting()  //don't use  this shit
        {

            Upload UploadWindow = new Upload();
            UploadWindow.Show();
        }


        private void GetAllPaintingsData()
        {
            CloudStorageAccount acc = CloudStorageAccount.Parse(
            ConfigurationManager.AppSettings["StorageConnectionString"]);
            var tableClient = acc.CreateCloudTableClient();
            var table = tableClient.GetTableReference("funkytavlor");

            
            

            var entities = table.ExecuteQuery(new TableQuery()).ToList();
            listBox.Items.Clear();
            foreach (var item in entities)
            {
                listBox.Items.Add(item);                                
            }
        }

        private void GetCurrentPaintingsData()
        {

            if (listBox.SelectedItem == null)
            {
                return;
            }
            var taveltitel = ((dynamic)listBox.SelectedItem).PartitionKey;
            var tavelid = ((dynamic)listBox.SelectedItem).RowKey;

            CloudStorageAccount current = CloudStorageAccount.Parse(
            ConfigurationManager.AppSettings["StorageConnectionString"]);
            tableClient = current.CreateCloudTableClient();
            table = tableClient.GetTableReference("funkytavlor");



            // Define the query, and select only the Email property.
            TableQuery<DynamicTableEntity> projectionQuery = new TableQuery<DynamicTableEntity>().Select(new string[] { "Description" }).Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, taveltitel));

            // Define an entity resolver to work with the entity after retrieval.
            EntityResolver<string> resolver = (pk, rk, ts, props, etag) => props.ContainsKey("Description") ? props["Description"].StringValue : null;



            foreach (string projectedDescription in table.ExecuteQuery(projectionQuery, resolver, null, null))
            {
                txbDescription.Text = projectedDescription;
            }

           
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetCurrentPaintingsData();
        }
    }
}
