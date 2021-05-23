using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Items
{
	public class PotatNonConsumable : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Potat");
			Tooltip.SetDefault("Non-Consumable\n(c) zig");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(ModContent.ItemType<Items.Potat>());
			item.stack = 1;
			item.consumable = false;
		}

        public override string Texture => ("PotatMod/Items/Potat");

        public override void AddRecipes()
		{
			// Non-Consumable
			#region After Cultist
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofNight, 3);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddIngredient(ModContent.ItemType<Items.Potat>(), 333);
			recipe.AddIngredient(ItemID.Pumpkin);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddTile(TileID.Bowls);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.AddTile(TileID.LunarCraftingStation); // Ancient Manupulartor
			recipe.SetResult(this);
			recipe.AddRecipe();
			#endregion
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
			=> Useful.PotatShoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
	}
}