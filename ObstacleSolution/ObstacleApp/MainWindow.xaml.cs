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
using System.IO;
using Microsoft.Win32;

namespace ObstacleApp
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

        private void uxImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ImportFile = new OpenFileDialog();
            ImportFile.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
            Nullable<bool> result = ImportFile.ShowDialog();

            if (result == true)
            {
                string fileName = ImportFile.FileName;
                
            }
        }

        private void uxAbout_Click(object sender, RoutedEventArgs e)
        {
            string message = "Mark La Gasse" + Environment.NewLine + "Alaska Airlines";
            MessageBox.Show(message);
        }

        private void uxClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void uxNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new ObstacleWindow();
            if (window.ShowDialog() == true)
            {
                var UiObstacleModel = window.Obstacle;

                var repositoryObstacleModel = UiObstacleModel.ToRepositoryModel();
                App.ContactRepository.Add(repositoryObstacleModel);
               
                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());
            }
        }
    }
}
