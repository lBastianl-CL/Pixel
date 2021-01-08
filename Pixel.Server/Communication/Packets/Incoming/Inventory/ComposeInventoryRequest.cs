using Pixel.Server.Communication.Packets.Outgoing.Inventory;

namespace Pixel.Server.Communication.Packets.Incoming.Inventory
{
    public class ComposeInventoryRequest : ClientPacket
    {
        public override void Read()
        {

        }

        public override void Run()
        {
            if (Client == null || Client.User == null)
                return;

            Client.SendPacket(new ComposeInventory(Client.User));
        }
    }
}
