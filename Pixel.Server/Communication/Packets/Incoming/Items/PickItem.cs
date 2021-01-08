using Pixel.Server.Communication.Packets.Outgoing.Items;
using Pixel.Server.Database;
using Pixel.Server.Database.Interfaces;
using Pixel.Server.Pixel.Items;
using Pixel.Server.Pixel.Rooms;

namespace Pixel.Server.Communication.Packets.Incoming.Items
{
    public class PickItem : ClientPacket
    {
        private int itemId;

        public override void Read()
        {
            itemId = ReadInt();
        }

        public override void Run()
        {
            RoomItem Item = Client.Room.RoomMapManager.GetItemById(itemId);
            if (Item == null)
                return;

            if (Client.Room.Owner != Client.User.Id)
                return;

            Item.Room = 0;
            Client.Room.RoomMapManager.RemoveItem(Item);

            GameClient SendBackItemClient = Client;
            if(Client.User.Id != Item.Owner)
                SendBackItemClient = CommunicationManager.GetClientById(Item.Owner);

            if (SendBackItemClient != null)
                SendBackItemClient.User.OwnedItems.Add(Item);

            foreach (RoomUser User in Client.Room.RoomUserManager.Users)
                User.Client.SendPacket(new RemoveItem(Item));

            using (IQueryAdapter dbClient = DatabaseManager.GetQueryReactor())
            {
                dbClient.SetQuery("UPDATE `items` SET `room` = '0' WHERE `id` = @item");
                dbClient.AddParameter("item", Item.Id);
                dbClient.RunQuery();
            }

        }
    }
}
