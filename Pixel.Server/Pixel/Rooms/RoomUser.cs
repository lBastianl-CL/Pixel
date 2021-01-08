using Pixel.Server.Communication;
using Pixel.Server.Pixel.Rooms.PathFinder;
using Pixel.Server.Pixel.Users;
using System.Collections.Generic;

namespace Pixel.Server.Pixel.Rooms
{
    public class RoomUser
    {
        public User User;
        public GameClient Client;
        public Room Room;

        public int X, Y, Rotation = 1;
        public double Z;
        public bool IsOnDoor;

        public bool IsWalking, IsWalkingWaiting;
        public List<Vector2D> WalkingPath, WalkingPathPacket;
        public int WalkingStep;

        public RoomUser(User User, Room Room)
        {
            this.User = User;
            this.Client = User.Client;
            this.Room = Room;

            this.X = Room.Model.DoorX;
            this.Y = Room.Model.DoorY;
            this.Z = Room.Model.DoorZ;
            this.IsOnDoor = true;

            this.IsWalking = false;
            this.IsWalkingWaiting = false;
            this.WalkingPath = null;
            this.WalkingPathPacket = null;
            this.WalkingStep = -1;
        }

        public void PerformWalk(List<Vector2D> Path)
        {
            // If is on door he is no more dumbass
            if (IsOnDoor)
                IsOnDoor = false;

            // Lets start to walk Billie
            IsWalking = false;
            IsWalkingWaiting = true;
            WalkingPathPacket = Path;
            List<Vector2D> CopyPacket = new List<Vector2D>(Path);
            WalkingPath = CopyPacket;
            WalkingPath.Reverse();
            WalkingStep = 1;
        }
    }
}
