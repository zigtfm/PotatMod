using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Items.Accessories
{
    class WoodenShield: ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Converts all defence into Potat damage\nPlace in the last accessory slot\n1 defence");
		}

		public override void SetDefaults()
		{
			item.accessory = true;
			item.width = 32;
			item.height = 32;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.EoCShield);
			recipe.AddIngredient(ItemID.LivingWoodWand);
			recipe.AddIngredient(ItemID.Wood, 10);
			recipe.anyWood = true;
			recipe.AddIngredient(ItemID.Pumpkin);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddTile(TileID.Bowls);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			//PotatPlayer.ModPlayer(player).woodenShieldMult = player.statDefense + 1;
			player.thrownDamageMult += (player.statDefense + 1) / 25;
			player.statDefense = 0;
			//PotatPlayer.ModPlayer(player).woodenShield = true;
		}
    }
}
