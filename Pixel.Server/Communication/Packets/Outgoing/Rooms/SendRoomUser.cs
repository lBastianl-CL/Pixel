using Pixel.Server.Pixel.Rooms;

namespace Pixel.Server.Communication.Packets.Outgoing.Rooms
{
    public class SendRoomUser : ServerPacket
    {
        private RoomUser RoomUser;

        public SendRoomUser(RoomUser RoomUser)
        {
            this.RoomUser = RoomUser;
        }

        public override void Write()
        {
            WriteInt(5);
            WriteInt(RoomUser.User.Id);
            WriteString(RoomUser.User.Username);
            WriteString(RoomUser.User.Look);
            WriteInt(RoomUser.X);
            WriteInt(RoomUser.Y);
            WriteDouble(RoomUser.Z);
            WriteBool(RoomUser.IsOnDoor);
        }
    }
}
