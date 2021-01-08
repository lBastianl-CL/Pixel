using System.Drawing;

namespace Pixel.FurnitureCreator
{
    public class ItemImage
    {
        public int Rotation = 0, State = 0, Layer = 0, Depth = 0, offX = 0, offY = 0;
        public int Id;
        public string RealName = "";
        public Image Image;

        public int AtlasX, AtlasY;
    }
}
