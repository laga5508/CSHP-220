using System;
using System.Collections.Generic;
using System.Text;
using ObstacleDb;

namespace ObstacleRepository
{
   public static class DatabaseManager
    {
        private static readonly PBNContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new PBNContext();
        }

        // Provide an accessor to the database
        public static PBNContext Instance
        {
            get
            {
                return entities;
            }
        }

    }
}
