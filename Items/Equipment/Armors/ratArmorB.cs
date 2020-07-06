using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BrynStuff.Items.Equipment.Armors
{
    [AutoloadEquip(EquipType.Body)]
	public class ratArmorB : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("raet bod");
			Tooltip.SetDefault("This is a modded body armor."
				+ "\nImmunity to 'On Fire!'"
				+ "\n x10 Minion slots, max mana, max life, damage, 100% crit chance, and boosts a bunch of other stuff lolol");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.defense = 1000;
		}

		public override void UpdateEquip(Player player)
		{
			player.buffImmune[BuffID.OnFire] = true;
			player.statManaMax2 *= 10;
			player.maxMinions *= 10;
			player.eocDash = 60;
			player.statDefense *= 100;
			player.noKnockback = true;
			player.allDamageMult = 20000;
			player.jumpSpeedBoost = 1000;
			player.moveSpeed = 1000;
			player.runAcceleration = 100;
			
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}