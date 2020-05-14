using System;
using System.Collections.Generic;
using System.Text;

namespace ObstacleApp.Models
{
    class ObsImport
    {
        public static List<ObsRec> GetObsFromFile(string fileName, NavGenDataSet.rwDataTable runways)
        {
            string[] readText = File.ReadAllLines(fileName);
            int NumberOfLines = readText.Length;
            List<ObsRec> ObstaclesWithin30 = new List<ObsRec>();

            for (int i = 4; i < NumberOfLines; i++)
            {
                string obsRecLine = readText[i];
                if (obsRecLine.Substring(0, 3) != "OLD")
                {
                    double ObsLat = Conversions.ConvertPosition(double.Parse(obsRecLine.Substring(45, 2) + obsRecLine.Substring(48, 2) + obsRecLine.Substring(51, 5)));
                    double ObsLon = Conversions.ConvertPosition(double.Parse(obsRecLine.Substring(58, 3) + obsRecLine.Substring(62, 2) + obsRecLine.Substring(65, 5)));

                    foreach (NavGenDataSet.rwRow rwy in runways)
                    {

                        double result = Inverse.invcalc(rwy.lat, rwy.lon, ObsLat, ObsLon).xmeters / 1852;
                        if (result < 30)
                        {

                            
                            ObsRec NewObstacle = new ObsRec()
                            {
                                Study = obsRecLine.Substring(10, 9),
                                Otype = obsRecLine.Substring(72, 18).TrimEnd(),
                                MSL_Height = int.Parse(obsRecLine.Substring(99, 5)),                              
                                Latitude_Hemisphere = obsRecLine.Substring(56, 1),
                                Longitude_hemisphere = obsRecLine.Substring(70, 1),
                                Latitude_DMS = double.Parse(obsRecLine.Substring(45, 2) + obsRecLine.Substring(48, 2) + obsRecLine.Substring(51, 5)),
                                Longitude_DMS = double.Parse(obsRecLine.Substring(58, 3) + obsRecLine.Substring(62, 2) + obsRecLine.Substring(65, 5)),
                                Status = obsRecLine.Substring(0, 3),
                                
                            };

                            NewObstacle.LatitudeDD = Conversions.ConvertPosition(NewObstacle.Latitude_DMS);
                            NewObstacle.Longitude_DD = Conversions.ConvertPosition(NewObstacle.Longitude_DMS);
                            
                           

                            ObstaclesWithin30.Add(NewObstacle);
                            break;

                        }
                    }
                }
            }
            return ObstaclesWithin30;
        }
    }
}
