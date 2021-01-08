using Fleck;
using Org.BouncyCastle.Cms;
using Pixel.Server.Communication.Packets;
using Pixel.Server.Communication.Packets.Incoming.Inventory;
using Pixel.Server.Communication.Packets.Incoming.Items;
using Pixel.Server.Communication.Packets.Incoming.Navigator;
using Pixel.Server.Communication.Packets.Incoming.Rooms;
using Pixel.Server.Communication.Packets.Incoming.USERS;
using Pixel.Server.Communication.Packets.Outgoing;
using Pixel.Server.Core.Managers;
using Pixel.Server.Pixel.Rooms;
using Pixel.Server.Pixel.Users;
using System;
using System.Threading;

namespace Pixel.Server.Communication
{
    public class GameClient : IDisposable
    {
        public IWebSocketConnection socket;

        public User User;
        public Room Room;
        public RoomUser RoomUser;

        #region General socket
        public GameClient(IWebSocketConnection socket)
        {
            try
            {
                this.socket = socket;

                this.socket.OnMessage = (data) => Receive(data);
                this.socket.OnError = (error) => Close(error);
                this.socket.OnClose = () => Close(null);
            }
            catch (Exception e)
            {
                Logger.Error("Error creating new GameClient => " + e.ToString());
            }
        }

        private void Close(Exception error)
        {
            try
            {
                if (error != null)
                    Logger.Error($"Client closing due to a error. [{error.ToString()}]");

                if (Room != null && User != null)
                    Room.RoomUserManager.RemoveUser(User.Id);

                CommunicationManager.Remove(this);
            }
            catch (Exception e)
            {
                Logger.Error("Error closing GC => " + e.ToString());
            }

            try
            {
                socket.Close();
            }
            catch
            {

            }
        }

        public void Disconnect()
        {
            Close(null);
        }

        #endregion

        #region Packets
        private void Receive(string data)
        {
            try
            {
                string[] vars = data.Split('|');
                int opcode = int.Parse(vars[0]);

                ClientPacket receivePacket = null;

                switch (opcode)
                {
                    case 1: receivePacket = new AuthenticateUserTicket(); break;
                    case 2: receivePacket = new UserJoinRoom(); break;
                    case 3: receivePacket = new UserClickTile(); break;
                    case 4: receivePacket = new UserPendingPlayers(); break;
                    case 5: receivePacket = new InteractItem(); break;
                    case 6: receivePacket = new RequestNavigatorRoom(); break;
                    case 7: receivePacket = new ComposeInventoryRequest(); break;
                    case 8: receivePacket = new InventoryPoseItem(); break;
                    case 9: receivePacket = new InventoryPoseItemOnTile(); break;
                    case 10: receivePacket = new PickItem(); break;
                }

                if (receivePacket != null)
                {
                    receivePacket.Client = this;
                    receivePacket.data = vars;
                    new Thread(receivePacket.ExecuteAllThePacket).Start();
                }
                else if (ConfigManager.GetBool("connection.missing.packet")) Logger.Warn($"Received unknown packet. [{data}]");
            }
            catch (Exception e)
            {
                Logger.Error("Error received data from GC => " + e.ToString());
            }
        }

        public void SendPacket(ServerPacket packet)
        {
            try
            {
                packet.Client = this;
                new Thread(packet.ExecuteAllThePacket).Start();
            }
            catch (Exception e)
            {
                Logger.Error("Error sending a packet. " + e.ToString());
            }
        }

        private void Ping()
        {
            SendPacket(new InitConnectionPing());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
