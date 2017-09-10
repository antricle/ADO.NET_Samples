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
    public static class Delete
    {
        /// <summary>
        /// Delete without using a stored proc
        /// </summary>
        public static void DeleteUsingNoStoredProc()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string qry = "Delete from tblNews WHERE NewsID = @NewsID";

            using (var connection = new SqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(qry, connection);
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
        /// Delete using stored proc
        /// </summary>
        public static void DeleteUsingStoredProc()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (var connection = new SqlConnection(connString))
            {
                var command = new SqlCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "uspDeleteNews";
                command.Connection = connection;

                command.Parameters.AddWithValue("@newsID", 2);

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
