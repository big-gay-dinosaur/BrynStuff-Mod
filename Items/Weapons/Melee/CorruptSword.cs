using Terraria.ID;
using Terraria.ModLoader;

namespace BrynStuff.Items.Weapons.Melee
{
	public class CorruptSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Night's Painful bite"); 
			Tooltip.SetDefault("'The night is here, surrender your weapons' \n");
		}

		public override void SetDefaults() 
		{
			item.damage = 20;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 30;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = ProjectileID.CursedFlameFriendly;
            item.shootSpeed = 20;
            item.crit = 10;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar, 15);
            recipe.AddIngredient(ItemID.RottenChunk, 6);
            recipe.AddIngredient(ItemID.ShadowScale, 20);
            recipe.AddIngredient(mod.GetItem("CorruptMaterial"), 60);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}