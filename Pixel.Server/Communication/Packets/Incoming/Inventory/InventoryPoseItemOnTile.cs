using Pixel.Server.Communication.Packets.Outgoing.Inventory;
using Pixel.Server.Communication.Packets.Outgoing.Items;
using Pixel.Server.Database;
using Pixel.Server.Database.Interfaces;
using Pixel.Server.Pixel.Items;
using Pixel.Server.Pixel.Rooms;

namespace Pixel.Server.Communication.Packets.Incoming.Inventory
{
    public class InventoryPoseItemOnTile : ClientPacket
    {
        private RoomItem Item = null;
        private int TileX, TileY;

        public override void Read()
        {
            if (Client == null || Client.User == null)
                return;

            TileX = ReadInt();
            TileY = ReadInt();
            int id = ReadInt();

            Item = Client.User.GetItemById(id);
        }

        public override void Run()
        {
            if (Item == null)
                return;

            if (Client.Room == null)
                return;

            if (Client.Room.Owner != Client.User.Id)
                return;

            Item.X = TileX;
            Item.Y = TileY;
            Item.Z = Client.Room.RoomMapManager.CalculateHeight(TileX, TileY);
            Item.Rot = Item.BaseItem.Rotations[0];

            Client.User.OwnedItems.Remove(Item);
            Client.Room.RoomMapManager.AddItem(Item);
            
            foreach (RoomUser User in Client.Room.RoomUserManager.Users)
                User.Client.SendPacket(new ComposeItem(Item));

            Client.SendPacket(new ComposeInventory(Client.User));

            using (IQueryAdapter dbClient = DatabaseManager.GetQueryReactor())
            {
                dbClient.SetQuery("UPDATE `items` SET `room` = @room, `x` = @x, `y` = @y, `z` = @z, `rot` = @rot WHERE `id` = @item");
                dbClient.AddParameter("room", Client.Room.Id);
                dbClient.AddParameter("x", Item.X);
                dbClient.AddParameter("y", Item.Y);
                dbClient.AddParameter("z", Item.Z);
                dbClient.AddParameter("rot", Item.Rot);
                dbClient.AddParameter("item", Item.Id);
                dbClient.RunQuery();
            }
        }
    }
}
