using System;
using Microsoft.Xna.Framework.Graphics;
using On.Terraria;
using On.Terraria.UI;
using Terraria.ModLoader;
using Item = Terraria.Item;
using Main = Terraria.Main;

namespace ArmorSocial
{
	class ArmorSocial : Mod
	{
		internal static ArmorSocialConfig ArmorSocialConfig;
		public static readonly string setBonusOnly = "Set Bonuses Only";
		public static readonly string noDefense = "Everything Except Defense";
		public static readonly string allEffects = "All Armor Effects";
		
		public ArmorSocial()
		{
			Properties = new ModProperties()
			{
				Autoload = true
			};
		}


		public override void Load()
		{
			Player.UpdateArmorSets += PlayerOnUpdateArmorSets;
			ItemSlot.MouseHover_ItemArray_int_int += ItemSlotOnMouseHoverItemArrayIntInt;
		}

		public override void Unload()
		{
			ArmorSocialConfig = null;
		}

		private void PlayerOnUpdateArmorSets(Player.orig_UpdateArmorSets orig, Terraria.Player self, int i)
		{
			int head = self.head;
			int body = self.body;
			int legs = self.legs;
			Item armor0 = self.armor[0].Clone();
			Item armor1 = self.armor[1].Clone();
			Item armor2 = self.armor[2].Clone();
			
			int solarCounter = self.solarCounter;
			bool vortexStealthActive = self.vortexStealthActive;
			float beetleCounter = self.beetleCounter;
			
			orig(self, i);
			String setBonus = self.setBonus;
			
			int solarCounter2 = self.solarCounter;
			bool vortexStealthActive2 = self.vortexStealthActive;
			float beetleCounter2 = self.beetleCounter;
			bool stadustBuff = self.FindBuffIndex(187) != -1;

			self.head = self.armor[10].headSlot;
			self.body = self.armor[11].bodySlot;
			self.legs = self.armor[12].legSlot;
			self.armor[0] = self.armor[10];
			self.armor[1] = self.armor[11];
			self.armor[2] = self.armor[12];
			self.solarCounter = solarCounter;
			self.vortexStealthActive = vortexStealthActive;
			self.beetleCounter = beetleCounter;

			orig(self, i);
			self.GetModPlayer<ArmorSocialPlayer>().secondSetBonus = self.setBonus;
			if (self.head == 101 && self.body == 66 && self.body == 55 && ArmorSocialConfig.BalanceSpectreHealing && ArmorSocialConfig.ArmorSocialMode == setBonusOnly)
			{
				self.magicDamage -= .4f;
			}

			self.solarCounter = Math.Max(self.solarCounter, solarCounter2);
			self.vortexStealthActive = self.vortexStealthActive || vortexStealthActive2;
			self.beetleCounter = Math.Max(self.beetleCounter, beetleCounter2);
			if (stadustBuff && self.FindBuffIndex(187) == -1)
			{
				self.AddBuff(187, 3600);
			}

			self.head = head;
			self.body = body;
			self.legs = legs;
			self.armor[0] = armor0;
			self.armor[1] = armor1;
			self.armor[2] = armor2;
			self.setBonus = setBonus;
		}
		
		

		private void ItemSlotOnMouseHoverItemArrayIntInt(ItemSlot.orig_MouseHover_ItemArray_int_int orig, Item[] inv, int context, int slot)
		{
			orig(inv, context, slot);
			if (inv[slot].type > 0 && inv[slot].stack > 0 && context == 9 && ArmorSocialConfig.ArmorSocialMode != setBonusOnly)
			{
				Main.HoverItem.wornArmor = true;
				Main.HoverItem.social = false;
				Main.HoverItem.GetGlobalItem<ArmorSocialItem>().social = true;
			}
		}
	}
}
