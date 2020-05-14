using ObstacleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ObstacleApp
{
    /// <summary>
    /// Interaction logic for ObstacleWindow.xaml
    /// </summary>
    public partial class ObstacleWindow : Window
    {
        public ObstacleWindow()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }
        public ObstacleModel Obstacle { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            Obstacle = new ObstacleModel();
            Obstacle.ObsStudy = uxObsStudy.Text;
            Obstacle.ObsType = uxObsType.Text;
            Obstacle.ObsLatitudeDms = double.Parse(uxObsLatDms.Text);
            Obstacle.ObsLongitudeDms = double.Parse(uxObsLatDms.Text);
            //Obstacle.ObstLatitudeDd = double.Parse(uxLatDD.Text);
            //Obstacle.ObsLongitudeDd = double.Parse(uxLonDD.Text);
            Obstacle.ObsLongitudeHemisphere = uxLonHem.Text;
            Obstacle.ObsLatitudeHemisphere = uxLatHem.Text;
            Obstacle.ObsAglHeight = int.Parse(uxAglHeight.Text);
            Obstacle.ObsMslHeight = int.Parse(uxMslHeight.Text);
            Obstacle.ObsIcao = uxIcao.Text;
            

            // This is the return value of ShowDialog( ) below
            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = false;
            Close();
        }

    }
}
