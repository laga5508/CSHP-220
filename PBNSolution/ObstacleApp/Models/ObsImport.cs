using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ObstacleApp.Models
{
    class ObsImport
    {

        public static List<ObstacleModel> GetObsFromFile(string fileName)
        {
            var runways = App.RunwayRepsitory.GetAll();
            string[] readText = File.ReadAllLines(fileName);
            int NumberOfLines = readText.Length;
            List<ObstacleModel> ObstaclesWithin30 = new List<ObstacleModel>();

            for (int i = 4; i < NumberOfLines; i++)
            {
                string obsRecLine = readText[i];
                if (obsRecLine.Substring(0, 3) != "OLD")
                {
                    double ObsLat = Conversions.ConvertPosition(double.Parse(obsRecLine.Substring(45, 2) + obsRecLine.Substring(48, 2) + obsRecLine.Substring(51, 5)));
                    double ObsLon = Conversions.ConvertPosition(double.Parse(obsRecLine.Substring(58, 3) + obsRecLine.Substring(62, 2) + obsRecLine.Substring(65, 5)));

                  

                    foreach (var rwy in runways)
                    {

                        double result = Inverse.invcalc(rwy.Lat, rwy.Long, ObsLat, ObsLon).xmeters / 1852;
                        if (result < 30)
                        {

                           
                            ObstacleModel NewObstacle = new ObstacleModel()
                            {
                                ObsStudy = obsRecLine.Substring(10, 9),
                                ObsType = obsRecLine.Substring(72, 18).TrimEnd(),
                                ObsMslHeight = int.Parse(obsRecLine.Substring(99, 5)),
                                ObsLatitudeHemisphere = obsRecLine.Substring(56, 1),
                                ObsLongitudeHemisphere = obsRecLine.Substring(70, 1),
                                ObsLatitudeDms = double.Parse(obsRecLine.Substring(45, 2) + obsRecLine.Substring(48, 2) + obsRecLine.Substring(51, 5)),
                                ObsLongitudeDms = double.Parse(obsRecLine.Substring(58, 3) + obsRecLine.Substring(62, 2) + obsRecLine.Substring(65, 5)),
                                ObsStatus = obsRecLine.Substring(0, 3),
                                ObsIcao = rwy.Icao
                            };

                            NewObstacle.ObsLatitudeDd = Conversions.ConvertPosition(NewObstacle.ObsLatitudeDms);
                            NewObstacle.ObsLongitudeDd = Conversions.ConvertPosition(NewObstacle.ObsLongitudeDms);
                           
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
