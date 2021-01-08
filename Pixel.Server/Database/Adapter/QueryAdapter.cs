using MySql.Data.MySqlClient;
using Pixel.Server.Database.Interfaces;
using System;
using System.Data;

namespace Pixel.Server.Database.Adapter
{
    public class QueryAdapter : IRegularQueryAdapter
    {
        protected IDatabaseClient Client;
        protected MySqlCommand Command;

        public bool DbEnabled = true;

        public QueryAdapter(IDatabaseClient client)
        {
            Client = client;
        }

        public void AddParameter(string parameterName, object val)
        {
            Command.Parameters.AddWithValue(parameterName, val);
        }

        public bool FindsResult()
        {
            bool hasRows = false;
            try
            {
                using (MySqlDataReader reader = Command.ExecuteReader())
                {
                    hasRows = reader.HasRows;
                }
            }
            catch (Exception exception)
            {
                Logger.Error(Command.CommandText + " - " + exception.ToString());
            }

            return hasRows;
        }

        public int GetInteger()
        {
            int result = 0;
            try
            {
                object obj2 = Command.ExecuteScalar();
                if (obj2 != null)
                {
                    int.TryParse(obj2.ToString(), out result);
                }
            }
            catch (Exception exception)
            {
                Logger.Error(Command.CommandText + " - " + exception.ToString());
            }

            return result;
        }

        public DataRow GetRow
            ()
        {
            DataRow row = null;
            try
            {
                DataSet dataSet = new DataSet();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(Command))
                {
                    adapter.Fill(dataSet);
                }
                if ((dataSet.Tables.Count > 0) && (dataSet.Tables[0].Rows.Count == 1))
                {
                    row = dataSet.Tables[0].Rows[0];
                }
            }
            catch (Exception exception)
            {
                Logger.Error(Command.CommandText + " - " + exception.ToString());
            }

            return row;
        }

        public string GetString()
        {
            string str = string.Empty;
            try
            {
                object obj2 = Command.ExecuteScalar();
                if (obj2 != null)
                {
                    str = obj2.ToString();
                }
            }
            catch (Exception exception)
            {
                Logger.Error(Command.CommandText + " - " + exception.ToString());
            }

            return str;
        }

        public DataTable GetTable()
        {
            var dataTable = new DataTable();
            if (!DbEnabled)
                return dataTable;

            try
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(Command))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception exception)
            {
                Logger.Error(Command.CommandText + " - " + exception.ToString());
            }

            return dataTable;
        }

        public void RunQuery(string query)
        {
            if (!DbEnabled)
                return;

            SetQuery(query);
            RunQuery();
        }

        public void SetQuery(string query)
        {
            Command.Parameters.Clear();
            Command.CommandText = query;
        }

        public long InsertQuery()
        {
            if (!DbEnabled)
                return 0;

            long lastInsertedId = 0L;
            try
            {
                Command.ExecuteScalar();
                lastInsertedId = Command.LastInsertedId;
            }
            catch (Exception exception)
            {
                Logger.Error(Command.CommandText + " - " + exception.ToString());
            }
            return lastInsertedId;
        }

        public void RunQuery()
        {
            if (!DbEnabled)
                return;

            try
            {
                Command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                Logger.Error(Command.CommandText + " - " + exception.ToString());
            }
        }
    }
}
