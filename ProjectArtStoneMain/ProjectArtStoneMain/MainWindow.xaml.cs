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

        Inventory TheInventory = new Inventory();
        
        public MainWindow()
        {
            InitializeComponent();
            PopulateList();

            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                ConfigurationManager.AppSettings["StorageConnectionString"]);

            //Create the table client
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            //Create the CloudTable object that represents the "people" table
            CloudTable table = tableClient.GetTableReference("funkytavlor");

        }

        public void PopulateList()
        {
            foreach (var item in TheInventory.GetArtworkList)
            {
                listBox.Items.Add(item);
            }
        }

        public void RefreshListbox(Inventory TheInventory)
        {
            listBox.Items.Clear();
            foreach (var item in TheInventory.GetArtworkList)
            {
                listBox.Items.Add(item);
            }
        }

        //Upload Button
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Upload u1 = new Upload();
            u1.Show();
        }

        //Remove Button
        private void Tabortknapp_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                //TheInventory.RemoveFromInventory(((Artwork)listBox.SelectedItem).Id);     //Doesnt work                
                //MessageBox.Show("Removed item Total items now: " + MyInventory.GetArtworkList.Count());

                TheInventory.RemoveFromInventory(((Artwork)listBox.SelectedItem).Id);
                //MessageBox.Show(listBox.SelectedIndex.ToString());
                //TheInventory.RemoveFromInventory(listBox.SelectedIndex);
                RefreshListbox(TheInventory);
            }
            else
            {
                MessageBox.Show("Du måste välja vilken tavla du vill ta bort");
            }
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
            RefreshListbox(TheInventory);
        }


        private void addpainting()
        {
            //Create a new Customer Entity
            CustomerEntity customer1 = new CustomerEntity("Tame", "Impala");
            customer1.Email = "Walter@contoso.acom";
            customer1.PartitionKey = "425-555-0101";
            customer1.Funkyness = "Micke äger asså!";



            //create the tableoperation object that inserts the customer entity
            TableOperation insertOperation = TableOperation.Insert(customer1);

            //execute the insert operation,
            table.Execute(insertOperation);
        }


        

    }
}
