using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Component
{
    public abstract class MsSqlConnect
    {
        protected string _connectionString = "";
        protected SqlConnection dbconn;
        protected SqlCommand cmd;
        protected SqlDataReader reader;
        protected SqlParameter parameter;
        protected string sqlCommandString;
        public MsSqlConnect(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void ConnectDB()
        {
           dbconn = new SqlConnection(_connectionString);
            try
            {
                dbconn.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void CloseDB()
        {
            dbconn.Close();
        }
    }
}
