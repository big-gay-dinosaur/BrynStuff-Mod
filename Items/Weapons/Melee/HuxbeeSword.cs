using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BrynStuff.Items.Weapons.Melee
{
	public class HuxbeeSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sword of R.Huxbee"); 
			Tooltip.SetDefault("Dedicated to R.Huxbee, a good friend of mine.");
		}

		public override void SetDefaults() 
		{
			item.damage = 1000;
			item.melee = true;
			item.width = 32;
			item.height = 32;
            item.useTime = 1;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = -3;
			item.value = 10000;
            item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
			item.shoot = ProjectileID.GiantBee;
            item.shootSpeed = 40;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float numberProjectiles = 5;
            float rotation = MathHelper.ToRadians(20);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}