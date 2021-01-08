using System;

namespace Pixel.Server
{
    public class Logger
    {
        public static bool DebugLog = false;

        public static void Info(string text) => Write("INFO", text, ConsoleColor.White);
        public static void Error(string text) => Write("ERROR", text, ConsoleColor.Red);
        public static void Warn(string text) => Write("WARN", text, ConsoleColor.Yellow);
        public static void Debug(string text) => Write("DEBUG", text, ConsoleColor.Green);

        private static void Write(string type, string text, ConsoleColor color)
        {
            if (!DebugLog && type == "DEBUG")
                return;

            Console.ForegroundColor = color;
            Console.WriteLine(DateTime.Now.ToString(" HH:mm:ss") + " [" + type + "] " + text);
        }
    }
}
