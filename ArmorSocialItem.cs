using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ArmorSocial
{
    public class ArmorSocialItem : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public bool social;

        public ArmorSocialItem()
        {
            social = false;
        }
        
        public override GlobalItem Clone(Item item, Item itemClone)
        {
            ArmorSocialItem myClone = (ArmorSocialItem) base.Clone(item, itemClone);
            myClone.social = social;
            return myClone;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if ((social || item.social) && (item.headSlot != -1 || item.bodySlot != -1 || item.legSlot != -1))
            {
                if (ArmorSocial.ArmorSocialConfig.ArmorSocialMode == ArmorSocial.noDefense)
                {
                    for (var i = 0; i < tooltips.Count; i++)
                    {
                        if (tooltips[i].Name == "Defense")
                        {
                            tooltips.RemoveAt(i);
                            i--;
                        }
                    }
                }
                
                
                string secondSetBonus = Main.player[item.owner].GetModPlayer<ArmorSocialPlayer>().secondSetBonus;
                if (secondSetBonus != "")
                {
                    tooltips.Add(new TooltipLine(mod, "SetBonusCheat", "Set Bonus: " + secondSetBonus));
                }
            }
        }
        
    }
}