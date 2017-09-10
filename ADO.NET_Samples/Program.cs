using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ADO.NET_Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            //SelectUsingNoStoredProc();
            //SelectUsingStoredProc();
            //SelectWithParamUsingNoStoredProc();
            //Select.SelectWithParamUsingStoredProc();

            //Insert.InsertUsingNoStoredProc();
            //Insert.InsertUsingStoredProc();

            //Update.UpdateUsingNoStoredProc();
            //Update.UpdateUsingStoredProc();

            //Delete.DeleteUsingNoStoredProc();
            Delete.DeleteUsingStoredProc();

            Console.ReadKey();
        }


    }
}
