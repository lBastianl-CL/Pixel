using Pixel.Server.Pixel.Rooms.PathFinder;
using System.Collections.Generic;

namespace Pixel.Server.Communication.Packets.Incoming.Rooms
{
    public class UserClickTile : ClientPacket
    {
        private int x, y;

        public override void Read()
        {
            x = ReadInt();
            y = ReadInt();
        }

        public override void Run()
        {
            if (Client.RoomUser.IsWalking)
                return;

            List<Vector2D> path = PathFinder.FindPath(Client.RoomUser, true, Client.Room, new Vector2D(Client.RoomUser.X, Client.RoomUser.Y), new Vector2D(x, y));
            if (path.Count == 0)
                return;

            Client.RoomUser.PerformWalk(path);
        }
    }
}
