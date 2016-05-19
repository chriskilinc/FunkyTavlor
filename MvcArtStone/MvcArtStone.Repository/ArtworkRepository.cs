﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using MvcArtStone.Models;
using System.Web;

namespace MvcArtStone.Repository
{
    public class ArtworkRepository
    {
        private static DatabaseHelper _databaseHelper;

        public ArtworkRepository()
        {
            _databaseHelper = new DatabaseHelper();

        }

        public static List<Artwork> GetPaintingsAsList()
        {
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            //    ConfigurationManager.AppSettings[_databaseHelper.GetConnectionString()]);

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_databaseHelper.GetConnectionString());

            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("funkytavlor");
            var entities = table.ExecuteQuery(new TableQuery<Artwork>());//.Where(x => x.Visible);
            return entities.ToList();
        }

        public static async void AddImage(HttpPostedFile image)
        {

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_databaseHelper.GetConnectionString());
            CloudBlobClient blobClient;

            blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container;

            container = blobClient.GetContainerReference("funky");
            container.CreateIfNotExists();

            BlobContainerPermissions permissions = container.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permissions);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            //Create the CloudTable object with your table reference


            var blob = container.GetBlockBlobReference(image.FileName);

            await blob.UploadFromStreamAsync(image.InputStream); //TODO fix this shit


        }


        public static void AddArtwork(ArtworkInsertModel model)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_databaseHelper.GetConnectionString());

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table;

            table = tableClient.GetTableReference("funkytavlor");

            Guid Identity = Guid.NewGuid(); 

            Artwork fiktivArtwork = new Artwork()
            {
                
                Title = model.Title,
                AddedDate = DateTime.UtcNow.Date,
                Artist = model.Artist,
                CreationDate = DateTime.UtcNow.Date,
                Description = model.Description,
                Id = Identity,
                InStorage = model.InStorage,
                PartitionKey = "ostra",
                RowKey = Identity.ToString(),
                Room = model.Room,
                ImgUrl = "",
                Visible = true,
            };

            TableOperation insertOperation = TableOperation.Insert(fiktivArtwork);

            //table.Execute(insertOperation);
            //table.Execute(insertOperation);
        }





        public Artwork GetSingleArtworkById(string id)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_databaseHelper.GetConnectionString());

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table;
            table = tableClient.GetTableReference("funkytavlor");

            Artwork SingleArtworkEntity = null;

            // Create a retrieve operation that takes a customer entity.
            if (id != string.Empty)
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<Artwork>("ostra", id);

                // Execute the operation.
                TableResult retrievedResult = table.Execute(retrieveOperation);

                // Assign the result to a CustomerEntity object.
                SingleArtworkEntity = (Artwork)retrievedResult.Result;
            }

            if (SingleArtworkEntity != null)
            {
                return SingleArtworkEntity;
            }
            else
            {
                return null;
            }
        }

        public static void EditSingleArtwork(Artwork model)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_databaseHelper.GetConnectionString());

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table;
            table = tableClient.GetTableReference("funkytavlor");

            Artwork SingleArtworkEntity = null;

            // Create a retrieve operation that takes a customer entity.
            if (model.PartitionKey != null && model.RowKey != null)
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<Artwork>(model.PartitionKey, model.RowKey);

                // Execute the operation.
                TableResult retrievedResult = table.Execute(retrieveOperation);

                // Assign the result to a CustomerEntity object.
                SingleArtworkEntity = (Artwork)retrievedResult.Result;
            }

            if (SingleArtworkEntity != null)
            {
                //TODO add parameters that should be changed
            }
        }
    }
}



