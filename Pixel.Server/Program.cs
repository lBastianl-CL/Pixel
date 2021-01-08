using Pixel.Server.Communication;
using Pixel.Server.Core.Managers;
using Pixel.Server.Database;
using Pixel.Server.Pixel.Rooms;
using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Pixel.Server
{
    class Program
    {
        private static string Build = "0.0.0.1";
        #region Close remove
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        #endregion

        #region Server general infos
        private static string Logo =@"     _____________            _____" + Environment.NewLine +
                                    @"     ___  __ \__(_)___  _________  /" + Environment.NewLine +
                                    @"     __  /_/ /_  /__  |/_/  _ \_  / " + Environment.NewLine +
                                    @"     _  ____/_  / __>  < /  __/  /" + Environment.NewLine +
                                    @"     /_/     /_/  /_/|_| \___//_/" + Environment.NewLine +
                                    @"         Pixel Team - {0}" + Environment.NewLine;
        #endregion

        public static void Main(string[] args)
        {
            UpdateTitle("Loading");

            // Remove close button beofre start
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);

            // Show cool and useless informations that I want to see
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(Logo.Replace("{0}", Build));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   THIS IS NOT A FREE FOR USE SOFTWARE");
            Console.WriteLine();

            // Load important manager
            ConfigManager.Load();
            DatabaseManager.Load();

            // Load manager
            RoomManager.Load();
            ItemManager.Load();

            // Start communication
            CommunicationManager.Initialize();

            // Listen to commands
            while (true)
            {
                string cmd = Console.ReadLine().Trim().ToLower();

                switch(cmd)
                {
                    case "stop":
                    case "close":
                    case "shutdown":
                        PerformShutdown();
                        break;
                    case "reload": break;
                }
            }
        }

        private static void UpdateTitle(string Text)
        {
            Console.Title = "Pixel.JS - " + Text;
        }

        private static void PerformShutdown()
        {
            Console.Clear();

            // Start
            UpdateTitle("Closing..");
            Logger.Warn("Performing shutdown..");
            Thread.Sleep(1000);

            // Shutdown everything
            foreach(Room room in RoomManager.Rooms)
            {

            }

            // End
            Logger.Warn("Shotdown done.");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }

    }
}
