using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Items.Accessories
{
	class VegetableSpirit : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Potat power is over its limit\n16 defence");
		}

		public override void SetDefaults()
		{
			item.accessory = true;
			item.width = 32;
			item.height = 32;
			item.value = Item.sellPrice(gold: 10);
			item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<AgedStoneSpirit>());
			recipe.AddIngredient(ModContent.ItemType<AncientVegetableForces>());
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddIngredient(ItemID.Pumpkin);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddTile(TileID.Bowls);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.thrownDamageMult += 0.7f;
			player.lifeRegen += 1;
			player.moveSpeed += 0.02f;
			player.statDefense += 16;
			PotatPlayer.ModPlayer(player).ancientVegetableForces = true;
			PotatPlayer.ModPlayer(player).agedStoneSpirit = true;
		}
	}
}
