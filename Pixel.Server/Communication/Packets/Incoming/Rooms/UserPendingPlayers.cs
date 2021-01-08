using System;
using System.Collections.Generic;
using System.Text;

namespace Pixel.Server.Communication.Packets.Incoming.Rooms
{
    class UserPendingPlayers : ClientPacket
    {
        public override void Read()
        {

        }

        public override void Run()
        {
            if (Client.Room != null)
                Client.Room.RoomUserManager.AddUser(Client);
        }
    }
}
