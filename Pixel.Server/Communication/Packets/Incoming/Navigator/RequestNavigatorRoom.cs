using Pixel.Server.Communication.Packets.Outgoing.Navigator;

namespace Pixel.Server.Communication.Packets.Incoming.Navigator
{
    public class RequestNavigatorRoom : ClientPacket
    {
        public override void Read()
        {

        }

        public override void Run()
        {
            if (Client == null || Client.User == null)
                return;

            Client.SendPacket(new ComposeNavigator(Client.User));
        }
    }
}
