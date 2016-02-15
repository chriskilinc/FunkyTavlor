using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for editwindow.xaml
    /// </summary>
    public partial class editwindow : Window
    {
        CloudTable table;
        CloudTableClient tableClient;

        public editwindow()
        {
            InitializeComponent();

            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.AppSettings["StorageConnectionString"]);

            //Create the table client
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            //Create the CloudTable object that represents the "people" table
            table = tableClient.GetTableReference("funkytavlor");


            GetInfo();
        }

        private void GetInfo()
        {
            CloudStorageAccount acc = CloudStorageAccount.Parse(
                ConfigurationManager.AppSettings["StorageConnectionString"]);
            var tableClient = acc.CreateCloudTableClient();
            var table = tableClient.GetTableReference("funkytavlor");

            

            //IEnumerable arrayNumerable = table.ExecuteQuery(new TableQuery()).ToArray();


            var entities = table.ExecuteQuery(new TableQuery()).ToList();
            foreach (var item in entities)
            {

            }

        }
        
    }
}
