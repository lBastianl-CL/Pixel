using Pixel.Server.Communication.Packets.Outgoing.Items;
using Pixel.Server.Core.Managers;
using Pixel.Server.Database;
using Pixel.Server.Database.Interfaces;
using Pixel.Server.Pixel.Items;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Pixel.Server.Pixel.Rooms
{
    public class RoomMapManager
    {
        public bool[,] ValidTiles = new bool[64, 64]; // TODO: Enlarge room size more then 64x64?
        public int MaxMapX = 0, MaxMapY = 0;
        private Room Room;

        private Dictionary<int, RoomItem> RoomItems = new Dictionary<int, RoomItem>();

        public RoomMapManager(Room Room, string Map)
        {
            this.Room = Room;
            LoadValidTiles(Map);

            using (IQueryAdapter dbClient = DatabaseManager.GetQueryReactor())
            {
                dbClient.SetQuery("SELECT * FROM `items` WHERE `room` = @room");
                dbClient.AddParameter("room", Room.Id);

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
                    RoomItems.Add(item.Id, item);
                }
            }
        }

        public void AddItem(RoomItem Item)
        {
            RoomItems.Add(Item.Id, Item);
        }

        public void RemoveItem(RoomItem Item)
        {
            if (RoomItems.ContainsKey(Item.Id))
                RoomItems.Remove(Item.Id);
        }

        public double CalculateHeight(int X, int Y)
        {
            try
            {
                List<RoomItem> items = RoomItems.Values.Where(x => x.X == X && x.Y == Y).OrderByDescending(x => x.Z).ToList();
                if (items != null && items.Count > 0)
                {
                    RoomItem item = items[0];
                    double height = item.Z;

                    if (item.BaseItem.InteractionCount > 0)
                        height += item.BaseItem.MultiHeight[item.GetState()];
                    else
                        height += item.BaseItem.Height;

                    return height;
                }
                
            }
            catch
            {

            }

            return 0;
        }

        public void UpdateItemInfo(RoomItem Item)
        {
            foreach (RoomUser User in Room.RoomUserManager.Users)
                User.Client.SendPacket(new UpdateItem(Item));
        }

        public List<RoomItem> GetItemsList()
        {
            return RoomItems.Values.ToList();
        }

        public RoomItem GetItemById(int itemId)
        {
            if (RoomItems.ContainsKey(itemId))
                return RoomItems[itemId];
            return null;
        }

        private void LoadValidTiles(string Map)
        {
            int X = 0, Y = 0;
            foreach(char c in Map)
            {
                if (c.ToString().Trim().Length == 0)
                    continue;

                switch(c)
                {
                    case 'C':
                    case 'y':
                    case 'x':
                    case 'D':
                        ValidTiles[X, Y] = false;
                        Y++; 
                        break;
                    case 'n':
                        ValidTiles[X, Y] = false;
                        X++;
                        Y = 0;
                        break;
                    default:
                        ValidTiles[X, Y] = true;
                        Y++;
                        break;
                }
            }

            MaxMapX = X;
            MaxMapY = Y;
        }

        public bool CanWalkOn(int X, int Y)
        {
            // You can walk out of the room stupid asshole
            if (X < 0 || Y < 0)
                return false;

            // If isn't a valid tile
            if (ValidTiles[X, Y] == false)
                return false;

            // TODO: Check if there are room settings that allow it?

            if (Room.RoomUserManager.Users.FirstOrDefault(x => x != null && x.X == X && x.Y == Y) != null)
                return false;

            var TopItem = GetTopItemOnTile(X, Y);
            if (TopItem != null && !TopItem.BaseItem.CanWalk)
                return false;

            List<RoomItem> ItemsWithMoreThanOneTile = Room.RoomMapManager.RoomItems.Values.Where(item => item != null && !item.BaseItem.CanWalk && (item.BaseItem.Width > 1 || item.BaseItem.Height > 1) ).ToList();
            foreach(RoomItem Item in ItemsWithMoreThanOneTile)
            {
                int StartX = Item.X;
                int StartY = Item.Y;
                int EndX = 0;
                int EndY = 0;

                switch(Item.Rot)
                {
                    case 0:
                        EndX = StartX + Item.BaseItem.Length - 1;
                        EndY = StartY + Item.BaseItem.Width - 1;
                        break;
                }

                // x: 4
                // start: 4 - end: 5
                if (X >= StartX && X <= EndX && Y >= StartY && Y <= EndY)
                    return false;
            }

            // Cool! He can walk.
            return true;
        }

        public RoomItem GetTopItemOnTile(int X, int Y)
        {
            try
            {
                List<RoomItem> items = RoomItems.Values.Where(x => x.X == X && x.Y == Y).OrderByDescending(x => x.Z).ToList();
                if (items != null && items.Count > 0)
                {
                    RoomItem item = items[0];
                    return item;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
