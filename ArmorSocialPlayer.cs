using System;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ArmorSocial
{
    public class ArmorSocialPlayer : ModPlayer
    {
        public string secondSetBonus = "";

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            if (ArmorSocial.ArmorSocialConfig.ArmorSocialMode != ArmorSocial.setBonusOnly)
            {
                for (int i = 10; i < 12; i++)
                {
                    player.VanillaUpdateEquip(player.armor[i]);
                    if (ArmorSocial.ArmorSocialConfig.ArmorSocialMode == ArmorSocial.noDefense)
                    {
                        player.statDefense -= player.armor[i].defense;
                    }
                }
            }
        }
    }
}