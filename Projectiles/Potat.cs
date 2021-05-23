using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Projectiles
{
    class Potat : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Potat");
		}

		public override void SetDefaults()
		{
			projectile.width = 64;
			projectile.height = 64;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 120;
		}

		public override void Kill(int timeLeft)
		{
			Vector2 pos = projectile.position;

			// Play Sound
			Main.PlaySound(SoundID.Dig, pos);

			// Dust
			for (int i = 0; i < 20; i++)
			{
				Dust dust = Dust.NewDustDirect(pos, 64, 64, DustID.Copper);
				dust.noGravity = true;
			}			
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			Useful.BounceProjectileOnTileCollide(projectile, oldVelocity);
			Useful.PlaySoundBasedOnProjectileVelocity(projectile, SoundID.Dig);
			return false;
		}

        public override void AI()
		{
			projectile.velocity.Y += 0.1f;
			projectile.rotation += 0.05f;
		}
	}
}
