using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using PathOfTerraria.Systems;

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

			foreach (var stat in modPlayer.attributes)
			{
				tooltips.Add(new TooltipLine(Mod, stat.name.ToLower(), stat.ToString()));
			}
		}
	}
}
