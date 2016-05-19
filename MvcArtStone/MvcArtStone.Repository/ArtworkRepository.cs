using System;
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


            CloudBlobClient blobClient;

            blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container;

            container = blobClient.GetContainerReference("funky");
            container.CreateIfNotExists();

            return entities.ToList();
        }

        public static void AddImage(HttpPostedFileBase image)
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


            var blob = container.GetBlockBlobReference("7f6d2c7c-690a-4440-b4b4-af25440f8e1e");

            blob.UploadFromStreamAsync(image.InputStream); //TODO fix this shit


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
                AddedDate = DateTime.UtcNow,
                Artist = model.Artist,
                CreationDate = DateTime.UtcNow,
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

            table.Execute(insertOperation);
            //table.Execute(insertOperation);
        }

        public static Artwork EditArtworkByModel(Artwork model)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_databaseHelper.GetConnectionString());

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table;
            table = tableClient.GetTableReference("funkytavlor");

            Artwork SingleArtworkEntity = null;

            // Create a retrieve operation that takes a customer entity.
            if (model.Id != Guid.Empty)
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<Artwork>("ostra", model.Id.ToString());

                // Execute the operation.
                TableResult retrievedResult = table.Execute(retrieveOperation);

                // Assign the result to a CustomerEntity object.
                SingleArtworkEntity = (Artwork)retrievedResult.Result;

                //change the properties to new properties
                //if(SingleArtworkEntity!= null)
                //{
                //    SingleArtworkEntity.Title = model.Title,
                //    SingleArtworkEntity.AddedDate = DateTime.UtcNow,
                //    SingleArtworkEntity.Artist = model.Artist,
                //    SingleArtworkEntity.CreationDate = DateTime.UtcNow,
                //    SingleArtworkEntity.Description = model.Description,
                //    SingleArtworkEntity.Id = model.Id,
                //    SingleArtworkEntity.InStorage = model.InStorage,
                //    SingleArtworkEntity.PartitionKey = "ostra",
                //    SingleArtworkEntity.RowKey = Identity.ToString(),
                //    SingleArtworkEntity.Room = model.Room,
                //    SingleArtworkEntity.ImgUrl = "",
                //    SingleArtworkEntity.Visible = true,
                //}                       
            }




            return SingleArtworkEntity;

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
    }
}



