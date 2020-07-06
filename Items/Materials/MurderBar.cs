using Terraria.ID;
using Terraria.ModLoader;
using BrynStuff.Tiles;

namespace BrynStuff.Items.Materials
{
	public class MurderBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Profane Bar");
			Tooltip.SetDefault("Shut up Calamity fans");
		}
		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.value = 1000;
			item.rare = 3;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("HardmodeMuder"), 2);
			recipe.AddIngredient(ItemID.HallowedBar, 1);
			recipe.AddTile(ModContent.TileType<EarlyWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}