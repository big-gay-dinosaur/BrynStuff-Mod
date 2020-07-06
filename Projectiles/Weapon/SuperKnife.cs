using System;
using BrynStuff.Items.Ammos;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BrynStuff.Projectiles.Weapon
{
    public class SuperKnife : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("SuperKnife");
        }

        public override void SetDefaults()
        {
            projectile.arrow = true;
            projectile.width = 31;
            projectile.height = 31;
            projectile.aiStyle = 2;
            projectile.friendly = true;
            projectile.ranged = true;
            aiType = ProjectileID.ThrowingKnife;
            projectile.penetrate = 1;
            projectile.timeLeft = 60 * 6;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Main.rand.Next(3) == 0)
            {
                Item.NewItem(projectile.position, ModContent.ItemType<SuperKnifeP>(), 1);
                return base.OnTileCollide(oldVelocity);
            };
            projectile.Kill();
            return base.OnTileCollide(oldVelocity);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(3) == 0)
            {
                Item.NewItem(projectile.position, ModContent.ItemType<SuperKnifeP>(), 1);
            };
            target.AddBuff(BuffID.OnFire, 60, quiet:true);
        }

        // Additional hooks/methods here.
    }
}