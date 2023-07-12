using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace PathOfTerraria.Items
{
	public class StatsViewer : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.value = 100;
			Item.rare = 2;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			var player = Main.LocalPlayer;
			var modPlayer = player.GetModPlayer<Attributes>();
			
			tooltips.Add(new TooltipLine(Mod, "str", "Strength: " + modPlayer.str));
			tooltips.Add(new TooltipLine(Mod, "dex", "Dexterity: " + modPlayer.dex));
			tooltips.Add(new TooltipLine(Mod, "intel", "Intelligence: " + modPlayer.intel));
			tooltips.Add(new TooltipLine(Mod, "wil", "Willpower: " + modPlayer.wil));
			tooltips.Add(new TooltipLine(Mod, "vit", "Vitality: " + modPlayer.vit));
			tooltips.Add(new TooltipLine(Mod, "exp", "Experience: " + modPlayer.exp));
		}
	}
}
