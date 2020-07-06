using Terraria.ID;
using Terraria.ModLoader;
using BrynStuff.Projectiles;
using Terraria;
using Microsoft.Xna.Framework;

namespace BrynStuff.Items.Ammos
{
    public class SuperKnifeP : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Super-charged Throwing Knife"); 
		}

		public override void SetDefaults() 
		{
			item.damage = 10;
			item.ranged = true;
            item.useTime = 5;
			item.useAnimation = 5;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("SuperKnife");
            item.shootSpeed = 20;
            item.crit = 10;
            item.noUseGraphic = true;
			item.noMelee = true;
            item.consumable = true;
            item.maxStack = 999;
		}


        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ThrowingKnife, 1);
            recipe.AddIngredient(mod.GetItem("Death"), 3);
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
	}
}