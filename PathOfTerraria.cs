using Terraria.ModLoader;
using Terraria.UI;
using System.Collections.Generic;
using Terraria;
using Microsoft.Xna.Framework;
using PathOfTerraria.UI;

namespace PathOfTerraria
{
	public class PathOfTerraria : ModSystem
	{
		internal UserInterface attributeUI;
		internal AttributeUI attributeUIState;
		public override void Load()
		{
			if (!Main.dedServ)
			{
				attributeUI = new UserInterface();
				attributeUIState = new AttributeUI();
				attributeUI.SetState(attributeUIState);
			}
		}
		public override void UpdateUI(GameTime gameTime)
		{
			if (attributeUI?.CurrentState != null) {
				attributeUI.Update(gameTime);
			}
		}
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
			if (inventoryIndex != -1)
			{
				layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
					"MyMod: Attributes",
					delegate {
						if (Main.playerInventory)
							attributeUI?.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
	}
}
