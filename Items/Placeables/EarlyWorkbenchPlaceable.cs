using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace BrynStuff.Items.Placeables
{
    public class EarlyWorkbenchPlaceable : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demonic Forgery Station");
            Tooltip.SetDefault("'The hellish corrupt energy is strong' \n Crafts Demonic weapons. \n Behaves like Hardmode forge and anvil.");
        }

        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 14;
            item.maxStack = 99;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = 150;
            item.createTile = TileType<Tiles.EarlyWorkbench>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 30);
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.MythrilAnvil);
            recipe.AddIngredient(ItemID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.HellstoneBar, 30);
            recipe2.AddIngredient(ItemID.HallowedBar, 10);
            recipe2.AddIngredient(ItemID.OrichalcumAnvil);
            recipe2.AddIngredient(ItemID.AdamantiteForge);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
            ModRecipe recipe3 = new ModRecipe(mod);
            recipe3.AddIngredient(ItemID.HellstoneBar, 30);
            recipe3.AddIngredient(ItemID.HallowedBar, 10);
            recipe3.AddIngredient(ItemID.MythrilAnvil);
            recipe3.AddIngredient(ItemID.TitaniumForge);
            recipe3.SetResult(this);
            recipe3.AddRecipe();
            ModRecipe recipe4 = new ModRecipe(mod);
            recipe4.AddIngredient(ItemID.HellstoneBar, 30);
            recipe4.AddIngredient(ItemID.HallowedBar, 10);
            recipe4.AddIngredient(ItemID.OrichalcumAnvil);
            recipe4.AddIngredient(ItemID.TitaniumForge);
            recipe4.SetResult(this);
            recipe4.AddRecipe();
        }
    }
}