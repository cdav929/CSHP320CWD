using HomeInventoryApp.Models;
using System;
using System.Windows;

namespace HomeInventoryApp
{
    /// <summary>
    /// Interaction logic for ContactWindow.xaml
    /// </summary>
    public partial class HomeInventoryWindow : Window
    {
        public HomeInventoryWindow()
        {
            InitializeComponent();

            // Don't show this window in the task bar
            ShowInTaskbar = false;
        }

        public InventoryItemsModel Contact { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            Contact = new InventoryItemsModel();

            Contact.Name = uxName.Text;
            Contact.Brand = uxBrand.Text;


            Contact.ModelNumber = uxModelNumber.Text;
            Contact.Notes = uxNotes.Text;
            Contact.CreatedDate = DateTime.Now;
            Contact.Price = Convert.ToDecimal(uxPrice.Text);
            Contact.SerialNumber = uxSerial.Text;
            Contact.PurchaseLocation = uxPurchLocation.Text;
            Contact.PurchaseDate = Convert.ToDateTime(uxPurchDate.Text);
            Contact.WarrantyLength = Convert.ToInt32(uxWarranty.Text);



           

            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Contact != null)
            {
              
                uxSubmit.Content = "Update";
            }
            else
            {
                Contact = new InventoryItemsModel();
                Contact.CreatedDate = DateTime.Now;
            }

            uxGrid.DataContext = Contact;
        }
    }
}