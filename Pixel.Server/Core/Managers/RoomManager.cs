using Pixel.Server.Database;
using Pixel.Server.Database.Interfaces;
using Pixel.Server.Pixel.Rooms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Pixel.Server.Core.Managers
{
    public static class RoomManager
    {
        public static Dictionary<string, RoomModel> RoomModels;
        public static List<Room> Rooms;

        public static void Load()
        {
            try
            {
                RoomModels = new Dictionary<string, RoomModel>();
                Rooms = new List<Room>();

                using (IQueryAdapter dbClient = DatabaseManager.GetQueryReactor())
                {
                    dbClient.SetQuery("SELECT * FROM `room_models`");

                    DataTable data = dbClient.GetTable();
                    foreach (DataRow row in data.Rows)
                    {
                        RoomModel model = new RoomModel()
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Name = Convert.ToString(row["model_name"]),
                            Map = Convert.ToString(row["model_map"]),
                            DoorX = Convert.ToInt32(row["door_x"]),
                            DoorY = Convert.ToInt32(row["door_y"]),
                            DoorZ = Convert.ToInt32(row["door_z"]),
                        };

                        RoomModels.Add(model.Name, model);
                    }
                }

                Logger.Debug("Loaded " + RoomModels.Count + " models.");
                Logger.Info("Loading RoomManager. Ready for use.");
            }
            catch (Exception e)
            {
                Logger.Error(e.ToString());
            }
        }
        
        public static List<Room> GetActiveRooms()
        {
            return Rooms.Where(x => x != null && x.RoomUserManager != null && x.RoomUserManager.Users.Count > 0).ToList();
        }

        public static Room GetRoomById(int Id)
        {
            return Rooms.FirstOrDefault(x => x != null && x.Id == Id);
        }

        public static Room LoadRoom(int Id)
        {
            Room room = GetRoomById(Id);
            if (room != null)
                return room;

            using (IQueryAdapter dbClient = DatabaseManager.GetQueryReactor())
            {
                dbClient.SetQuery("SELECT * FROM `rooms` WHERE `id` = @id LIMIT 1");
                dbClient.AddParameter("id", Id);

                DataTable data = dbClient.GetTable();
                foreach (DataRow row in data.Rows)
                    room = new Room(Convert.ToInt32(row["id"]), Convert.ToString(row["title"]), Convert.ToString(row["model"]), Convert.ToInt32(row["owner"]));
            }

            if (room != null)
                Rooms.Add(room);

            return room;
        }
    }
}
