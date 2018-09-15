using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfGroceryStores.Models
{

    class ConnectBD
    {
      
        private static SqlConnection thisConnection;

        private ConnectBD() { }

        public static SqlConnection Connect
        {
            get
            {
                try
                {
                    thisConnection = new SqlConnection("Server = (local); Database = DB_NetworkOfGroceryStores; Uid = sa; Pwd = 11111111;");
                    thisConnection.Open();
                    Console.WriteLine("COMPLETED");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR:  " + ex);
                }
                return thisConnection;
            } 
        }
    }


}
