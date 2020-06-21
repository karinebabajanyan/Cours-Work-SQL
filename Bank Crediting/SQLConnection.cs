using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Crediting
{
    class SQLConnection
    {
        public static SqlConnection connect()
        {
            SqlConnection conn = new SqlConnection("Server=localhost; Database=BankCrediting;Trusted_Connection=True;");
            return conn;
        }
    }
}
