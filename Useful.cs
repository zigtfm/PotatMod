using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod
{
	public static class Useful
	{
		public static void DropProjectileOnKill(Projectile projectile, int itemId, int chance)
		{
			if (projectile.owner == Main.myPlayer)
			{
				int item =
				Main.rand.NextBool(chance)
					? Item.NewItem(projectile.getRect(), itemId)
					: 0;

				if (Main.netMode == NetmodeID.MultiplayerClient && item >= 0)
				{
					NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
				}
			}
		}

		public static void BounceProjectileOnTileCollide(Projectile projectile, Vector2 oldVelocity)
		{
			if (projectile.velocity.X != oldVelocity.X)
			{
				projectile.velocity.X = -oldVelocity.X;
				projectile.velocity.X *= 0.5f;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				projectile.velocity.Y = -oldVelocity.Y;
				projectile.velocity.Y *= 0.5f;
			}
		}

		public static void PlaySoundBasedOnProjectileVelocity(Projectile projectile, int soundId)
		{
			float velocityLength = projectile.velocity.Length();
			float volume = velocityLength < 1f ? velocityLength : 1f;
			Main.PlaySound(soundId, x: (int)projectile.position.X, y: (int)projectile.position.Y, volumeScale: volume);
		}

		public static bool PotatShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			position.Y -= 20f;
			Vector2 velocity = new Vector2(speedX, speedY);

			PotatPlayer potatPlayer = PotatPlayer.ModPlayer(player);
			if (potatPlayer.natureForces)
			{
				damage *= 2;
				velocity *= 1.1f;
			}

			Projectile newProjectile = Projectile.NewProjectileDirect(position, velocity, type, damage, knockBack, player.whoAmI);

			if (potatPlayer.natureForces)
			{
				newProjectile.scale = 2f;
				newProjectile.timeLeft += 120;
				for (int i = 0; i < 3; i++)
					Projectile.NewProjectile(position, velocity * Main.rand.NextFloat(0.7f, 1f), type, damage / 3, knockBack, player.whoAmI);
			}

			if (potatPlayer.vegetableWaveAmplifier)
			{
				newProjectile.timeLeft += 30;
				Projectile.NewProjectile(position, velocity * 1.1f, ModContent.ProjectileType<Projectiles.PotatCursed>(), damage / 6, knockBack, player.whoAmI);
			}

			if (potatPlayer.ancientVegetableForces)
			{
				newProjectile.timeLeft += 30;
				Projectile.NewProjectile(position.X, position.Y, velocity.X * 0.7f, velocity.Y - 0.7f, type, damage / 2, knockBack, player.whoAmI);
			}

			if (potatPlayer.agedStoneSpirit)
			{
				newProjectile.timeLeft += 30;
				Projectile newSpirtProjectile = Projectile.NewProjectileDirect(position, velocity * 1.1f, ModContent.ProjectileType<Projectiles.Spirit>(), damage / 2, knockBack, player.whoAmI);

				if (potatPlayer.natureForces)
				{
					newSpirtProjectile.aiStyle = -2;
					newSpirtProjectile.velocity *= 3f;
					newSpirtProjectile.scale = 2f;
				}
			}

			return false;
		}
		#region	https://github.com/tModLoader/tModLoader/blob/master/ExampleMod/Projectiles/Wisp.cs
		public static void HomingAi(Projectile projectile)
        {
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 400f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target)
			{
				AdjustMagnitude(ref move);
				projectile.velocity = (10 * projectile.velocity + move) / 11f;
				AdjustMagnitude(ref projectile.velocity);
			}
		}

		private static void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 6f / magnitude;
			}
		}
		#endregion
	}
}
