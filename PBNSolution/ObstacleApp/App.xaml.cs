using ObstacleRepository;
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
        private static ObstacleRepository.RunwayRepsitory runwayRepsitory;


        static App()
        {
            obstacleRepository = new ObstacleRepository.ObstacleRepository();
            runwayRepsitory = new ObstacleRepository.RunwayRepsitory();
        }
            

        public static ObstacleRepository.ObstacleRepository ObstacleRepository
        {
            get
            {
                return obstacleRepository;
            }

        }

        public static ObstacleRepository.RunwayRepsitory RunwayRepsitory
        {
            get
            {
                return runwayRepsitory;
            }
        }
    }
}
