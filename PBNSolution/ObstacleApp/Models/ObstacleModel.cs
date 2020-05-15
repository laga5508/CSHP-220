using System;
using System.Collections.Generic;
using System.Text;

namespace ObstacleApp.Models
{
    public class ObstacleModel
    {
        public int ObsId { get; set; }
        public string ObsStudy { get; set; }
        public string ObsType { get; set; }
        public double ObsLatitudeDms { get; set; }
        public double ObsLongitudeDms { get; set; }
        public string ObsLatitudeHemisphere { get; set; }
        public string ObsLongitudeHemisphere { get; set; }
        public int ObsAglHeight { get; set; }
        public int ObsMslHeight { get; set; }
        public double ObsLatitudeDd { get; set; }
        public double ObsLongitudeDd { get; set; }
        public string ObsIcao { get; set; }

        public ObstacleRepository.ObstacleModel ToRepositoryModel()
        {
            var repositoryModel = new ObstacleRepository.ObstacleModel
            {
                ObsId = ObsId,
                ObsStudy = ObsStudy,
                ObsType = ObsType,
                ObsLatitudeDms = ObsLatitudeDms,
                ObsLongitudeDms = ObsLongitudeDms,
                ObsLatitudeHemisphere = ObsLatitudeHemisphere,
                ObsLongitudeHemisphere = ObsLongitudeHemisphere,
                ObsAglHeight = ObsAglHeight,
                ObsMslHeight = ObsMslHeight,
                ObsLongitudeDd = ObsLongitudeDd,
                ObstLatitudeDd = ObsLatitudeDd,
                ObsIcao = ObsIcao

            };

            return repositoryModel;
        }

        public static ObstacleModel ToModel(ObstacleRepository.ObstacleModel repositoryModel)
        {
            var obstacleModel = new ObstacleModel
            {
                ObsId = repositoryModel.ObsId,
                ObsStudy = repositoryModel.ObsStudy,
                ObsType = repositoryModel.ObsType,
                ObsLatitudeDms = repositoryModel.ObsLatitudeDms,
                ObsLongitudeDms = repositoryModel.ObsLongitudeDms,
                ObsLatitudeHemisphere = repositoryModel.ObsLatitudeHemisphere,
                ObsLongitudeHemisphere = repositoryModel.ObsLongitudeHemisphere,
                ObsAglHeight = repositoryModel.ObsAglHeight,
                ObsMslHeight = repositoryModel.ObsMslHeight,
                ObsLatitudeDd = repositoryModel.ObstLatitudeDd,
                ObsLongitudeDd = repositoryModel.ObsLongitudeDd,
                ObsIcao = repositoryModel.ObsIcao
            };

            return obstacleModel;
        }
    }
}
