using DEV.Utils;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DEV.Data.Resources
{
    public class ConnectionFactory
    {
        public static SqlConnection GetConnection(string cnn = "DBConnection")
        {
            var settings = ConfigHelper.GetConfig();
            var connectionString = settings.GetConnectionString(cnn);
            var connection = new SqlConnection(connectionString);

            return connection;
        }

        public static void CloseConnection(SqlConnection connection)
        {
            connection.Dispose();
            connection.Close();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
