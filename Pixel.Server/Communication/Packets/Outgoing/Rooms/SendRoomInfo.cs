using Pixel.Server.Pixel.Items;
using Pixel.Server.Pixel.Rooms;
using System.Collections.Generic;

namespace Pixel.Server.Communication.Packets.Outgoing.Rooms
{
    class SendRoomInfo : ServerPacket
    {
        private Room roon;

        public SendRoomInfo(Room roon)
        {
            this.roon = roon;
        }

        public override void Write()
        {
            WriteInt(3);
            WriteInt(roon.Id);
            WriteString(roon.Title);
            WriteString(roon.Model.Map);

            List<RoomItem> items = roon.RoomMapManager.GetItemsList();
            WriteInt(items.Count);
            foreach(RoomItem item in items)
            {
                WriteInt(item.Id);
                WriteString(item.BaseItem.FurnidataName);
                WriteInt(item.X);
                WriteInt(item.Y);
                WriteString(item.Z.ToString());
                WriteInt(item.Rot);
                WriteInt(item.GetState());
            }
        }
    }
}
