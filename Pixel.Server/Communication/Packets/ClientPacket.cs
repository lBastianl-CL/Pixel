using System;

namespace Pixel.Server.Communication.Packets
{
    public abstract class ClientPacket : IDisposable
    {
        public GameClient Client;
        private int offset = 1;
        public string[] data;

        public void ExecuteAllThePacket()
        {
            Read();
            Run();
        }

        #region Reads
        private string ReadNext()
        {
            try
            {
                return data[offset++];
            }
            catch
            {
                return "";
            }
        }

        public int ReadInt()
        {
            try
            {
                return int.Parse(ReadNext());
            }
            catch
            {
                return -1;
            }
        }

        public string ReadString()
        {
            try
            {
                return ReadNext();
            }
            catch
            {
                return "";
            }
        }
        #endregion

        public abstract void Read();
        public abstract void Run();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
