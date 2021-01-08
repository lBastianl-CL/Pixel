using Pixel.Server.Communication.Packets.Outgoing.USERS;
using Pixel.Server.Core.Managers;
using System;

namespace Pixel.Server.Communication.Packets.Incoming.USERS
{
    public class AuthenticateUserTicket : ClientPacket
    {
        private string authTicket;

        public override void Read()
        {
            try
            {
                authTicket = ReadString();
            }
            catch
            {
                Logger.Error("AuthTicket null. Disposing connection.");
                Client.Disconnect();
            }
        }

        public override void Run()
        {
            try
            {
                if (authTicket.Trim().Length == 0)
                {
                    Client.Disconnect();
                    Logger.Error("Empty ticket. Disposing connection.");
                    return;
                }

                Client.SendPacket(new InitUserData(UserManager.Authenticate(authTicket, Client), Client));
            }
            catch (Exception e)
            {
                Logger.Error(e.ToString());
            }
        }
    }
}
