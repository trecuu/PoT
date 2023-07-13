using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Microsoft.Xna.Framework;
using Terraria;
using PathOfTerraria.Systems;

namespace PathOfTerraria.UI
{
	public class AttributeUI : UIState
	{
		bool updated = false;
		Attributes modPlayer;

		public override void OnInitialize() {}

		private void firstUpdate() {
			if (updated) return;

			// BUG: Why is the player not being initialized before OnInitialize?
			modPlayer = Main.LocalPlayer.GetModPlayer<Attributes>();

			UIPanel attrsPanel = new UIPanel();
			UIText panelHeader = new UIText("Attributes");
			var singleTextHeight = 20f;

			// Initialize the Panel
			{
				attrsPanel.SetPadding(0);
				attrsPanel.Left.Set(600f, 0f);
				attrsPanel.Top.Set(20f, 0f);
			}

			// Initialize the Text lines
			{
				panelHeader.Top.Set(10f, 0f);
				panelHeader.Left.Set(10f, 0f);
				attrsPanel.Append(panelHeader);

				int i = 1;
				foreach (var stat in modPlayer.attributes)
				{
					UIText statText = new UIText(stat.name + ": " + stat.value);
					statText.Top.Set(10f + (singleTextHeight * (i + 1)), 0f);
					statText.Left.Set(10f, 0f);
					attrsPanel.Append(statText);
					i++;
				}
			}

			// Calculate the sizes
			{
				var fullWidth = 60f;
				var fullHeight = (singleTextHeight * 2) + (modPlayer.attributes.Length * singleTextHeight);
				attrsPanel.Width.Set(panelHeader.GetDimensions().Width + fullWidth, 0f);
				attrsPanel.Height.Set(panelHeader.GetDimensions().Height + fullHeight, 0f);
				attrsPanel.Activate();
			}

			// Finish the panel
			Append(attrsPanel);

			updated = true;
		}

		public override void Update(GameTime gameTime)
		{
			firstUpdate();
			base.Update(gameTime);
		}
	}
}
