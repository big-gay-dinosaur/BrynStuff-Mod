using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BrynStuff.Items.Weapons.Melee
{
    public class DinoSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Ethereal Flurry Staff"); 
			Tooltip.SetDefault("'This is a remnant of the dream god as she had gone mad and left her very abnormal domain...' \n " +
				"Shoots a salvo of nebula blasts and lunar flares to rain down and drench your foes in her pandemonic magic");
		}

		public override void SetDefaults() 
		{
			
            item.damage = 420;
			item.magic = true;
			item.width = 32;
			item.height = 32;
            item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 2;
			item.value = 125000;
            item.rare = ItemRarityID.Expert;
			item.UseSound = SoundID.Item9;
			item.autoReuse = false;
			item.shoot = ProjectileID.NebulaBlaze2;
            item.shootSpeed = 32;
			item.mana = 50;
		}
        public override void AddRecipes() 
		{
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentNebula, 60);
			recipe.AddIngredient(ItemID.NebulaArcanum);
			recipe.AddIngredient(ItemID.NebulaBlaze);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float numberProjectiles = 22; // 3, 4, or 5 shots
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			float width = 111;
			position.X = Main.MouseWorld.X - width / 2;
			float cenPos = Main.MouseWorld.X;
			position.Y = player.position.Y - 900;
			for (int i = 0; i < numberProjectiles; i++)
			{
				speedX = (position.X - cenPos) / 10;
				Projectile.NewProjectile(position.X, position.Y, 0, 20, type, 1500, knockBack, player.whoAmI);
				position.X += width / numberProjectiles;
				position.Y -= position.X - cenPos;
			}
			numberProjectiles = 22; // 4 or 5 shots
			position.X = Main.MouseWorld.X;
			position.Y = player.position.Y - 900;
			for (int i = 0; i < numberProjectiles; i++)
			{
				
				position.Y = player.position.Y - 900;
				speedX = Main.rand.NextFloat(-0.5f, 0.5f);
				speedY = 10;
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
																												// If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale;
				position.X = Main.MouseWorld.X + Main.rand.NextFloat(-1, 1) * 5;
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.LunarFlare, damage, knockBack, player.whoAmI);
			}
			return false;
		}
	}
}