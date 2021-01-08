using Pixel.Server.Core.Managers;
using Pixel.Server.Pixel.Rooms;
using Pixel.Server.Pixel.Users;
using System.Collections.Generic;

namespace Pixel.Server.Communication.Packets.Outgoing.Navigator
{
    class ComposeNavigator : ServerPacket
    {
        private User User;
        public ComposeNavigator(User User)
        {
            this.User = User;
        }

        public override void Write()
        {
            WriteInt(9);

            // Open rooms
            List<Room> ActiveRooms = RoomManager.GetActiveRooms();
            WriteInt(ActiveRooms.Count);
            foreach (Room Room in ActiveRooms)
            {
                WriteInt(Room.Id);
                WriteString(Room.Title);
                WriteInt(Room.RoomUserManager.Users.Count);
            }

            // My rooms
            WriteInt(User.OwnedRooms.Count);
            foreach(int RoomId in User.OwnedRooms)
            {
                Room Room = RoomManager.GetRoomById(RoomId);
                WriteInt(Room.Id);
                WriteString(Room.Title);
                WriteInt(Room.RoomUserManager.Users.Count);
            }
        }
    }
}
