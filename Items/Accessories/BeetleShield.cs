using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Items.Accessories
{
    class BeetleShield: ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Converts all defence into Potat damage\nIncreased life regeneration\nPlace in the last accessory slot\n9 defence");
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
			recipe.AddIngredient(ModContent.ItemType<WoodenShield>());
			recipe.AddIngredient(ItemID.ShinyStone);
			recipe.AddIngredient(ItemID.BeetleHusk, 10);
			recipe.AddIngredient(ItemID.Pumpkin);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddTile(TileID.Bowls);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			//PotatPlayer.ModPlayer(player).woodenShieldMult = player.statDefense + 1;
			player.thrownDamageMult += (player.statDefense + 9) / 25;
			player.lifeRegen += 2;
			player.statDefense = 0;
			//PotatPlayer.ModPlayer(player).woodenShield = true;
		}
    }
}
