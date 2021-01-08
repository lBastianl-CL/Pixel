using Pixel.Server.Communication;
using Pixel.Server.Database;
using Pixel.Server.Database.Interfaces;
using Pixel.Server.Pixel.Items;
using Pixel.Server.Pixel.Rooms;
using Pixel.Server.Pixel.Users;
using System;
using System.Data;

namespace Pixel.Server.Core.Managers
{
    public class UserManager
    {
        public static int Authenticate(string authTicket, GameClient client)
        {
            int error = 0; // 0 - ok | 1 - fuck off

            if (client != null)
            {
                User user = GenerateUser(authTicket);

                if (user != null)
                {
                    user.Client = client;
                    client.User = user;
                }
                else error = 1;
            }
            else error = 1;

            return error;
        }

        public static User GenerateUser(string authTicket)
        {
            DataRow dataUser = null;

            using (IQueryAdapter dbClient = DatabaseManager.GetQueryReactor())
            {
                dbClient.SetQuery("SELECT `id`, `username`, `look`, `motto`, `credits` FROM `USERS` WHERE `auth_ticket` = @sso LIMIT 1");
                dbClient.AddParameter("sso", authTicket);
                dataUser = dbClient.GetRow();
            }

            if (dataUser == null)
                return null;

            User user = new User()
            {
                Id = Convert.ToInt32(dataUser["id"]),
                Username = Convert.ToString(dataUser["username"]),
                Look = Convert.ToString(dataUser["look"]),
                Motto = Convert.ToString(dataUser["motto"]),
                Credits = Convert.ToInt32(dataUser["credits"]),
                OwnedItems = new System.Collections.Generic.List<RoomItem>(),
                OwnedRooms = new System.Collections.Generic.List<int>()
            };

            using (IQueryAdapter dbClient = DatabaseManager.GetQueryReactor())
            {
                dbClient.SetQuery("SELECT `id` FROM `rooms` WHERE `owner` = @owner");
                dbClient.AddParameter("@owner", user.Id);

                DataTable data = dbClient.GetTable();
                foreach (DataRow row in data.Rows)
                {
                    int roomId = Convert.ToInt32(row["id"]);
                    Room room = RoomManager.LoadRoom(roomId);
                    if(room != null)
                        user.OwnedRooms.Add(roomId);
                }
            }

            using (IQueryAdapter dbClient = DatabaseManager.GetQueryReactor())
            {
                dbClient.SetQuery("SELECT * FROM `items` WHERE `owner` = @user AND `room` = '0'");
                dbClient.AddParameter("user", user.Id);

                DataTable data = dbClient.GetTable();
                foreach (DataRow row in data.Rows)
                {
                    RoomItem item = new RoomItem();
                    item.Id = Convert.ToInt32(row["id"]);
                    item.BaseItem = ItemManager.FurnitureDefinitions[Convert.ToInt32(row["base_id"])];
                    item.Owner = Convert.ToInt32(row["owner"]);
                    item.Room = Convert.ToInt32(row["room"]);
                    item.X = Convert.ToInt32(row["x"]);
                    item.Y = Convert.ToInt32(row["y"]);
                    item.Z = Convert.ToDouble(row["z"]);
                    item.Rot = Convert.ToInt32(row["rot"]);
                    item.ExtraData = Convert.ToString(row["extra_data"]);
                    user.OwnedItems.Add(item);
                }
            }

            return user;
        }
    }
}
