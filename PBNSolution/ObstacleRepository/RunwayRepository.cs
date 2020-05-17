using System;
using System.Collections.Generic;
using System.Text;
using ObstacleDb;
using System.Linq;

namespace ObstacleRepository
{

    public partial class RunwayModel
    {
        public string Icao { get; set; }
        public string RWY { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
    class RunwayRepository
    {
        public RunwayModel Add(RunwayModel runwayModel)
        {
            var runwayDb = ToDbModel(runwayModel);

            DatabaseManager.Instance.Runway.Add(runwayDb);
            DatabaseManager.Instance.SaveChanges();

            runwayModel = new RunwayModel
            {
                RWY = runwayModel.RWY,
                Icao = runwayModel.Icao,
                Lat = runwayModel.Lat,
                Long = runwayModel.Long            

            };
            return runwayModel;
        }

        public List<RunwayModel> GetAll()
        {
            // Use .Select() to map the database contacts to ContactModel
            var items = DatabaseManager.Instance.Runway
              .Select(t => new RunwayModel
              {
                  RWY = t.RWY,
                  Icao = t.Icao,
                  Lat = t.Lat,
                  Long = t.Long
              }).ToList();

            return items;
        }

        public bool Update(RunwayModel runwayModel)
        {
            var original = DatabaseManager.Instance.Obstacle.Find(runwayModel.Icao);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(runwayModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(string Icao)
        {
            var items = DatabaseManager.Instance.Runway
                                .Where(t => t.Icao == Icao);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Runway.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Runway ToDbModel(RunwayModel runwayModel)
        {
            var runwayDb = new Runway
            {
                RWY = runwayModel.RWY,
                Icao = runwayModel.Icao,
                Lat = runwayModel.Lat,
                Long = runwayModel.Long
            };

            return runwayDb;
        }
    }
}

