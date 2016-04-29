using System;
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

        public static IEnumerable<DynamicTableEntity> GetPaintingsAsList()
        {
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            //    ConfigurationManager.AppSettings[_databaseHelper.GetConnectionString()]);

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_databaseHelper.GetConnectionString());

            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("funkytavlor");
            List<DynamicTableEntity> entities = table.ExecuteQuery(new TableQuery()).ToList();
            return entities;
        }

        public static void AddArtwork(Artwork model)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_databaseHelper.GetConnectionString());

            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            //    ConfigurationManager.AppSettings["StorageConnectionString"]);

            //Create the table client
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            //Create the CloudTable object with your table reference
            CloudTable table;
            table = tableClient.GetTableReference("funkytavlor");

            Artwork fiktivArtwork = new Artwork()
            {
                Title = "MvcArtStoneFirstPainting",
                AddedDate = DateTime.UtcNow.Date,
                Artist = "Daniil",
                CreationDate = DateTime.UtcNow.Date, //TODO bildens skapningstid
                Description = "First painting from the mvc project",
                Id = 15,
                InStorage = 0,
                PartitionKey = "MvcArtStoneFirstPainting",
                RowKey = "15",
            };

        //create the tableoperation object that inserts the customer entity
        TableOperation insertOperation = TableOperation.Insert(fiktivArtwork);

        //execute the insert operation,
        table.Execute(insertOperation);


        //throw new NotImplementedException();
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
