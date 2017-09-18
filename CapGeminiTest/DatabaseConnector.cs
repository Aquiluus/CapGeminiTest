using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapGeminiTest
{
    /// <summary>
    /// Singleton class responsible for connecting to database 
    /// </summary>
    public class DatabaseConnector
    {
        /// <summary>
        /// Parameter holding database connection entity
        /// Initialized in Singleton constructor
        /// </summary>
        private CGTDataEntities database; 

        /// <summary>
        /// Single instance of DatabaseConnector
        /// Makes sure that no other instance of this class will be created
        /// </summary>
        private static DatabaseConnector DatabaseConnectorInstance;

        /// <summary>
        /// Private constructor
        /// Creates connection to a database
        /// </summary>
        private DatabaseConnector()
        {
            database = new CGTDataEntities();
        }

        /// <summary>
        /// Method for getting current instance of DatabaseConnector
        /// If DatabaseConnectorInstance hasn't been initialized, a new one is created
        /// If DatabaseConnectorInstance holds current instance it's just returned
        /// </summary>
        /// <returns>Current class instance</returns>
        public static DatabaseConnector GetInstance()
        {
            if (DatabaseConnectorInstance == null)
            {
                DatabaseConnectorInstance = new DatabaseConnector();
            }
            return DatabaseConnectorInstance;
        }

        /// <summary>
        /// Getter for database parameter
        /// </summary>
        public CGTDataEntities Database
        {
            get { return database; }
        }

    }
}