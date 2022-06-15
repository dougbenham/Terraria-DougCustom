﻿using System.Collections.Generic;
using Terraria.ModLoader;

namespace TranscendsCustomizations
{
    public class Item : GlobalItem
    {
        public static readonly Dictionary<int, int> DefaultUseTimes = new Dictionary<int, int>();
        public static Dictionary<int, int> CustomUseTimes = new Dictionary<int, int>();

        public override void SetDefaults(Terraria.Item item)
        {
            if (!DefaultUseTimes.ContainsKey(item.type))
				DefaultUseTimes[item.type] = item.useTime;

            SetUseTime(item);
        }
        
        internal static void SetUseTime(Terraria.Item item)
        {
            if (CustomUseTimes.TryGetValue(item.type, out var v))
                item.useTime = v;

            else if (Config.Instance.MaxPickSpeed && (item.axe > 0 ||
                                                      item.pick > 0 ||
                                                      item.hammer > 0))
                item.useTime = 1;

            else if (Config.Instance.MaxTileSpeed && item.createTile >= 0)
                item.useTime = 0;

            else if (Config.Instance.MaxWallSpeed && item.createWall >= 0)
                item.useTime = 0;

            else
                item.useTime = DefaultUseTimes[item.type];
        }
    }
}