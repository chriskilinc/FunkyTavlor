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

           var taveltitel = ((dynamic)listBox.SelectedItem).PartitionKey;
           var tavelid = ((dynamic)listBox.SelectedItem).RowKey;                    //Detta ska funka förfan
            

            MessageBox.Show(tavelid);
            
            



            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.AppSettings["StorageConnectionString"]);

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable that represents the "people" table.
            CloudTable table = tableClient.GetTableReference("funkytavlor");

            // Create a retrieve operation that expects a customer entity.
            TableOperation retrieveOperation = TableOperation.Retrieve<TableEntity>(taveltitel, tavelid);

            // Execute the operation.
            TableResult retrievedResult = table.Execute(retrieveOperation);

            // Assign the result to a ArtworkTableEntity object.
            TableEntity updateEntity = (TableEntity)retrievedResult.Result;

            if (updateEntity != null)
            {
                //Update the partitionkey to adelle
                updateEntity.PartitionKey = "Adelle";

                
                updateEntity.RowKey = tavelid;

                // Create the InsertOrReplace TableOperation.
                TableOperation updateOperation = TableOperation.Replace(updateEntity);

                // Execute the operation.
                //table.Execute(updateOperation);

            }


            //editwindow edit = new editwindow();
            //edit.Show();
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

            // Define the query, and select only the Email property.
            

            var entities = table.ExecuteQuery(new TableQuery()).ToList();
            listBox.Items.Clear();
            foreach (var item in entities)
            {
                listBox.Items.Add(item);                                
            }
        }

        private void GetCurrentPaintingsData()
        {

            var taveltitel = ((dynamic)listBox.SelectedItem).PartitionKey;
            var tavelid = ((dynamic)listBox.SelectedItem).RowKey;

            CloudStorageAccount current = CloudStorageAccount.Parse(
                ConfigurationManager.AppSettings["StorageConnectionString"]);
            var tableClient = current.CreateCloudTableClient();
            var table = tableClient.GetTableReference("funkytavlor");


            TableOperation retrieveOperation = TableOperation.Retrieve<TableEntity>(taveltitel, tavelid);
            
            TableResult retrievedData = table.Execute(retrieveOperation);

            if (retrievedData != null)
            {
                txbDescription.Text = (((TableEntity)retrievedData.Result).RowKey);
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetCurrentPaintingsData();
        }
    }
}
