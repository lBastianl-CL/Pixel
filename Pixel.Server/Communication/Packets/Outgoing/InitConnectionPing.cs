namespace Pixel.Server.Communication.Packets.Outgoing
{
    public class InitConnectionPing : ServerPacket
    {
        public override void Write()
        {
            WriteInt(1);
        }
    }
}
