using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Items.Accessories
{
    class VegetableWaveAmplifier : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Potat bonuses\nIncreases throwing damage and moving speed\n8 defence");
		}

		public override void SetDefaults()
		{
			item.accessory = true;
			item.width = 32;
			item.height = 32;
			item.value = Item.sellPrice(gold: 5);
			item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BlueMoon);
			recipe.AddIngredient(ItemID.ThrowingKnife, 200);
			recipe.AddIngredient(ItemID.Pumpkin);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddTile(TileID.Bowls);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.thrownDamageMult += 0.66f;
			player.moveSpeed += 0.08f;
			player.statDefense += 8;
			PotatPlayer.ModPlayer(player).vegetableWaveAmplifier = true;
		}
    }
}
