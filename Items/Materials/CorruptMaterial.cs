using Microsoft.Xna.Framework;
using MonoMod.Cil;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BrynStuff.Items.Materials
{
    public class CorruptMaterial : ModItem
    {
        readonly static List<int> CorruptionEnemies = new List<int>()
        {6,-11,-12, 7, 8, 9, NPCID.EaterofWorldsBody, NPCID.EaterofWorldsHead, NPCID.EaterofWorldsTail};
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupt Pus");
            Tooltip.SetDefault("'Eww...'");
            // ticksperframe, frameCount
            ItemID.Sets.ItemIconPulse[item.type] = false;
            ItemID.Sets.ItemNoGravity[item.type] = false;
            ItemID.Sets.AnimatesAsSoul[item.type] = false;
            //Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
            
        }

        // TODO -- Velocity Y smaller, post NewItem?
        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.SoulofSight);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 999;
            item.value = 1000;
            item.rare = 1;
        }


        public class SoulGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (CorruptionEnemies.Contains(npc.type) && NPC.downedBoss1 == true)
                {
                            Item.NewItem(npc.getRect(), ItemType<CorruptMaterial>(), 1);
                }
            }
        }
    }
}