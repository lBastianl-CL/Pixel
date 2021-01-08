using System;

namespace Pixel.Server.Communication.Packets
{
    public abstract class ServerPacket : IDisposable
    {
        public GameClient Client;
        public abstract void Write();
        private string result = "";

        public void WriteString(string value)
        {
            if (result == null)
                return;

            result += value.Replace('|', ' ') + "|";
        }

        public void WriteInt(int value)
        {
            if (result == null)
                return;

            result += value.ToString() + "|";
        }
        
        public void WriteDouble(double value)
        {
            if (result == null)
                return;

            result += value.ToString() + "|";
        }

        public void WriteBool(bool value)
        {
            if (result == null)
                return;

            result += (value ? "1" : "0") + "|";
        }

        public string GetData()
        {
            return result;
        }

        public void ExecuteAllThePacket()
        {
            // Generate the packet
            Write();

            // Send it
            Client.socket.Send(result);

            // Dispose it
            Dispose();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
