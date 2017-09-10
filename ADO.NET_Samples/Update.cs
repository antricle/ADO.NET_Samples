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
    public static class Update
    {
        /// <summary>
        /// Insert without using a stored proc
        /// </summary>
        public static void UpdateUsingNoStoredProc()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string qry = "UPDATE tblNews SET Title = @Title WHERE NewsID = @NewsID";

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(qry, connection);
                    command.Parameters.AddWithValue("@title", "Title updated");
                    command.Parameters.AddWithValue("@NewsID", 1);
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
        /// Update using stored proc
        /// </summary>
        public static void UpdateUsingStoredProc()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (var connection = new SqlConnection(connString))
            {
                var command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "uspUpdateNews";
                command.Connection = connection;

                command.Parameters.AddWithValue("@title", "Title updated again");
                command.Parameters.AddWithValue("@newsID", 1);

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
