using System;
using System.Collections.Generic;
using System.Text;

namespace HomeInventoryApp.Models
{
    public class InventoryItemsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public string PurchaseLocation { get; set; }
        public decimal Price { get; set; }
        public int WarrantyLength { get; set; }
        public string Notes { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime PurchaseDate { get; set; }


        //internal InventoryItemsModel Clone()
        //{
        //    return (InventoryItemsModel)this.MemberwiseClone();
        //}
        public HomeInventoryRepository.InventoryItemsModel ToRepositoryModel()
        {
            var repositoryModel = new HomeInventoryRepository.InventoryItemsModel
            {
                Id = Id,
                CreatedDate = CreatedDate,
                Name = Name,
                Brand = Brand,
                ModelNumber = ModelNumber,
                Notes = Notes,
                SerialNumber = SerialNumber,
                PurchaseDate = PurchaseDate,
                PurchaseLocation = PurchaseLocation,
                Price = Price,
                WarrantyLength = WarrantyLength,
            };

            return repositoryModel;
        }

        public static InventoryItemsModel ToModel(HomeInventoryRepository.InventoryItemsModel repositoryModel)
        {
            var inventoryItemsModel = new InventoryItemsModel
            {
                Id = repositoryModel.Id,
                CreatedDate = repositoryModel.CreatedDate,
                Name = repositoryModel.Name,
                Brand = repositoryModel.Brand,
                ModelNumber = repositoryModel.ModelNumber,
                Notes = repositoryModel.Notes,
                SerialNumber = repositoryModel.SerialNumber,
                PurchaseDate = repositoryModel.PurchaseDate,
                PurchaseLocation = repositoryModel.PurchaseLocation,
                Price = repositoryModel.Price,
                WarrantyLength = repositoryModel.WarrantyLength,
            };

            return inventoryItemsModel;
        }
    }
}
