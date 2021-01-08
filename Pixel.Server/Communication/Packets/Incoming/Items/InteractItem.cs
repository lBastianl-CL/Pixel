using Pixel.Server.Pixel.Items;
using Pixel.Server.Pixel.Items.Interactions;

namespace Pixel.Server.Communication.Packets.Incoming.Items
{
    public class InteractItem : ClientPacket
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
            {
                return;
            }

            if (Client.Room.Owner != Client.User.Id)
                return;

            InteractorInterface interactor = Item.BaseItem.GetInteractor();
            if(interactor != null)
            {
                interactor.Trigger(Client, Item);
                interactor = null;
            }
            
        }
    }
}
