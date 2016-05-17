﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using MvcArtStone.Models;

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
            var entities = table.ExecuteQuery(new TableQuery<Artwork>()).Where(x => x.Visible);
            return entities.ToList();
        }

        public static void AddArtwork(ArtworkInsertModel model, string name)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_databaseHelper.GetConnectionString());

            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            //    ConfigurationManager.AppSettings["StorageConnectionString"]);

            CloudBlobContainer container;
            //create the blob client
            CloudTable table;
            //Create the table client

            CloudBlobClient blobClient;
            blobClient = storageAccount.CreateCloudBlobClient();

            container = blobClient.GetContainerReference("funky");

            container.CreateIfNotExists();

            BlobContainerPermissions permissions = container.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            container.SetPermissions(permissions);


            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            //Create the CloudTable object with your table reference

            var blob = container.GetBlobReference(name);



            table = tableClient.GetTableReference("funkytavlor");

            Artwork fiktivArtwork = new Artwork()
            {
                Title = model.Title,
                AddedDate = DateTime.UtcNow.Date,
                Artist = model.Artist,
                CreationDate = DateTime.UtcNow.Date,
                Description = model.Description,
                Id = null,
                InStorage = model.InStorage,
                PartitionKey = model.Title,
                RowKey = model.Id.ToString(),
                Room = model.Room,
            };



  
        TableOperation insertOperation = TableOperation.Insert(fiktivArtwork);

        //table.Execute(insertOperation);

        //throw new NotImplementedException();
        }

      
        public Artwork GetSingleArtwork(string partitionKey, string rowKey)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_databaseHelper.GetConnectionString());

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table;
            table = tableClient.GetTableReference("funkytavlor");

            Artwork SingleArtworkEntity = null;

            // Create a retrieve operation that takes a customer entity.
            if (partitionKey != null && rowKey != null)
            {
                TableOperation retrieveOperation = TableOperation.Retrieve<Artwork>(partitionKey, rowKey);

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

        //CRUD Artwork
        //public void AddCompany(Models.Company company)
        //{
        //    using (var context = new GatewayContextDataContext(_databaseHelper.GetConnectionString()))
        //    {
        //        var newCompany = new Company
        //        {
        //            VATRegistrationNumber = company.CorporateIdentityNumber,
        //            CompanyName = company.Name,
        //            CompanyNameAlternative = company.Name,
        //            WebAddress = "www.example.com",
        //            Deleted = false,
        //            RegistrationDate = DateTime.Now,
        //            Comment = "Test Company",
        //            Address = new Address
        //            {
        //                Street = company.InvoiceAddress1,
        //                City = company.InvoiceCity,
        //                ZipCode = company.InvoicePostalCode,
        //                AddressType = new AddressType
        //                {
        //                    AddressTypeId = 1,  //Fakturaadress
        //                },
        //                Country = new Country
        //                {
        //                    CountryCode = company.InvoiceCountryCode,
        //                    IsEU = true, //check if country is in EU
        //                    EnglishName = "EnglishName",
        //                    NativeName = "NativeName",
        //                    CultureCode = "CultureCode",
        //                    CallingCode = "CallingCode",
        //                }
        //            },
        //            ContactPerson = new ContactPerson
        //            {
        //                FirstName = company.ContactPersonName

        //            },
        //            CompanyInvoiceSetting = new CompanyInvoiceSetting
        //            {
        //                Currency = new Currency
        //                {
        //                    CurrencyCode = company.CurrencyCode,
        //                    CurrencyIsoCode = "s",
        //                },
        //                DueDays = 1,
        //            },


        //            //Add more fields
        //        };

        //        context.Companies.InsertOnSubmit(newCompany);
        //        //context.Addresses.InsertOnSubmit(newCompany.Address);
        //        //context.Companies..InsertOnSubmit(newCompany.VATRegistrationNumber);
        //        context.SubmitChanges();
        //    }
        //}
    }
}
