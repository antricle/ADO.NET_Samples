using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Samples
{
    public static class Insert
    {
        /// <summary>
        /// Insert without using a stored proc
        /// </summary>
        public static void InsertUsingNoStoredProc()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string qry = "INSERT INTO tblNews (Title, Description) values(@title, @description)";

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(qry, connection);
                    command.Parameters.AddWithValue("@title", "Title 2");
                    command.Parameters.AddWithValue("@description", "Description 2");
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();

                }
                catch(System.Data.SqlClient.SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Insert using a stored proc
        /// </summary>
        public static void InsertUsingStoredProc()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (var connection = new SqlConnection(connString))
            {
                var command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "uspInsertNews";
                command.Connection = connection;

                command.Parameters.AddWithValue("@title", "Title 3");
                command.Parameters.AddWithValue("@description", "Description 3");

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error");
                }
                finally
                {
                    connection.Close();
                }

            }
        }
    }
}
