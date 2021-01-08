using Pixel.Server.Pixel.Items;

namespace Pixel.Server.Communication.Packets.Outgoing.Inventory
{
    public class ComposePoseItem : ServerPacket
    {
        private RoomItem Item;

        public ComposePoseItem(RoomItem Item)
        {
            this.Item = Item;
        }

        public override void Write()
        {
            WriteInt(11);

            if(Item == null)
            {
                WriteInt(0);
                return;
            }

            WriteInt(Item.Id);
            WriteString(Item.BaseItem.FurnidataName);
        }
    }
}
