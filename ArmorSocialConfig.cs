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
            foreach (var remoteClient in Netplay.Clients)
            {
                if (remoteClient.Socket.GetRemoteAddress().IsLocalHost() && remoteClient.Id == whoAmI)
                {
                    return true;
                }
            }

            message = "Only localhost can change";
            return false;
        }
    }
    
    
}