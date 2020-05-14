using System;
using System.Collections.Generic;
using System.Text;

namespace ObstacleApp.Models
{
    public class ObstacleModel
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

        public ObstacleRepository.ObstacleModel ToRepositoryModel()
        {
            var repositoryModel = new ObstacleRepository.ObstacleModel
            {
              ObsStudy = ObsStudy,
              ObsType = ObsType,
              ObsLatitudeDms = ObsLatitudeDms,
              ObsLongitudeDms = ObsLongitudeDms,
              ObsLatitudeHemisphere = ObsLatitudeHemisphere,
              ObsLongitudeHemisphere = ObsLongitudeHemisphere,
              ObsAglHeight = ObsAglHeight,
              ObsMslHeight = ObsMslHeight,
              ObsLongitudeDd = ObstLatitudeDd,
              ObstLatitudeDd = ObstLatitudeDd, 
              ObsIcao = ObsIcao
             
            };

            return repositoryModel;
        }

        public static ObstacleModel ToModel(ObstacleRepository.ObstacleModel repositoryModel)
        {
            var obstacleModel = new ObstacleModel
            {
               ObsStudy = repositoryModel.ObsStudy,
               ObsType = repositoryModel.ObsType,
               ObsLatitudeDms = repositoryModel.ObsLatitudeDms,
               ObsLongitudeDms = repositoryModel.ObsLongitudeDms,
               ObsLatitudeHemisphere = repositoryModel.ObsLatitudeHemisphere,
               ObsLongitudeHemisphere = repositoryModel.ObsLongitudeHemisphere,
               ObsAglHeight = repositoryModel.ObsAglHeight,
               ObsMslHeight = repositoryModel.ObsMslHeight,
               ObstLatitudeDd = repositoryModel.ObstLatitudeDd,
               ObsLongitudeDd = repositoryModel.ObsLongitudeDd,
               ObsIcao = repositoryModel.ObsIcao
            };

            return obstacleModel;
        }
    }
}
