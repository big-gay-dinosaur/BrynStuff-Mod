using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace BrynStuff.Items.Equipment.Accessories
{
    public class LifeForceAcc : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corrupt Muscle Tissue");
            Tooltip.SetDefault("You absorb the gross flesh... \n +20% damage. \n +5% crit chance");
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
        }

        public override int ChoosePrefix(UnifiedRandom rand)
        {
            // When the item is given a prefix, only roll the best modifiers for accessories
            return rand.Next(new int[] { PrefixID.Arcane, PrefixID.Lucky, PrefixID.Menacing, PrefixID.Quick, PrefixID.Violent, PrefixID.Warding });
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 5);
            recipe.AddIngredient(ItemID.ShadowScale, 10);
            recipe.AddIngredient(mod.GetItem("CorruptMaterial"), 10);
            recipe.AddIngredient(mod.GetItem("Death"), 40);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
