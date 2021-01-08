using Pixel.Server.Pixel.Items;

namespace Pixel.Server.Communication.Packets.Outgoing.Items
{
    public class RemoveItem : ServerPacket
    {
        public RoomItem Item;
        public RemoveItem(RoomItem Item)
        {
            this.Item = Item;
        }

        public override void Write()
        {
            WriteInt(13);
            WriteInt(Item.Id);
        }
    }
}
