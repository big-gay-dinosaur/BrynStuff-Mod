using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BrynStuff.Projectiles.Weapon
{
    public class Fireball : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fireball");
        }

        public override void SetDefaults()
        {
            projectile.arrow = true;
            projectile.width = 31;
            projectile.height = 31;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.ranged = true;
            aiType = ProjectileID.EnchantedBoomerang;
            projectile.penetrate = -1;
            projectile.timeLeft = 60 * 6;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
        }

        // Additional hooks/methods here.
    }
}