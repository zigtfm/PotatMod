using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Items
{
    class InnerNatureFirePotion : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Unleashes nature inner forces\nPotat bonuses");
		}

		public override void SetDefaults()
		{
			//item.potion = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.EatingUsing;
			item.value = Item.sellPrice(silver: 25);
			item.rare = ItemRarityID.Red;
			item.UseSound = SoundID.Item1;
			item.consumable = true;
			item.maxStack = 69;
			item.buffTime = 1800;
			item.buffType = ModContent.BuffType<Buffs.NatureForces>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentNebula);
			recipe.AddIngredient(ItemID.FragmentSolar);
			recipe.AddIngredient(ItemID.FragmentStardust);
			recipe.AddIngredient(ItemID.FragmentVortex);
			recipe.AddIngredient(ItemID.IronskinPotion, 2);
			recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddIngredient(ItemID.Pumpkin);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddTile(TileID.Bowls);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}
