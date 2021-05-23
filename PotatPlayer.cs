using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PotatMod
{
    class PotatPlayer : ModPlayer
    {
        public static PotatPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<PotatPlayer>();
        }

        public bool woodenShield = false;
        public int woodenShieldMult = 0;
        public bool vegetableWaveAmplifier = false;
        //public bool throwingGlove = false;
        public bool ancientVegetableForces = false;
        public bool agedStoneSpirit = false;
        public bool natureForces = false;

        public override void ResetEffects()
        {
            woodenShield = false;
            woodenShieldMult = 0;
            vegetableWaveAmplifier = false;
            //throwingGlove = false;
            ancientVegetableForces = false;
            agedStoneSpirit = false;
            natureForces = false;
        }
    }
}
