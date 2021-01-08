using Pixel.Server.Communication;

namespace Pixel.Server.Pixel.Items.Interactions
{
    public interface InteractorInterface
    {
        void Trigger(GameClient Client, RoomItem Item);
    }
}
