





using InventoryItemsDB;
using System.Collections.Generic;
using System.Linq;



namespace HomeInventoryRepository
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
    }

    public class HomeInventoryRepository
    {
        public InventoryItemsModel Add(InventoryItemsModel inventoryItemsModel)
        {
            var inventoryItemsDb = ToDbModel(inventoryItemsModel);

            DatabaseManager.Instance.InventoryItems.Add(inventoryItemsDb);
            DatabaseManager.Instance.SaveChanges();

            inventoryItemsModel = new InventoryItemsModel
            {
                Id = inventoryItemsDb.ItemId,
                CreatedDate = inventoryItemsDb.ItemAddedDate,
                Name = inventoryItemsDb.ItemName,
                Brand = inventoryItemsDb.ItemBrand,
                ModelNumber = inventoryItemsDb.ItemModelNumber,
                Notes = inventoryItemsDb.ItemNotes,
                SerialNumber = inventoryItemsDb.ItemSerialNumber,
                PurchaseLocation = inventoryItemsDb.ItemPurchaseLocation,
                Price = (decimal)inventoryItemsDb.ItemPrice,
                WarrantyLength = (int)inventoryItemsDb.ItemWarrantylength,
                PurchaseDate = (System.DateTime)inventoryItemsDb.ItemDatePurchased,

            };
            return inventoryItemsModel;
        }

        public List<InventoryItemsModel> GetAll()
        {
            // Use .Select() to map the database contacts to ContactModel
            var items = DatabaseManager.Instance.InventoryItems
              .Select(t => new InventoryItemsModel
              {
                  Id = t.ItemId,
                  CreatedDate = t.ItemAddedDate,
                  Name = t.ItemName,
                  Brand = t.ItemBrand,
                  ModelNumber = t.ItemModelNumber,
                  Notes = t.ItemNotes,
                  SerialNumber = t.ItemSerialNumber,
                  PurchaseLocation = t.ItemPurchaseLocation,
                  Price = (decimal)t.ItemPrice,
                  WarrantyLength = (int)t.ItemWarrantylength,
                  PurchaseDate = (System.DateTime)t.ItemDatePurchased,
              }).ToList();

            return items;
        }
        
        public bool Update(InventoryItemsModel inventoryItemsModel)
        {
            var original = DatabaseManager.Instance.InventoryItems.Find(inventoryItemsModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(inventoryItemsModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int itemId)
        {
            var items = DatabaseManager.Instance.InventoryItems
                                .Where(t => t.ItemId == itemId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.InventoryItems.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private InventoryItems ToDbModel(InventoryItemsModel inventoryItemsModel)
        {
            var inventoryItemsDb = new InventoryItems
            {
                ItemId = inventoryItemsModel.Id,
                ItemAddedDate = inventoryItemsModel.CreatedDate,
                ItemName = inventoryItemsModel.Name,
                ItemBrand = inventoryItemsModel.Brand,
                ItemModelNumber = inventoryItemsModel.ModelNumber,
                ItemSerialNumber = inventoryItemsModel.SerialNumber,
                ItemDatePurchased = inventoryItemsModel.PurchaseDate,
                ItemPurchaseLocation = inventoryItemsModel.PurchaseLocation,
                ItemPrice = inventoryItemsModel.Price,
                ItemWarrantylength = inventoryItemsModel.WarrantyLength,
                ItemNotes = inventoryItemsModel.Notes,
            };

            return inventoryItemsDb;
        }
    }
}