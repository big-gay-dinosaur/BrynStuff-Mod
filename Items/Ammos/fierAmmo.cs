using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BrynStuff.Tiles;

namespace BrynStuff.Items.Ammos
{
	public class fierAmmo : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blasphemous Bullet");
			Tooltip.SetDefault("'The chaos god's remnants lie here' \n Good for crouds.");
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 1.5f;
			item.value = 10;
			item.rare = 2;
			item.shoot = mod.ProjectileType("InfernoBlastB");   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 16f;                  //The speed of the projectile
			item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}

		// Give each bullet consumed a 20% chance of granting the Wrath buff for 5 seconds
		public override void OnConsumeAmmo(Player player)
		{
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MusketBall, 50);
			recipe.AddIngredient(mod.ItemType("MurderBar"), 3);
			recipe.AddTile(ModContent.TileType<EarlyWorkbench>());
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}