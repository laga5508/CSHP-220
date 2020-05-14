using System;
using System.Collections.Generic;

namespace ObstacleDb
{
    public partial class Obstacle
    {
        public string ObsStudy { get; set; }
        public string ObsType { get; set; }
        public double? ObsLatitudeDms { get; set; }
        public double? ObsLongitudeDms { get; set; }
        public string ObsLatitudeHemisphere { get; set; }
        public string ObsLongitudeHemisphere { get; set; }
        public int? ObsAglHeight { get; set; }
        public int? ObsMslHeight { get; set; }
        public double? ObstLatitudeDd { get; set; }
        public double? ObsLongitudeDd { get; set; }
        public string ObsIcao { get; set; }
    }
}
