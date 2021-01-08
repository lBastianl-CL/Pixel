using Pixel.Server.Pixel.Items;

namespace Pixel.Server.Communication.Packets.Outgoing.Items
{
    public class UpdateItem : ServerPacket
    {
        private RoomItem Item;
        public UpdateItem(RoomItem Item)
        {
            this.Item = Item;
        }

        public override void Write()
        {
            WriteInt(8);
            WriteInt(Item.Id);
            WriteInt(Item.Rot);
            WriteInt(Item.GetState());
            WriteInt(Item.X);
            WriteInt(Item.Y);
            WriteDouble(Item.Z);
        }
    }
}
