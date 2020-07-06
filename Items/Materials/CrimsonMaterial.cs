using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BrynStuff.Items.Materials
{
    public class CrimsonMaterial : ModItem
    {
        readonly static List<int> CrimsonEnemies = new List<int>()
        {239,240,181,173,-22,-23,266,267};
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloody Intestines");
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
                if (CrimsonEnemies.Contains(npc.type) && NPC.downedBoss1 == true)
                {
                        Item.NewItem(npc.getRect(), ItemType<CrimsonMaterial>(), 1);
                };
                if(npc.type == NPCID.BrainofCthulhu && NPC.downedBoss1 == true) {
                    Item.NewItem(npc.getRect(), ItemType<CrimsonMaterial>(), Main.rand.Next(51) + 20);
                };
               
            }
        }
    }
}