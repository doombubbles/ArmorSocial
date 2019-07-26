using System.ComponentModel;
using IL.Terraria;
using Terraria.ModLoader.Config;
using Main = Terraria.Main;
using Netplay = Terraria.Netplay;

namespace ArmorSocial
{
    public class ArmorSocialConfig : ModConfig
    {
        
        public override ConfigScope Mode => ConfigScope.ServerSide;

        
        
        [OptionStrings(new[] {"Set Bonuses Only", "Everything Except Defense", "All Armor Effects"})]
        [DefaultValue("Set Bonuses Only")]
        [Label("ArmorSocial Mode")]
        [DrawTicks]
        public string ArmorSocialMode { get; set; }
        
        [DefaultValue(true)]
        [Label("Balance Spectre Healing Set Bonus")]
        public bool BalanceSpectreHealing{ get; set; }

        public override void OnLoaded()
        {
            ArmorSocial.ArmorSocialConfig = this;
        }

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            if (whoAmI == 0) {
                message = "Changes accepted!";
                return true;
            }
            message = "You have no rights to change mod Configuration.";
            return false;
        }
    }
    
    
}