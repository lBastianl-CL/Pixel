using Pixel.Server.Core.Managers;
using System;
using System.Threading;

namespace Pixel.Server.Pixel.Rooms
{
    public class Room : IDisposable
    {
        // Manager
        public RoomUserManager RoomUserManager = null;
        public RoomMapManager RoomMapManager = null;

        // Data
        public int Id, Owner;
        public string Title;
        public RoomModel Model;

        public Room(int Id, string Title, string ModelName, int Owner)
        {
            if (RoomManager.RoomModels.ContainsKey(ModelName))
                Model = RoomManager.RoomModels[ModelName];

            // Load data
            this.Id = Id;
            this.Title = Title;
            this.Owner = Owner;

            // Load managers
            RoomUserManager = new RoomUserManager(this);
            RoomMapManager = new RoomMapManager(this, Model.Map);

            // Start cycle
            new Thread(WalkCycle).Start();
        }

        private void WalkCycle()
        {
            while(!Disposed)
            {
                // Before cycle
                RoomUserManager.OnWalkCycleStart();

                // Middle cycle
                Thread.Sleep(250);

                // Post cycle
                Thread.Sleep(250);
                RoomUserManager.OnWalkCycleEnd();
            }
        }

        #region Disposing
        private bool Disposed = false;

        public void Dispose()
        {
            Disposed = true;
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
