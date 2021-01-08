namespace Pixel.Server.Pixel.Items
{
    public class RoomItem
    {
        public int Id, Owner, Room, X, Y, Rot;
        public double Z;
        public string ExtraData;
        public Item BaseItem;

        public int GetState()
        {
            if (BaseItem.InteractionCount > 0)
                return int.Parse(ExtraData);

            return 0;
        }
    }
}
