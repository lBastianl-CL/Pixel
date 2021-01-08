namespace Pixel.Server.Communication.Packets.Outgoing.Rooms
{
    class RemoveRoomUser : ServerPacket
    {
        private int user;

        public RemoveRoomUser(int user)
        {
            this.user = user;
        }

        public override void Write()
        {
            WriteInt(7);
            WriteInt(user);
        }
    }
}
