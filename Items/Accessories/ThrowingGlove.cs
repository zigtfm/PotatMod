using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Items.Accessories
{
    class ThrowingGlove : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Potat bonuses\n33% increased throwing damage\nKnockback resistance\nFire resistance\n4 defence");
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
			recipe.AddIngredient(ItemID.TitanGlove);
			recipe.AddIngredient(ItemID.ObsidianShield);
			recipe.AddIngredient(ItemID.TitaniumBar);
			recipe.AddIngredient(ItemID.Pumpkin);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddTile(TileID.Bowls);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.thrownVelocity += 4f;
			player.thrownDamageMult += 0.33f;
			player.noKnockback = true;
			player.fireWalk = true;
			player.statDefense += 4;
			//PotatPlayer.ModPlayer(player).throwingGlove = true;
		}
    }
}
