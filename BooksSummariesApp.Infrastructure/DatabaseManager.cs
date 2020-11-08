using Couchbase.Lite;
using System;
using System.IO;

namespace BooksSummariesApp.Infrastructure
{
    public class DatabaseManager
    {
        private Database _database;

        public Database GetDatabase()
        {
            if (_database == null)
            {
                var databaseConfig = new DatabaseConfiguration
                {
                    Directory =
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "BooksDB")
                };

                _database = new Database("BooksDB", databaseConfig);
            }

            return _database;
        }
    }
}
