
//UWNetID: chrisd94
//Name: Christopher Davenport
//Class: CSHP320 A sp 21: Creating Client Applications using .Net Core
//Homework 4



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
using System.Text.RegularExpressions;

namespace Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled = false;
        }

        private void SetButton()
        {
            
            string zipCodePattern = @"^\d{5}(?:[-\s]\d{4})?$";
            string canZipPattern = @"\A[ABCEGHJKLMNPRSTVXY]\d[A-Z] ?\d[A-Z]\d\z";
           
            bool isZipValid = Regex.IsMatch(uxZip.Text, zipCodePattern);
            bool isCanZipValid = Regex.IsMatch(uxZip.Text, canZipPattern );
             

            if (isZipValid || isCanZipValid)
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
            MessageBox.Show("Submitting zipcode: " + uxZip.Text);
        }

        private void uxZip_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }

       
    }
   
    
}
