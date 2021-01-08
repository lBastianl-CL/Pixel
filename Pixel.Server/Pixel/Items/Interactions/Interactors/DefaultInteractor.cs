using Pixel.Server.Communication;

namespace Pixel.Server.Pixel.Items.Interactions.Interactors
{
    public class DefaultInteractor : InteractorInterface
    {
        public void Trigger(GameClient Client, RoomItem Item)
        {
            int State = Item.GetState();
            int NewState = State + 1;

            if (NewState > Item.BaseItem.InteractionCount)
                NewState = 0;

            Item.ExtraData = NewState.ToString();

            if (Client.Room != null)
                Client.Room.RoomMapManager.UpdateItemInfo(Item);
        }
    }
}
