using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Projectiles
{
	class Spirit : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ModContent.ProjectileType<Projectiles.Potat>());
			projectile.width = 32;
			projectile.height = 32;
			projectile.penetrate = 6;
			projectile.timeLeft = 300;
			projectile.alpha = 128;
			projectile.tileCollide = false;
			projectile.aiStyle = -1;
		}

		public override void Kill(int timeLeft)
		{
			Vector2 pos = projectile.position;

			// Play Sound
			Main.PlaySound(SoundID.Splash, pos);

			// Dust
			for (int i = 0; i < 20; i++)
			{
				Dust dust = Dust.NewDustDirect(pos, 32, 32, DustID.DrillContainmentUnit);
				dust.noGravity = true;
			}
		}

		public override void AI()
		{
			if (projectile.aiStyle == -1)
				projectile.velocity *= 0.96420f;
			else
            {
				Useful.HomingAi(projectile);
            }

			Dust dust = Dust.NewDustDirect(projectile.position, 32, 32, DustID.DrillContainmentUnit);
			dust.noGravity = true;
		}
	}
}
