using Pixel.Server.Pixel.Rooms;

namespace Pixel.Server.Communication.Packets.Outgoing.Rooms
{
    public class SendRoomUSERS : ServerPacket
    {
        private Room Room;

        public SendRoomUSERS(Room Room)
        {
            this.Room = Room;
        }

        public override void Write()
        {
            WriteInt(4);

            WriteInt(Room.RoomUserManager.Users.Count);
            foreach (RoomUser RoomUser in Room.RoomUserManager.Users)
            {
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
}
