using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Win32;

namespace ObstacleApp.Models
{
    static class GoogleEarth
    {
        public static StringBuilder printObstacle = new StringBuilder();


        public static void printToGoogleEarth(ObstacleModel obstacle)
        {
            string ObsStudy = obstacle.ObsStudy;
            string ObsType = obstacle.ObsType;
            int ObsAglHeight = obstacle.ObsAglHeight;
            int ObsMslHeight = obstacle.ObsMslHeight;
            double ObsLatDd = obstacle.ObsLatitudeDd;
            double ObsLonDd = obstacle.ObsLongitudeDd;

           
            printObstacle.AppendLine(
                "<?xml version=\"1.0\" encoding = \"UTF-8\"?>"
                + "<kml xmlns=\"http://www.opengis.net/kml/2.2\">"
                + $"<Document> <Placemark><name>{ObsStudy}</name>"
                + $"<description><![CDATA[<h1>{ObsType}</h1>"
                + $"<p>AGL: {ObsAglHeight} </p>"
                + $"<p>MSL: {ObsMslHeight}</p>]]></description>"
                + $"<Point><coordinates>-{ObsLonDd}, {ObsLatDd}</coordinates></Point>"
                + "</Placemark></Document></kml>"
                );
         
            string fileName = string.Format($"{ObsStudy}.kml");
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SaveFile.Filter = "Google Earth files (*.kml)|*.kml|All files (*.*)|*.*";
            SaveFile.FileName = fileName;
            if (SaveFile.ShowDialog() == true)
            {
                File.WriteAllText(fileName, printObstacle.ToString());

            }

        }

    }
}
