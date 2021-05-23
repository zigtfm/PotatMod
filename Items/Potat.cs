using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Items
{
	public class Potat : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("(c) zig");
		}

		public override void SetDefaults()
		{
			item.damage = 40;
			item.thrown = true;
			item.width = 58;
			item.height = 58;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 25);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.consumable = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.shootSpeed = 6;
			item.shoot = ModContent.ProjectileType<Projectiles.Potat>();
			item.maxStack = 333;
		}

		public override void AddRecipes()
		{
			// Default Recipe
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Pumpkin);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddTile(TileID.Bowls);
			recipe.SetResult(this);
			recipe.AddRecipe();

			#region Post EoW or BoC
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowScale);
			recipe.AddIngredient(ItemID.Pumpkin);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddTile(TileID.Bowls);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TissueSample);
			recipe.AddIngredient(ItemID.Pumpkin);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddTile(TileID.Bowls);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
			#endregion

			#region Hardmode
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TurtleShell);
			recipe.AddIngredient(ItemID.Pumpkin);
			recipe.AddIngredient(ItemID.DaybloomSeeds);
			recipe.AddTile(TileID.Bowls);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this, 111);
			recipe.AddRecipe();
			#endregion
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
			=> Useful.PotatShoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
    }
}