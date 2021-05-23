using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod.Buffs
{
    class NatureForces : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Defensive Buff");
            Description.SetDefault("You are overpowered with nature");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 20;
            player.moveSpeed += 0.1f;
            PotatPlayer.ModPlayer(player).natureForces = true;
        }
    }
}
