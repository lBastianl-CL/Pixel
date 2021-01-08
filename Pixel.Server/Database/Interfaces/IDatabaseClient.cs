using MySql.Data.MySqlClient;
using System;

namespace Pixel.Server.Database.Interfaces
{
    public interface IDatabaseClient : IDisposable
    {
        void Connect();
        void Disconnect();
        IQueryAdapter GetQueryReactor();
        MySqlCommand CreateNewCommand();
    }
}
