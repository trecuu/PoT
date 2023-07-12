using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Microsoft.Xna.Framework;
using Terraria;
using System.Collections.Generic;

namespace PathOfTerraria
{
    public class AttributeUI : UIState
    {
        UIPanel attributePanel;
        UIText attributeText;
        Dictionary<string, UIText> attributeTexts = new Dictionary<string, UIText>();

        public override void OnInitialize()
        {
            attributePanel = new UIPanel();
            attributePanel.SetPadding(0);
            attributePanel.Left.Set(600f, 0f);
            attributePanel.Top.Set(20f, 0f);

            attributeText = new UIText("Attributes \n");
            attributeText.Top.Set(10f, 0f);
            attributeText.Left.Set(10f, 0f);
            attributePanel.Append(attributeText);

            string[] attributeNames = { "Strength", "Dexterity", "Intelligence", "Vitality", "Willpower", "Experience" };
            for (int i = 0; i < attributeNames.Length; i++)
            {
                var text = new UIText(attributeNames[i] + ": ");
                text.Top.Set(10f + 20f * (i+1), 0f);
                text.Left.Set(10f, 0f);
                attributeTexts.Add(attributeNames[i], text);
                attributePanel.Append(text);
            }

            attributePanel.Width.Set(attributeText.GetDimensions().Width + 50f, 0f);
            // attributePanel.Height.Set(attributeText.GetDimensions().Height * 2 + 20f * (attributeNames.Length + 1), 0f);
            attributePanel.Height.Set(attributeText.GetDimensions().Height * 2 + 20f * (attributeNames.Length), 0f);

            Append(attributePanel);
        }

        public override void Update(GameTime gameTime)
        {
            var modPlayer = Main.LocalPlayer.GetModPlayer<Attributes>();

            UpdateAttribute("Strength", modPlayer.str);
            UpdateAttribute("Dexterity", modPlayer.dex);
            UpdateAttribute("Intelligence", modPlayer.intel);
            UpdateAttribute("Vitality", modPlayer.vit);
            UpdateAttribute("Willpower", modPlayer.wil);
            UpdateAttribute("Experience", modPlayer.exp);

            base.Update(gameTime);
        }

        private void UpdateAttribute(string attributeName, long value)
        {
            var text = attributeTexts[attributeName];
            var newText = attributeName + ": " + value;

            if (text.Text != newText)
            {
                text.SetText(newText);
            }
        }
    }
}
