using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Items.Accessories
{
    class AncientVegetableForces : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Potat power is under its limit\nIncrease in all variety of stats");
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
			recipe.AddIngredient(ItemID.SoulofFright, 6);
			recipe.AddIngredient(ItemID.SoulofMight, 9);
			recipe.AddIngredient(ItemID.SoulofSight, 6);
			recipe.AddIngredient(ItemID.SpelunkerPotion, 9);
			recipe.AddIngredient(ItemID.Pumpkin);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddTile(TileID.Bowls);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.thrownDamageMult += 0.5f;
			player.moveSpeed += 0.02f;
			player.statDefense += 8;
			player.lifeRegen += 1;
			PotatPlayer.ModPlayer(player).ancientVegetableForces = true;
		}
    }
}
