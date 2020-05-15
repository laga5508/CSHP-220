using System;
using System.Collections.Generic;

namespace ObstacleDb
{
    public partial class Runway
    {
        public string Icao { get; set; }
        public string Runway1 { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
    }
}
