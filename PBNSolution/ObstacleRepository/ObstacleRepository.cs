using System;
using System.Collections.Generic;
using System.Text;
using ObstacleDb;
using System.Linq;

namespace ObstacleRepository
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
        public double ObstLatitudeDd { get; set; }
        public double ObsLongitudeDd { get; set; }
        public string ObsIcao { get; set; }
    }

    public class ObstacleRepository
    {
        public ObstacleModel Add(ObstacleModel obstacleModel)
        {
            var obstacleDb = ToDbModel(obstacleModel);

            DatabaseManager.Instance.Obstacle.Add(obstacleDb);
            DatabaseManager.Instance.SaveChanges();

            obstacleModel = new ObstacleModel
            {
                ObsId = obstacleModel.ObsId,
                ObsStudy = obstacleModel.ObsStudy,
                ObsType = obstacleModel.ObsType,
                ObsLongitudeDms = obstacleModel.ObsLongitudeDms,
                ObsLatitudeDms = obstacleModel.ObsLatitudeDms,
                ObsLatitudeHemisphere = obstacleModel.ObsLatitudeHemisphere,
                ObsLongitudeHemisphere = obstacleModel.ObsLongitudeHemisphere,
                ObsAglHeight = obstacleModel.ObsAglHeight,
                ObsMslHeight = obstacleModel.ObsMslHeight,
                ObstLatitudeDd = obstacleModel.ObstLatitudeDd,
                ObsLongitudeDd = obstacleModel.ObsLongitudeDd,
                ObsIcao = obstacleModel.ObsIcao


            };
            return obstacleModel;
        }

        public List<ObstacleModel> GetAll()
        {
            // Use .Select() to map the database contacts to ContactModel
            var items = DatabaseManager.Instance.Obstacle
              .Select(t => new ObstacleModel
              {
                  ObsId = t.ObsId,
                  ObsStudy = t.ObsStudy,
                  ObsType = t.ObsType,
                  ObsLatitudeDms = t.ObsLatitudeDms,
                  ObsLongitudeDms = t.ObsLongtitudeDms,
                  ObsLatitudeHemisphere = t.ObsLatitudeHemisphere,
                  ObsLongitudeHemisphere = t.ObsLongitudeHemisphere,
                  ObsAglHeight = t.ObsAglHeight,
                  ObsMslHeight = t.ObsMslHeight,
                  ObsLongitudeDd = t.ObsLongitudeDd,
                  ObstLatitudeDd = t.ObstLatitudeDd,
                  ObsIcao = t.ObsIcao,
              }).ToList();

            return items;
        }

        public bool Update(ObstacleModel obstacleModel)
        {
            var original = DatabaseManager.Instance.Obstacle.Find(obstacleModel.ObsId);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(obstacleModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int ObsId)
        {
            var items = DatabaseManager.Instance.Obstacle
                                .Where(t => t.ObsId == ObsId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Obstacle.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Obstacle ToDbModel(ObstacleModel obstacleModel)
        {
            var contactDb = new Obstacle
            {
                ObsId = obstacleModel.ObsId,
                ObsStudy = obstacleModel.ObsStudy,
                ObsType = obstacleModel.ObsType,
                ObsLongtitudeDms = obstacleModel.ObsLongitudeDms,
                ObsLatitudeDms = obstacleModel.ObsLatitudeDms,
                ObsLatitudeHemisphere = obstacleModel.ObsLatitudeHemisphere,
                ObsLongitudeHemisphere = obstacleModel.ObsLongitudeHemisphere,
                ObsAglHeight = obstacleModel.ObsAglHeight,
                ObsMslHeight = obstacleModel.ObsMslHeight,
                ObstLatitudeDd = obstacleModel.ObstLatitudeDd,
                ObsLongitudeDd = obstacleModel.ObsLongitudeDd,
                ObsIcao = obstacleModel.ObsIcao
            };

            return contactDb;
        }
    }
}