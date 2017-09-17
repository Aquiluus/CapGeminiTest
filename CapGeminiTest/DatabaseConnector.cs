using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapGeminiTest
{
    public class DatabaseConnector
    {

        private CGTDataEntities database; 
        private static DatabaseConnector DatabaseConnectorInstance;

        private DatabaseConnector()
        {
            database = new CGTDataEntities();
        }

        public static DatabaseConnector GetInstance()
        {
            if (DatabaseConnectorInstance == null)
            {
                DatabaseConnectorInstance = new DatabaseConnector();
            }
            return DatabaseConnectorInstance;
        }

        public CGTDataEntities Database
        {
            get { return database; }
        }

    }
}