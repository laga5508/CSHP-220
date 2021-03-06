﻿using System;
using System.Collections.Generic;
using System.Text;
using ObstacleDb;
using System.Linq;

namespace ObstacleRepository
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
                ObsStudy = obstacleModel.ObsStudy,
                ObsType = obstacleModel.ObsType,
                ObsLongitudeDms = obstacleModel.ObsLongitudeDms,
                ObsLatitudeDms = obstacleModel.ObsLongitudeDms,
                ObsLatitudeHemisphere = obstacleModel.ObsLatitudeHemisphere,
                ObsLongitudeHemisphere = obstacleModel.ObsLongitudeHemisphere,
                ObsAglHeight = obstacleModel.ObsAglHeight,
                ObsMslHeight = obstacleModel.ObsMslHeight,
                ObstLatitudeDd = obstacleModel.ObsLongitudeDd,
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
                  ObsStudy = t.ObsStudy,
                  ObsType = t.ObsType,
                  ObsLatitudeDms = t.ObsLatitudeDms,
                  ObsLongitudeDms = t.ObsLongitudeDms,
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
            var original = DatabaseManager.Instance.Obstacle.Find(obstacleModel.ObsStudy);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(obstacleModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(string obsStudy)
        {
            var items = DatabaseManager.Instance.Obstacle
                                .Where(t => t.ObsStudy == obsStudy);

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
                ObsStudy = obstacleModel.ObsStudy,
                ObsType = obstacleModel.ObsType,
                ObsLongitudeDms = obstacleModel.ObsLongitudeDms,
                ObsLatitudeDms = obstacleModel.ObsLongitudeDms,
                ObsLatitudeHemisphere = obstacleModel.ObsLatitudeHemisphere,
                ObsLongitudeHemisphere = obstacleModel.ObsLongitudeHemisphere,
                ObsAglHeight = obstacleModel.ObsAglHeight,
                ObsMslHeight = obstacleModel.ObsMslHeight,
                ObstLatitudeDd = obstacleModel.ObsLongitudeDd,
                ObsLongitudeDd = obstacleModel.ObsLongitudeDd,
                ObsIcao = obstacleModel.ObsIcao
            };

            return contactDb;
        }
    }
}
