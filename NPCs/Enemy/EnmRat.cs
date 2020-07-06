using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Security.AccessControl;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Audio;

namespace BrynStuff.NPCs.Enemy
{
    // Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
    public class EnmRat : ModNPC
	{
		readonly static List<int> UseableAi = new List<int>()
		{0, 1, 2, 3, 4, 5, 6, 8, 9, 10, 11, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 47, 48, 49, 50, 51, 52, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 76, 77, 78, 79, 80, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111};
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("raet");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[1];
		}

		public override void SetDefaults()
		{
			npc.width = 512;
			npc.height = 512;     
			npc.damage = 1000;
			npc.defense = 1000;
			npc.lifeMax = 5000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
			npc.value = 50f;
			npc.knockBackResist = 5f;
			npc.aiStyle = 22;
			aiType = NPCID.Paladin;
			banner = Item.NPCtoBanner(NPCID.Zombie);
			bannerItem = Item.BannerToItem(banner);
			
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.Overworld.Chance * 10f;
		}

		int AiRand;

        public override void HitEffect(int hitDirection, double damage)
		{
			float speedX = 0;
			float speedY = 0;
			Vector2 position;
			position = npc.position;
			float numberProjectiles = 18;
			float rotation = MathHelper.ToRadians(360);
			position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .2f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.PaladinsHammerHostile, npc.damage, 15, npc.whoAmI);
			}
		}
	}
}