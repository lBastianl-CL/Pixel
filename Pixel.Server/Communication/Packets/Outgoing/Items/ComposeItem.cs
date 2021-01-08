using Pixel.Server.Pixel.Items;

namespace Pixel.Server.Communication.Packets.Outgoing.Items
{
    public class ComposeItem : ServerPacket
    {
        private RoomItem Item;

        public ComposeItem(RoomItem Item)
        {
            this.Item = Item;
        }

        public override void Write()
        {
            WriteInt(12);
            WriteInt(Item.Id);
            WriteString(Item.BaseItem.FurnidataName);
            WriteInt(Item.X);
            WriteInt(Item.Y);
            WriteDouble(Item.Z);
            WriteInt(Item.Rot);
            WriteInt(Item.GetState());
        }
    }
}
