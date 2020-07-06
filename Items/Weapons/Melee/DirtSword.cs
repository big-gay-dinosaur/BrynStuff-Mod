using Terraria.ID;
using Terraria.ModLoader;

namespace BrynStuff.Items.Weapons.Melee
{
	public class DirtSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Dirt Sword"); 
			Tooltip.SetDefault("'Get a better sword, noob' \n You're wasting dirt, STOP.");
		}

		public override void SetDefaults() 
		{
			item.damage = 1;
			item.melee = true;
			item.width = 32;
			item.height = 32;
            item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = -3;
			item.value = 10000;
			item.rare = ItemRarityID.Gray;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 5);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}