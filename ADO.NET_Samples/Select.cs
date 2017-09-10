using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ADO.NET_Samples
{
    public static class Select
    {
        /// <summary>
        /// Select statement without using stored proc
        /// </summary>
        public static void SelectUsingNoStoredProc()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string qry = "SELECT * FROM tblNews";

            using (var connection = new SqlConnection(connString))
            {
                var command = new SqlCommand(qry, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("NewsID: " + reader["NewsID"]);
                        Console.WriteLine("Title: " + reader["Title"]);
                        Console.WriteLine("Description: " + reader["Description"]);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                }

            }
        }

        /// <summary>
        /// Select statement using stored proc
        /// </summary>
        public static void SelectUsingStoredProc()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (var connection = new SqlConnection(connString))
            {
                var command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetAllNews";
                command.Connection = connection;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("NewsID: " + reader["NewsID"]);
                        Console.WriteLine("Title: " + reader["Title"]);
                        Console.WriteLine("Description: " + reader["Description"]);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                }

            }
        }

        /// <summary>
        /// Select using WHERE without stored proc
        /// </summary>
        public static void SelectWithParamUsingNoStoredProc()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string qry = "SELECT * FROM tblNews WHERE NewsID = @NewsID";

            using (var connection = new SqlConnection(connString))
            {
                var command = new SqlCommand(qry, connection);
                command.Parameters.AddWithValue("@NewsID", 1);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("NewsID: " + reader["NewsID"]);
                        Console.WriteLine("Title: " + reader["Title"]);
                        Console.WriteLine("Description: " + reader["Description"]);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                }

            }
        }

        /// <summary>
        /// Select using WHERE with stored proc
        /// </summary>
        public static void SelectWithParamUsingStoredProc()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (var connection = new SqlConnection(connString))
            {
                var command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "uspGetNewsByID";
                command.Parameters.Add("@NewsID", SqlDbType.Int).Value = 1;
                command.Connection = connection;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine("NewsID: " + reader["NewsID"]);
                        Console.WriteLine("Title: " + reader["Title"]);
                        Console.WriteLine("Description: " + reader["Description"]);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                }

            }
        }
    }
}
