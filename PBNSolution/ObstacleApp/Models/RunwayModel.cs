using System;
using System.Collections.Generic;
using System.Text;

namespace ObstacleApp.Models
{
    public class RunwayModel
    {
        public string Icao { get; set; }
        public string RWY { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
