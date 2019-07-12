using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ArmorSocial
{
    public class ArmorSocialItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.social && (item.headSlot != -1 || item.bodySlot != -1 || item.legSlot != -1))
            {
                string secondSetBonus = Main.player[item.owner].GetModPlayer<ArmorSocialPlayer>().secondSetBonus;
                if (secondSetBonus != "")
                {
                    tooltips.Add(new TooltipLine(mod, "SetBonusCheat", "Set Bonus: " + secondSetBonus));
                }
            }
        }
    }
}