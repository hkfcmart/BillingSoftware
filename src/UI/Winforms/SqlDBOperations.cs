using SelfServicedDataBase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winforms
{
    public static class SqlDBOperations
    {
        public static SqlConnection OpenSQLConnections()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Project\HKFC MART Billing Projects\WinForms\HkfcMartBilling\src\dataAccess\SelfServicedDataBase\bin\Debug\net5.0\LoginDetails.mdf;Integrated Security=True;Connect Timeout=30";
            LoginData loginData = new();
            SqlConnection sqlConnection = loginData.GetSqlConnection(connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
