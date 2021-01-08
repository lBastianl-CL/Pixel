using Pixel.Server.Communication;
using Pixel.Server.Communication.Packets.Outgoing.Rooms;
using Pixel.Server.Pixel.Rooms.PathFinder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pixel.Server.Pixel.Rooms
{
    public class RoomUserManager : IDisposable
    {
        private Room Room;
        public List<RoomUser> Users;

        public RoomUserManager(Room Room)
        {
            this.Room = Room;
            this.Users = new List<RoomUser>();
        }

        public void OnWalkCycleStart()
        {
            foreach(RoomUser RoomUser in Users)
            {
                // Need to setup here else the end cycle stop it before start
                if (RoomUser.IsWalkingWaiting)
                {
                    RoomUser.IsWalking = true;
                    RoomUser.IsWalkingWaiting = false;

                    foreach (RoomUser SubRoomUser in Users)
                        SubRoomUser.Client.SendPacket(new SendUserMove(RoomUser.User.Id, RoomUser.WalkingPathPacket, Room));
                }

                // If he's walking
                if (RoomUser.IsWalking && RoomUser.WalkingPath != null)
                {

                    Vector2D PerformingStep = RoomUser.WalkingPath[RoomUser.WalkingStep];
                    if(PerformingStep != null)
                    {
                        if (!Room.RoomMapManager.CanWalkOn(PerformingStep.X, PerformingStep.Y))
                        {
                            foreach (RoomUser ToSendUser in Room.RoomUserManager.Users)
                                ToSendUser.Client.SendPacket(new StopUserMove(RoomUser.User.Id, RoomUser.X, RoomUser.Y, RoomUser.Z));

                            RoomUser.IsWalking = false;
                            RoomUser.IsWalkingWaiting = false;
                            RoomUser.WalkingPath = null;
                        }
                        else
                        {
                            RoomUser.Z = Room.RoomMapManager.CalculateHeight(PerformingStep.X, PerformingStep.Y);
                            RoomUser.Rotation = Rotation.Calculate(RoomUser.X, RoomUser.Y, PerformingStep.X, PerformingStep.Y);
                        }
                    }
                    else
                    {
                        Logger.Error("PerformingStep was null. Cancelled.");
                        RoomUser.IsWalking = false;
                        RoomUser.WalkingStep = 0;
                        RoomUser.WalkingPath = null;
                    }
                }


            }
        }

        public void OnWalkCycleEnd()
        {
            foreach (RoomUser RoomUser in Users)
            {
                // If he's walking
                if (RoomUser.IsWalking && RoomUser.WalkingPath != null)
                {
                    Vector2D PerformedStep = RoomUser.WalkingPath[RoomUser.WalkingStep];

                    if(PerformedStep != null)
                    {
                        RoomUser.X = PerformedStep.X;
                        RoomUser.Y = PerformedStep.Y;

                        // Next step is on the way :P
                        RoomUser.WalkingStep++;

                        // If now the path is out of idx
                        if (RoomUser.WalkingPath.Count == RoomUser.WalkingStep)
                        {
                            RoomUser.IsWalking = false;
                            RoomUser.WalkingStep = 0;
                            RoomUser.WalkingPath = null;
                            RoomUser.WalkingPathPacket = null;
                        }
                    }
                    else
                    {
                        Logger.Error("PerformedStep was null. Cancelled.");
                        RoomUser.IsWalking = false;
                        RoomUser.WalkingStep = 0;
                        RoomUser.WalkingPath = null;
                        RoomUser.WalkingPathPacket = null;
                    }
                }


            }
        }


        public bool AddUser(GameClient Client)
        {
            if (GetUser(Client.User.Id) == null)
            {
                // Create the user
                RoomUser roomUser = new RoomUser(Client.User, Room);

                // Set clients vars
                Client.RoomUser = roomUser;

                // Send packets
                foreach (RoomUser User in Users)
                    User.Client.SendPacket(new SendRoomUser(roomUser));

                Client.SendPacket(new SendRoomUSERS(Room));

                // Add the user
                Users.Add(roomUser);

                return true;
            }
            else Logger.Error("Requesting to add User with same Id " + Client.User.Id);

            return false;
        }

        public void RemoveUser(int Id)
        {
            if(GetUser(Id) != null)
            {
                // Send packets
                foreach (RoomUser User in Users)
                    User.Client.SendPacket(new RemoveRoomUser(Id));

                // Remove the user
                Users.Remove(GetUser(Id));
            }
        }

        public RoomUser GetUser(int Id)
        {
            return Users.FirstOrDefault(x => x != null && x.User != null && x.User.Id == Id);
        }

        #region Disposing
        private bool Disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    if (Users != null)
                        Users = null;
                }

                Disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
