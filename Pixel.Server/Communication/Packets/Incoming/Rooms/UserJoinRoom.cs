using Pixel.Server.Communication.Packets.Outgoing.Rooms;
using Pixel.Server.Core.Managers;
using Pixel.Server.Pixel.Rooms;
using System.Threading;

namespace Pixel.Server.Communication.Packets.Incoming.Rooms
{
    public class UserJoinRoom : ClientPacket
    {
        private int RoomId;

        public override void Read()
        {
            RoomId = ReadInt();
        }

        public override void Run()
        {
            if (RoomId == 0)
                return;

            Room room = RoomManager.LoadRoom(RoomId);
            if (room == null)
                return;

            if(Client.Room != null)
            {
                Client.Room.RoomUserManager.RemoveUser(Client.User.Id);
                Client.Room = null;
                return;
            }
            Client.Room = room;
            Client.SendPacket(new SendRoomInfo(room));
            
        }
    }
}
