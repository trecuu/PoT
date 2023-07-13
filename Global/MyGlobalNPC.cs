using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using PathOfTerraria.Items;

namespace PathOfTerraria.NPCs
{
	public class MyGlobalNPC : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			// 5 kills to drop
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Starforge>(), 5));
			// 1 kill to drop
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StatsViewer>(), 1));
		}
	}
}
