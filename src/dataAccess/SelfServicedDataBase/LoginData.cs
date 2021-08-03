using System;
using System.Data.SqlClient;

namespace SelfServicedDataBase
{
    public class LoginData
    {
        public void login()
        {
            string strSettingsXmlFilePath = GetDatabaseFilePath();
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + strSettingsXmlFilePath + ";Integrated Security=True";
            SqlConnection sqlConnection = GetSqlConnection(connectionString);
            sqlConnection.Open();
        }

        private static string GetDatabaseFilePath()
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
            string strSettingsXmlFilePath = System.IO.Path.Combine(strWorkPath, "LoginDetails.mdf");
            return strSettingsXmlFilePath;
        }

        public SqlConnection GetSqlConnection(string connectionstring)
        {
            return new SqlConnection(connectionstring);
        }
    }
}
