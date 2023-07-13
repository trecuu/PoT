using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using System.Linq;

namespace PathOfTerraria.Systems
{
	public enum Attribute {
		STRENGTH,
		DEXTERITY,
		INTELLIGENCE,
		VITALITY,
		WILLPOWER
	}

	public class Stat {
		public Attribute type;
		public string name;
		public int value;

		public Stat(Attribute type, string name, int value) {
			this.type = type;
			this.name = name;
			this.value = value;
		}

		public override string ToString()
		{
			return name + ": " + value;
		}
	}

	public class Attributes : ModPlayer
	{
		public Stat[] attributes = new Stat[5];
		private float originalMeleeDamage;
		private double experience;

		private Stat GetAttribute(Attribute type) {
			return attributes.Where<Stat>(attr => attr.type == type).Single<Stat>();
		}

		public override void Initialize()
		{
			if (false) {
				// Load
			} else {
				// Initialize
				attributes[0] = new Stat(Attribute.STRENGTH, "Strength", 10);
				attributes[1] = new Stat(Attribute.DEXTERITY, "Dexterity", 10);
				attributes[2] = new Stat(Attribute.INTELLIGENCE, "Intelligence", 10);
				attributes[3] = new Stat(Attribute.VITALITY, "Vitality", 10);
				attributes[4] = new Stat(Attribute.WILLPOWER, "Willpower", 10);
				originalMeleeDamage = Player.GetDamage(DamageClass.Melee).Base; // Store the original melee damage
				experience = 0;
			}
		}

		public override void ResetEffects()
		{
			foreach (var attribute in attributes)
			{
				attribute.value = 10;
			}

			// Reset the melee damage to the original value
			Player.GetDamage(DamageClass.Melee).Base = originalMeleeDamage;
		}

		public override void PostUpdate()
		{
			// This will increase melee damage by 1% for each point in strength
			Player.GetDamage(DamageClass.Melee).Base += GetAttribute(Attribute.STRENGTH).value;
		}

		// public override void SavePlayer(BinaryWriter writer)
		// {
		// 	foreach (var stat in attributes)
		// 	{
		// 		writer.Write(stat);
		// 	}
		// }

		// public override void LoadPlayer(BinaryReader reader, bool cloudSave)
		// {
		// 	str = reader.ReadInt32();
		// 	dex = reader.ReadInt32();
		// 	intel = reader.ReadInt32();
		// 	vit = reader.ReadInt32();
		// 	wil = reader.ReadInt32();
		// 	exp = reader.ReadInt64();
		// }

		// public override void NetSend(BinaryWriter writer)
		// {
		// 	foreach (var stat in attributes)
		// 	{
		// 		writer.Write(stat);
		// 	}
		// }

		// public override void NetReceive(BinaryReader reader)
		// {
		// 	str = reader.ReadInt32();
		// 	dex = reader.ReadInt32();
		// 	intel = reader.ReadInt32();
		// 	vit = reader.ReadInt32();
		// 	wil = reader.ReadInt32();
		// 	exp = reader.ReadInt64();
		// }
	}
}
