﻿using ProjectArtStone;
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

        //Inventory TheInventory = new Inventory();
        CloudTable table;
        CloudTableClient tableClient;

        
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
             table = tableClient.GetTableReference("funkytavlor");

        }

        public void PopulateList()
        {
           
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
            if (listBox.SelectedItem != null)
            {
                //TheInventory.RemoveFromInventory(((Artwork)listBox.SelectedItem).Id);     //Doesnt work                
                //MessageBox.Show("Removed item Total items now: " + MyInventory.GetArtworkList.Count());

                //TheInventory.RemoveFromInventory(((Artwork)listBox.SelectedItem).Id);
                //MessageBox.Show(listBox.SelectedIndex.ToString());
                //TheInventory.RemoveFromInventory(listBox.SelectedIndex);
                //RefreshListbox(TheInventory);
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
            
        }


        private void addpainting()
        {
            //Create a new Customer Entity
            Artwork artwork1 = new Artwork("Tame Impala", 420);
            artwork1.Artist = "Brutus Östling";
            artwork1.Visible = true;
            artwork1.Description = "Random text Description";



            //create the tableoperation object that inserts the customer entity
            TableOperation insertOperation = TableOperation.Insert(artwork1);

            //execute the insert operation,
            table.Execute(insertOperation);
        }


        

    }
}
