using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Items.Accessories
{
	class AgedStoneSpirit : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Potat bonuses\n20% increased throwing damage\n8 defence");
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
			recipe.AddIngredient(ItemID.Ectoplasm, 10);
			recipe.AddIngredient(ItemID.StoneBlock, 999);
			recipe.AddIngredient(ItemID.Pumpkin);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddTile(TileID.Bowls);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.thrownDamageMult += 0.2f;
			player.statDefense += 8;
			PotatPlayer.ModPlayer(player).agedStoneSpirit = true;
		}
	}
}
