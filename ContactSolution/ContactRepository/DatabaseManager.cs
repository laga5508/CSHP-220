using ContactDB;

namespace ContactRepository
{
    public static class DatabaseManager
    {
        private static readonly ContactsContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new ContactsContext();
        }

        // Provide an accessor to the database
        public static ContactsContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}