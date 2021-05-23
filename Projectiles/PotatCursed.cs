using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Projectiles
{
	class PotatCursed : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ModContent.ProjectileType<Projectiles.Potat>());
			projectile.penetrate = 3;
			projectile.alpha = 128;
		}

		public override void Kill(int timeLeft)
		{
			Vector2 pos = projectile.position;

			// Play Sound
			Main.PlaySound(SoundID.Item20, pos);

			// Dust
			for (int i = 0; i < 20; i++)
			{
				Dust dust = Dust.NewDustDirect(pos, 64, 64, DustID.CursedTorch);
				dust.noGravity = true;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Useful.BounceProjectileOnTileCollide(projectile, oldVelocity);
			Useful.PlaySoundBasedOnProjectileVelocity(projectile, SoundID.Item20.SoundId);
			return false;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(BuffID.CursedInferno, 300);
            base.OnHitNPC(target, damage, knockback, crit);
        }

        public override void AI()
		{
			projectile.velocity.Y += 0.1f;
			projectile.rotation += 0.05f;
		}
	}
}
