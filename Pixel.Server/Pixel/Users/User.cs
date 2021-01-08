using Pixel.Server.Communication;
using Pixel.Server.Pixel.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pixel.Server.Pixel.Users
{
    public class User : IDisposable
    {
        public int Id, Credits;
        public string Username, Look, Motto;
        public GameClient Client;
        public List<int> OwnedRooms;
        public List<RoomItem> OwnedItems;

        public Dictionary<string, int> GetInventory()
        {
            Dictionary<string, int> JoinedItems = new Dictionary<string, int>();

            foreach(RoomItem Item in OwnedItems)
            {
                if (JoinedItems.ContainsKey(Item.BaseItem.FurnidataName))
                    JoinedItems[Item.BaseItem.FurnidataName] += 1;
                else
                    JoinedItems.Add(Item.BaseItem.FurnidataName, 1);
            }

            return JoinedItems;
        }

        public RoomItem GetFirstItemByName(string Name)
        {
            return OwnedItems.FirstOrDefault(x => x != null && x.BaseItem != null && x.BaseItem.FurnidataName == Name);
        }

        public RoomItem GetItemById(int Id)
        {
            return OwnedItems.FirstOrDefault(x => x != null && x.Id == Id);
        }
        #region Disposing
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
