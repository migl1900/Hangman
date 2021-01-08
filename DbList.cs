// Namespace handling MySQL connections
using MySql.Data.MySqlClient;

// Namespace handling lists
using System.Collections.Generic;
using System;

namespace Hangman
{
    class DbList
    {
        // Creating instance of MySQL connection
        DbConnection DbConn = new DbConnection();

        // Preparing a list for objects
        private List<DbWord> words = new List<DbWord>();

        // Method to get all words from MySQL
        public List<DbWord> getListOfWords()
        {
            try
            {
                DbConn.conn.Open();

                // SQL Query to execute
                String sql = "select * from dt071g_project;";
                MySqlDataReader reader = DbConn.getReader(sql, DbConn.conn);

                // Fill list with id and word as objects
                while (reader.Read())
                {
                    words.Add(new DbWord
                    {
                        Id = (int)reader["id"],
                        Word = reader["word"].ToString()
                    });
                }

                reader.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            DbConn.conn.Close();
            return words;
        }

        // Method to add a word to MySQL
        public DbWord addWord(DbWord word)
        {
            try
            {
                DbConn.conn.Open();

                // SQL Query to execute
                String sql = "insert into dt071g_project (word) values ('" + word.Word + "');";
                MySqlDataReader reader = DbConn.getReader(sql, DbConn.conn);

                reader.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            DbConn.conn.Close();
            return word;
        }

        // Method to delete a word from MySQL, takes id as argument
        public int deleteWord(int id)
        {
            try
            {
                DbConn.conn.Open();

                // SQL Query to execute
                String sql = "delete from dt071g_project Where id = ('" + id + "');";
                MySqlDataReader reader = DbConn.getReader(sql, DbConn.conn);

                reader.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            DbConn.conn.Close();
            return id;
        }
    }
}
