using Fleck;
using Pixel.Server.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Pixel.Server.Communication
{
    public static class CommunicationManager
    {
        private static WebSocketServer server;
        private static List<GameClient> onlineClients = null;

        private static void SyncInfo()
        {
            while (true)
            {
                Console.Title = $"PixelJS | Uptime: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")} | Clients: {onlineClients.Count} | Rooms: {RoomManager.Rooms.Count}";
                Thread.Sleep(10000);
            }
        }

        public static void Remove(GameClient client)
        {
            if (onlineClients.Contains(client))
                onlineClients.Remove(client);
        }

        public static void Initialize()
        {
            Console.WriteLine();

            FleckLog.Level = LogLevel.Error;

            onlineClients = new List<GameClient>();
            server = new WebSocketServer($"ws://{ConfigManager.GetString("connection.ip")}:{ConfigManager.GetString("connection.port")}");
            server.Start(socket =>
            {
                socket.OnOpen = () => AcceptNewClient(socket);
            });

            Logger.Debug($"Communication started. [{ConfigManager.GetString("connection.ip")}:{ConfigManager.GetString("connection.port")}]");
            Logger.Info("Loading CommunicationManager. Ready for use.");

            new Thread(SyncInfo).Start();
        }

        private static void AcceptNewClient(IWebSocketConnection socket)
        {
            if (GetClientBySocket(socket) != null)
            {
                Logger.Warn($"Double-parsing new client. [{socket.ConnectionInfo.ClientIpAddress}, {socket.ConnectionInfo.ClientPort}]");
                return;
            }

            GameClient client = new GameClient(socket);
            onlineClients.Add(client);
        }

        private static GameClient GetClientBySocket(IWebSocketConnection socket)
        {
            if (onlineClients == null || onlineClients.Count == 0)
                return null;

            return onlineClients.FirstOrDefault(x => x.socket != null && x.socket == socket);
        }

        public static GameClient GetClientById(int Id)
        {
            return onlineClients.FirstOrDefault(x => x != null && x.User != null && x.User.Id == Id);
        }

    }
}
