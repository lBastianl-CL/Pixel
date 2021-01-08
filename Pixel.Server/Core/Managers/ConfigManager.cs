using System;
using System.Collections.Generic;
using System.IO;

namespace Pixel.Server.Core.Managers
{
    public static class ConfigManager
    {
        private static string PATH = "Data\\Config.ini";
        private static Dictionary<string, string> configs = new Dictionary<string, string>();


        public static void Load()
        {
            try
            {
                configs.Clear();

                string[] lines = File.ReadAllLines(PATH);

                foreach (string line in lines)
                {
                    if (line.Contains("#"))
                        continue;

                    if (line.Contains("="))
                    {
                        string key = line.Split('=')[0].Trim();
                        string value = line.Split('=')[1].Trim();

                        if (configs.ContainsKey(key))
                        {
                            Logger.Warn("Multiple configuration: " + key);
                            continue;
                        }
                        configs.Add(key, value);
                    }
                }

                if (configs.ContainsKey("debug"))
                    Logger.DebugLog = bool.Parse(configs["debug"]);

                Logger.Debug("Loaded " + configs.Count + " configurations.");
                Logger.Info("Loading ConfigManager. Ready to use.");
            }
            catch (Exception e)
            {
                Logger.Error(e.ToString());
            }
        }

        public static int GetInt(string key)
        {
            try
            {
                int value = int.Parse(configs[key]);
                return value;
            }
            catch
            {
                return 0;
            }
        }

        public static bool GetBool(string key)
        {
            try
            {
                bool value = bool.Parse(configs[key]);
                return value;
            }
            catch
            {
                return false;
            }
        }

        public static string GetString(string key)
        {
            if (configs.ContainsKey(key))
                return configs[key];

            return "";
        }
    }
}
