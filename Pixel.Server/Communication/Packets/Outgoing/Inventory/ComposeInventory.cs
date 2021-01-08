using Pixel.Server.Pixel.Users;
using System.Collections.Generic;

namespace Pixel.Server.Communication.Packets.Outgoing.Inventory
{
    public class ComposeInventory : ServerPacket
    {
        private User User;
        public ComposeInventory(User User)
        {
            this.User = User;
        }

        public override void Write()
        {
            WriteInt(10);

            Dictionary<string, int> Inventory = User.GetInventory();

            WriteInt(Inventory.Count);
            foreach(string Key in Inventory.Keys)
            {
                WriteString(Key);
                WriteInt(Inventory[Key]);
            }
        }
    }
}
