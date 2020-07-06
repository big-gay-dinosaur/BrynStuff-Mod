using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography.X509Certificates;

namespace BrynStuff.Projectiles.Weapon
{
    public class InfernoBlastB : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Homing[projectile.type] = true;
            DisplayName.SetDefault("Example Bullet");     //The English name of the projectile
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 10;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 2;        //The recording mode
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 8;               //The width of projectile hitbox
            projectile.height = 8;              //The height of projectile hitbox
            projectile.aiStyle = 1;             //The ai style of the projectile, please reference the source code of Terraria
            projectile.friendly = true;         //Can the projectile deal damage to enemies?
            projectile.hostile = false;         //Can the projectile deal damage to the player?
            projectile.ranged = true;           //Is the projectile shoot by a ranged weapon?
            projectile.penetrate = 1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            projectile.timeLeft = 300;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            projectile.alpha = 255;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
            projectile.light = 0.5f;            //How much light emit around the projectile
            projectile.ignoreWater = true;          //Does the projectile's speed be influenced by water?
            projectile.tileCollide = true;          //Can the projectile collide with tiles?
            projectile.extraUpdates = 0;            //Set to above 0 if you want the projectile to update multiple time in a frame
            aiType = ProjectileID.Bullet;
            projectile.penetrate = 6;
           
        }
        
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
        }

      
        public override bool OnTileCollide(Vector2 oldVelocity) { 
            projectile.Kill();
            return false;
        }
        int damageMultiplier = 1;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            damage *= damageMultiplier;
            damageMultiplier++;
            projectile.velocity.X *= 2f;
            projectile.velocity.Y *= 2f;
            Projectile.NewProjectile(projectile.position, projectile.velocity, ProjectileID.InfernoFriendlyBlast, 100, -15, projectile.owner);
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();

            }

            else
            {

                base.OnHitNPC(target, damage, knockback, crit);
                target.AddBuff(BuffID.Daybreak, 360, quiet: false);
                target.AddBuff(BuffID.Ichor, 360, quiet: false);
                target.AddBuff(BuffID.CursedInferno, 360, quiet: false);
                Vector2 vecvel;
                vecvel.X = projectile.velocity.X;
                vecvel.Y = projectile.velocity.Y;
               
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override void Kill(int timeLeft)
        {
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
        public override void AI()
        {
 
            if (projectile.alpha > 70)
            {
                projectile.alpha -= 15;
                if (projectile.alpha < 70)
                {
                    projectile.alpha = 70;
                }
            }
        }

    }
}