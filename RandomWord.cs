// Namespace handling MySQL connections
using MySql.Data.MySqlClient;
using System;

// Namespace enabling DataTable
using System.Data;

namespace Hangman
{
    class RandomWord
    {
        // MySQL connection string
        DbConnection DbConn = new DbConnection();

        // Preparing a data table to store MySQL result
        private DataTable dataTable = new DataTable();

        // Constructor to fetch values from MySQL and store them in a data table
        public RandomWord()
        {
            try
            {
                Console.WriteLine("Ansluter till MySQL och hämtar ett slumpat ord...\n");
                DbConn.conn.Open();

                // SQL Query to execute
                String sql = "select * from dt071g_project;";
                MySqlDataReader reader = DbConn.getReader(sql, DbConn.conn);

                // Save MySQL values to DataTable
                dataTable.Load(reader);

                reader.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            DbConn.conn.Close();
        }

        // Method to get random word
        public String getRandomWord()
        {
            // Create instance of Random
            Random randomNumber = new Random();

            // Get length of data table and choose a random number from that range 
            int index = randomNumber.Next(dataTable.Rows.Count);

            // Select word from data table with the index corresponding to the random number
            String word = dataTable.Rows[index].Field<String>("word");
            return word;
        }
    }
}
