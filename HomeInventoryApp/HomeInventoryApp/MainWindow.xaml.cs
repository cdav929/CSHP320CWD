using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HomeInventoryApp.Models;
using System.Drawing;

namespace HomeInventoryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadContacts();
        }

        private InventoryItemsModel selectedContact;

        private void uxItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedContact = (InventoryItemsModel)uxItemList.SelectedValue;
            uxContextFileDelete.IsEnabled = (selectedContact != null);
        }
        private void LoadContacts()
        {
            var contacts = App.HomeInventoryRepository.GetAll();

            uxItemList.ItemsSource = contacts
                .Select(t => InventoryItemsModel.ToModel(t))
                .ToList();

           
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new HomeInventoryWindow();

            if (window.ShowDialog() == true)
            {
                var uiContactModel = window.Contact;

                var repositoryContactModel = uiContactModel.ToRepositoryModel();

                App.HomeInventoryRepository.Add(repositoryContactModel);

                LoadContacts();

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());
            }
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            {
                App.HomeInventoryRepository.Remove(selectedContact.Id);
                selectedContact = null;
                LoadContacts();
            }
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedContact != null);
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new HomeInventoryWindow();
            //window.Contact = selectedContact.Clone();
            window.Contact = selectedContact;

            if (window.ShowDialog() == true)
            {
                App.HomeInventoryRepository.Update(window.Contact.ToRepositoryModel());
                LoadContacts();
            }
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedContact != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void uxItemList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // call on this filechange click function with two null parameters
            uxFileChange_Click(sender, null);

        }


    }
}
