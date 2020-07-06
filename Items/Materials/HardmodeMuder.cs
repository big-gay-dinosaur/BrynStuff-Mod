using BrynStuff.NPCs.Enemy;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace BrynStuff.Items.Materials
{
    public class HardmodeMuder : ModItem
    {
        readonly static List<int> EnmDrop = new List<int>()
        {60, 59, 24, 62, 66, 39, 40, 41, 113, 114, 115, 116, 151, 156};
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ungodly Essence");
            Tooltip.SetDefault("'Providence hates this stuff'");
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
            item.rare = 1;
        }


        public class SoulGlobalNPC : GlobalNPC
        {
            public override void NPCLoot(NPC npc)
            {
                if (EnmDrop.Contains(npc.type) && NPC.downedMechBossAny || npc.type == NPCType<EnmZom1>() && NPC.downedMechBossAny)
                {
                        Item.NewItem(npc.getRect(), ItemType<HardmodeMuder>(), Main.rand.Next(1, 10));
                };
                if (npc.type == NPCID.WallofFlesh && NPC.downedMechBossAny)
                {
                        Item.NewItem(npc.getRect(), ItemType<HardmodeMuder>(), Main.rand.Next(50, 100));
                };
          
               
            }
        }
    }
}