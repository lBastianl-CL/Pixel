using Pixel.Server.Database;
using Pixel.Server.Database.Interfaces;
using Pixel.Server.Pixel.Items;
using System;
using System.Collections.Generic;
using System.Data;

namespace Pixel.Server.Core.Managers
{
    public class ItemManager
    {
        public static Dictionary<int, Item> FurnitureDefinitions = new Dictionary<int, Item>();

        public static void Load()
        {
            FurnitureDefinitions.Clear();

            using (IQueryAdapter dbClient = DatabaseManager.GetQueryReactor())
            {
                dbClient.SetQuery("SELECT * FROM `furniture`");

                DataTable data = dbClient.GetTable();
                foreach (DataRow row in data.Rows)
                {
                    Item item = new Item();
                    item.Id = Convert.ToInt32(row["id"]);
                    item.FurnidataName = Convert.ToString(row["furnidata_name"]);
                    item.Width = Convert.ToInt32(row["width"]);
                    item.Length = Convert.ToInt32(row["length"]);
                    item.Height = Convert.ToDouble(row["height"]);
                    item.CanStack = Convert.ToInt32(row["allow_stack"]) == 1 ? true : false;
                    item.CanSit = Convert.ToInt32(row["allow_sit"]) == 1 ? true : false;
                    item.CanWalk = Convert.ToInt32(row["allow_walk"]) == 1 ? true : false;
                    item.Interaction = item.GetInteraction(Convert.ToString(row["interaction_type"]));
                    item.InteractionCount = Convert.ToInt32(row["interaction_count"]);
                    
                    string _heights = Convert.ToString(row["multi_height"]);
                    if(_heights.Contains(";"))
                    {
                        string[] heights = _heights.Split(';');
                        foreach (string height in heights)
                            item.MultiHeight.Add(Convert.ToDouble(height));
                    }

                    string _rotation = Convert.ToString(row["rotations"]);
                    if(_rotation.Contains(";"))
                    {
                        string[] rotations = _rotation.Split(';');
                        item.Rotations = new int[rotations.Length];

                        int count = 0;
                        foreach(string rotation in rotations)
                        {
                            item.Rotations[count] = int.Parse(rotation);
                            count++;
                        }
                    }
                    else
                    {
                        item.Rotations = new int[1];
                        item.Rotations[0] = int.Parse(_rotation);
                    }


                    FurnitureDefinitions.Add(item.Id, item);
                }
            }

            Logger.Debug("Loaded " + FurnitureDefinitions.Count + " furnitures.");
            Logger.Info("Loading ItemManager. Ready for use.");
        }
    }
}
