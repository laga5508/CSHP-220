﻿using System;
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
using ObstacleApp.Models;
using System.ComponentModel;

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
            LoadObstacles();
        }

        private void LoadObstacles()
        {
            var obstacles = App.ObstacleRepository.GetAll();
            uxObstacleList.ItemsSource = obstacles.Select(t => ObstacleModel.ToModel(t)).ToList();

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
                App.ObstacleRepository.Add(repositoryObstacleModel);

                LoadObstacles();
                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());
            }
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.ObstacleRepository.Remove(selectedObstacle.ObsStudy);
            selectedObstacle = null;
            LoadObstacles();
            
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedObstacle != null);
            uxContextFileDelete.IsEnabled = uxFileDelete.IsEnabled;
        }



        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            var column = (sender as GridViewColumnHeader);

            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                uxObstacleList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
            {
                newDir = ListSortDirection.Descending;
            }

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            uxObstacleList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
            uxObstacleList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        private ObstacleModel selectedObstacle;
        private void uxObstacleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedObstacle = (ObstacleModel)uxObstacleList.SelectedValue;
        }

        
    }
}
