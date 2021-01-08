// Namespace handling MySQL connections
using MySql.Data.MySqlClient;
using System;

// Namespace enabling import from App.config
using System.Configuration;

namespace Hangman
{
    class DbConnection
    {
        // MySQL connection string
        public static string connAtr = ConfigurationManager.AppSettings["MySqlConnectionString"];

        // Preparing the SQL connection
        public MySqlConnection conn = new MySqlConnection(connAtr);

        // Method connecting to MySQL and executing query
        public MySqlDataReader getReader(String sql, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
