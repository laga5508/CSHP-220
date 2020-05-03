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

namespace Homework_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void uxPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            string usPattern = @"^[0-9]{5}(?:-[0-9]{4})?$";
            string CanPattern = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";
            Regex us = new Regex(usPattern);
            Regex Can = new Regex(CanPattern);


            if (us.IsMatch(uxPhoneNumber.Text) || Can.IsMatch(uxPhoneNumber.Text))
            {
                uxSubmitBtn.IsEnabled = true;
                uxZipBorder.BorderThickness = new Thickness(0);
            }
            else
            {
                uxSubmitBtn.IsEnabled = false;
                uxZipBorder.BorderThickness = new Thickness(3);
            }

        }
    }
}
