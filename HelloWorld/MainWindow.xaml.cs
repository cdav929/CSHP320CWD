//UWNetID: chrisd94
//Name:    Christopher Davenport
//Class CSHP320 A Sp 21: Creating Client Applications Using .Net Core



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
using Microsoft.EntityFrameworkCore;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.User user = new Models.User();
        public MainWindow()
        {
            InitializeComponent();
            uxContainer.DataContext = user;

            var sample = new SampleContext();
            
            sample.User.Load();
            var users = sample.User.Local.ToObservableCollection();
            uxList.ItemsSource = users;
            uxName.DataContext = user;
            uxNameError.DataContext = user;
            uxPassword.DataContext = user;
            uxPasswordError.DataContext = user;
        }

        private void SetButton()
        {
           if (uxName.Text != "" && uxPassword.Text != "")
                {
                uxSubmit.IsEnabled = true;
            }
            else 
            {
                uxSubmit.IsEnabled = false;
            }
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password:" + uxPassword.Text);
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }
    }
}
