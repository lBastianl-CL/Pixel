using System;
using MySql.Data.MySqlClient;
using Pixel.Server.Core.Managers;
using Pixel.Server.Database.Interfaces;

namespace Pixel.Server.Database
{
    public sealed class DatabaseManager
    {
        private static string _connectionStr;

        public static void Load()
        {
            var cS = new MySqlConnectionStringBuilder
            {
                ConnectionTimeout = 10,
                Database = ConfigManager.GetString("mysql.database"),
                DefaultCommandTimeout = 30,
                Logging = false,
                MaximumPoolSize = uint.Parse(ConfigManager.GetString("mysql.pool.max")),
                MinimumPoolSize = uint.Parse(ConfigManager.GetString("mysql.pool.min")),
                Password = ConfigManager.GetString("mysql.password"),
                Pooling = true,
                Port = uint.Parse(ConfigManager.GetString("mysql.port")),
                Server = ConfigManager.GetString("mysql.host"),
                UserID = ConfigManager.GetString("mysql.user"),
                AllowZeroDateTime = true,
                ConvertZeroDateTime = true,
                SslMode = MySqlSslMode.None
            };

            _connectionStr = cS.GetConnectionString(true);
        }

        public static bool IsConnected()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(_connectionStr);
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT 1+1";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                con.Close();
            }
            catch (MySqlException)
            {
                return false;
            }

            return true;
        }

        public static IQueryAdapter GetQueryReactor()
        {
            try
            {
                IDatabaseClient dbConnection = new DatabaseConnection(_connectionStr);

                dbConnection.Connect();

                return dbConnection.GetQueryReactor();
            }
            catch (Exception e)
            {
                Logger.Error(e.ToString());
                return null;
            }
        }
    }
}
