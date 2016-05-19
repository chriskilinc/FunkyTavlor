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
using System.Text;
using System.IO;

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
                ImgUrl = "https://t4boys2016.blob.core.windows.net/funky/" + Identity,
                Visible = true,
            };

            TableOperation insertOperation = TableOperation.Insert(fiktivArtwork);

            CloudBlobClient blobClient;

            blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container;

            container = blobClient.GetContainerReference("funky");
            container.CreateIfNotExists();

            BlobContainerPermissions permissions = container.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permissions);

            var blob = container.GetBlockBlobReference(Identity.ToString());

            string base64String = model.Files.Split(',').LastOrDefault();

            byte[] byteArray = Convert.FromBase64String(base64String);
            //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
            MemoryStream stream = new MemoryStream(byteArray);

            blob.UploadFromStream(stream);           //TODO fix this shit

            table.Execute(insertOperation);            
        }

        public static void DeleteSingleArtworkWithId(Guid? id)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_databaseHelper.GetConnectionString());

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table;
            table = tableClient.GetTableReference("funkytavlor");

            Artwork SingleArtworkEntity = null;

            // Create a retrieve operation that takes a customer entity.
            if (id != Guid.Empty && id != null)
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<Artwork>("ostra", id.ToString());

                // Execute the operation.
                TableResult retrievedResult = table.Execute(retrieveOperation);

                // Assign the result to a CustomerEntity object.
                SingleArtworkEntity = (Artwork)retrievedResult.Result;

                TableOperation deleteOperation = TableOperation.Delete(SingleArtworkEntity);

                //FINISH HIM
                table.Execute(deleteOperation);

                //FAAATTAAALIITYYYYYYYY
            }
        }

        


        public static void EditArtworkByModel(Artwork model)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_databaseHelper.GetConnectionString());

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference("funkytavlor");

            TableOperation retrieveOperation = TableOperation.Retrieve<Artwork>("ostra", model.Id.ToString());

            TableResult retrievedResult = table.Execute(retrieveOperation);

            Artwork editArtwork = (Artwork)retrievedResult.Result;

            if (editArtwork != null)
            {
                editArtwork.Title = model.Title;
                editArtwork.Artist = model.Artist;
                editArtwork.Room = model.Room;
                editArtwork.Signed = model.Signed;
                editArtwork.Visible = model.Visible;
                editArtwork.ImgUrl = "";
                editArtwork.Description = model.Description;
                editArtwork.InStorage = model.InStorage;

                TableOperation editOperation = TableOperation.Replace(editArtwork);

                table.Execute(editOperation);

                Console.WriteLine("Entity updated.");

            }

            else
            {
                Console.WriteLine("Entity could not be retrieved.");
            }
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

        public static List<Artwork> SearchArtworks(string searchString)
        {
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            //    ConfigurationManager.AppSettings[_databaseHelper.GetConnectionString()]);
            
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_databaseHelper.GetConnectionString());
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("funkytavlor");
            var entities = table.ExecuteQuery(new TableQuery<Artwork>());
            var searchStringToLower = searchString.ToLower();
            var queriedEntity = entities.Where(x => x.Title.ToLower().Contains(searchStringToLower));
            foreach (var artwork in entities)
            {
                //Checks if the REQUIERED Title and Artist are NOT null and then returns a valid query
                if (artwork.Title != null && artwork.Artist != null)
                {
                    queriedEntity = entities.Where(x => x.Title.ToLower().Contains(searchStringToLower) || x.Artist.ToLower().Contains(searchStringToLower));
                }
                //Checks if Title, Artist and Room is not null and then returns a valid query
                else if(artwork.Title != null && artwork.Artist != null && artwork.Room != null)
                {
                    queriedEntity = entities.Where(x => x.Title.ToLower().Contains(searchStringToLower) || x.Artist.ToLower().Contains(searchStringToLower) || x.Room.ToLower().Contains(searchStringToLower)); //TOLOWER
                }
                else
                {
                    queriedEntity = entities.Where(x => x.Title.ToLower().Contains(searchStringToLower));
                }
            }
            CloudBlobClient blobClient;

            blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container;

            container = blobClient.GetContainerReference("funky");
            container.CreateIfNotExists();

            return queriedEntity.ToList();
        }
    }
}



