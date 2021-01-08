using Pixel.Server.Database.Interfaces;
using System;

namespace Pixel.Server.Database.Adapter
{
    public class NormalQueryReactor : QueryAdapter, IQueryAdapter
    {
        public NormalQueryReactor(IDatabaseClient client)
            : base(client)
        {
            Command = client.CreateNewCommand();
        }

        public void Dispose()
        {
            Command.Dispose();
            Client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
