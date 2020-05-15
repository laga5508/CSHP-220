using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ObstacleApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ObstacleRepository.ObstacleRepository obstacleRepository;

        static App()
        {
            obstacleRepository = new ObstacleRepository.ObstacleRepository();
        }

        public static ObstacleRepository.ObstacleRepository ObstacleRepository
        {
            get
            {
                return obstacleRepository;
            }

        }
    }
}
