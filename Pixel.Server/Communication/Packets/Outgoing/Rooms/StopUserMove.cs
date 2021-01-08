namespace Pixel.Server.Communication.Packets.Outgoing.Rooms
{
    public class StopUserMove : ServerPacket
    {
        private int User, X, Y;
        private double Z;

        public StopUserMove(int User, int X, int Y, double Z)
        {
            this.User = User;
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public override void Write()
        {
            WriteInt(14);
            WriteInt(User);
            WriteInt(X);
            WriteInt(Y);
            WriteDouble(Z);
        }
    }
}
