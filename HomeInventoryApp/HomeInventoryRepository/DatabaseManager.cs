using InventoryItemsDB;

namespace HomeInventoryRepository
{
    public class DatabaseManager
    {
        private static readonly HomeInventoryContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new HomeInventoryContext();
        }

        // Provide an accessor to the database
        public static HomeInventoryContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
