using Pixel.Server.Core.Managers;

namespace Pixel.Server.Communication.Packets.Outgoing.USERS
{
    public class InitUserData : ServerPacket
    {
        private GameClient client;
        private int error;

        public InitUserData(int error, GameClient client)
        {
            this.error = error;
            this.client = client;
        }

        public override void Write()
        {
            WriteInt(2);
            WriteInt(error);
            if (error == 0)
            {
                WriteInt(client.User.Id);
                WriteString(client.User.Username);
                WriteInt(ConfigManager.GetInt("dev.room"));
            }
        }
    }
}
