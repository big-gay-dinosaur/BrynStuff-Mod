using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BrynStuff.Items.Materials
{
    public class Death : ModItem
    {
        readonly static List<int> ZombieVariants = new List<int>()
        {3,-26,-27,430,132,-28,-29,186,-30,-31,432,187,-32,-33,433,188,-34,-35,434,189,-36,-37,435,200,-44,-45,436};
        readonly static List<int> DemonEyeVariants = new List<int>()
        {2,-43,190,-38,191,-39,192,-40,193,-41,194,-42,317,318};
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Supercharging Powder");
            Tooltip.SetDefault("Combine with your weapons to supercharge them!!!11!!1!!111!!11!!!!11!1!!!");
            // ticksperframe, frameCount
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
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
            item.rare = 3;
        }


        public class SoulGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (ZombieVariants.Contains(npc.type) || DemonEyeVariants.Contains(npc.type))
                {
                    
                        Item.NewItem(npc.getRect(), ItemType<Death>(), Main.rand.Next(6) + 1);
                    
                }
            }
        }
    }
}