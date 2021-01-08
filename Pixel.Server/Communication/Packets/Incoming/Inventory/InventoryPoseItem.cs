
using Pixel.Server.Communication.Packets.Outgoing.Inventory;
using Pixel.Server.Pixel.Items;

namespace Pixel.Server.Communication.Packets.Incoming.Inventory
{
    public class InventoryPoseItem : ClientPacket
    {
        private string ItemName = "";

        public override void Read()
        {
            ItemName = ReadString();
        }

        public override void Run()
        {
            // TODO: Pensare se effettivamente il 3 ha senso, cioè perchè 3? Bho sono tardo :(
            if (ItemName.Trim().Length < 3)
                return;

            if (Client == null || Client.User == null)
                return;

            RoomItem Item = Client.User.GetFirstItemByName(ItemName);
            if (Item == null)
            {
                Client.SendPacket(new ComposePoseItem(null));
                return;
            }

            Client.SendPacket(new ComposePoseItem(Item));
        }
    }
}
