using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace BrynStuff.Items.Equipment.Accessories
{
    public class SharkAcc : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Toothed Flesh Mass");
            Tooltip.SetDefault("You absorb the gross flesh... \n +20% more damage. \n +5% crit chance \n +5 armor penetration");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.rare = 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.allDamage *= 1.2f;
            player.magicCrit += 5;
            player.meleeCrit += 5;
            player.rangedCrit += 5;
            player.thrownCrit += 5;
            player.armorPenetration += 5;
        }

        public override int ChoosePrefix(UnifiedRandom rand)
        {
            // When the item is given a prefix, only roll the best modifiers for accessories
            return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem("LifeForceAcc"), 1);
            recipe.AddIngredient(ItemID.SharkToothNecklace, 1);
            recipe.AddIngredient(mod.GetItem("CorruptMaterial"), 1);
            recipe.AddIngredient(ItemID.SharkFin, 1);
            recipe.AddIngredient(mod.GetItem("Death"), 40);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
