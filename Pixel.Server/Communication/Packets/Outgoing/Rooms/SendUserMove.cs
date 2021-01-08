using Pixel.Server.Pixel.Rooms;
using Pixel.Server.Pixel.Rooms.PathFinder;
using System.Collections.Generic;

namespace Pixel.Server.Communication.Packets.Outgoing.Rooms
{
    class SendUserMove : ServerPacket
    {
        private int Id;
        private List<Vector2D> Path;
        private Room Room;

        public SendUserMove(int Id, List<Vector2D> Path, Room Room)
        {
            this.Id = Id;
            this.Path = Path;
            this.Room = Room;
        }

        public override void Write()
        {
            WriteInt(6);
            WriteInt(Id);
            WriteInt(Path.Count);
            foreach(Vector2D Step in Path)
            {
                WriteInt(Step.X);
                WriteInt(Step.Y);
                WriteString(Room.RoomMapManager.CalculateHeight(Step.X, Step.Y).ToString());
            }
        }
    }
}
