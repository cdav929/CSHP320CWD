using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace HomeInventoryApp.Models
{
    public class InventoryItemsModel : IDataErrorInfo, INotifyPropertyChanged
    {
       
        private string nameError { get; set; }

        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // IDataErrorInfo interface
        public string Error => "Never Used";

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        {
                            NameError = "";

                            if (Name == null || string.IsNullOrEmpty(Name))
                            {
                                NameError = "Name cannot be empty.";

                            }
                            else if (Name.Length > 20)
                            {
                                NameError = "Name cannot be longer than 20 characters.";
                            }

                            return NameError;
                        }
                }

                return null;
            }
        }

        public string NameError
        {
            get
            {
                return nameError;
            }
            set
            {
                if (nameError != value)
                {
                    nameError = value;
                    OnPropertyChanged("NameError");
                }
            }
        }



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
