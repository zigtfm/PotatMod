using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Items
{
    class InnerNatureFirePotionNonConsumable : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inner Nature Fire Potion");
			Tooltip.SetDefault("Unleashes nature inner forces\nPotat bonuses\nNon-Consumable");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ModContent.ItemType<Items.InnerNatureFirePotion>());
			item.stack = 1;
			item.consumable = false;
		}

        public override string Texture => "PotatMod/Items/InnerNatureFirePotion";

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Items.InnerNatureFirePotion>(), 10);
			recipe.AddIngredient(ItemID.LunarBar, 10);
			recipe.AddIngredient(ItemID.Pumpkin);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddTile(TileID.Bowls);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.needWater = true;
			recipe.needLava = true;
			recipe.needHoney = true;
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
