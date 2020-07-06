using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BrynStuff.Items.Weapons.Melee
{
	public class TarkSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sword of Tark"); 
			Tooltip.SetDefault("Dedicated to Tark.");
		}

		public override void SetDefaults() 
		{
			item.damage = 420;
			item.melee = true;
			item.width = 32;
			item.height = 32;
            item.useTime = 1;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 125000;
            item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
			item.shoot = ProjectileID.StarWrath;
            item.shootSpeed = 32;
		}
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StarWrath,1);
			recipe.AddIngredient(ItemID.BloodButcherer,1);
			recipe.AddTile(412); //using ancient manipulator
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}