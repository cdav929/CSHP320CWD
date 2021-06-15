using System;
using System.Collections.Generic;

namespace InventoryItemsDB
{
    public partial class InventoryItems
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemBrand { get; set; }
        public string ItemModelNumber { get; set; }
        public string ItemSerialNumber { get; set; }
        public DateTime? ItemDatePurchased { get; set; }
        public string ItemPurchaseLocation { get; set; }
        public decimal? ItemPrice { get; set; }
        public int? ItemWarrantylength { get; set; }
        public string ItemNotes { get; set; }
        public DateTime ItemAddedDate { get; set; }
    }
}
