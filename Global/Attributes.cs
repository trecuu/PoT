using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;

public class Attributes : ModPlayer
{
    public int str;
    public int dex;
    public int intel;
    public int vit;
    public int wil;
    public long exp;
    private float originalMeleeDamage;

    public override void Initialize()
    {
        originalMeleeDamage = Player.GetDamage(DamageClass.Melee).Base; // Store the original melee damage
    }

    public override void ResetEffects()
    {
        str = 10;
        dex = 0;
        intel = 0;
        vit = 0;
        wil = 0;
        exp = 0;
        Player.GetDamage(DamageClass.Melee).Base = originalMeleeDamage; // Reset the melee damage to the original value
    }

    public override void PostUpdate()
    {
        Player.GetDamage(DamageClass.Melee).Base += str; // This will increase melee damage by 1% for each point in strength
    }

    // public override void SavePlayer(BinaryWriter writer)
    // {
    //     writer.Write(str);
    //     writer.Write(dex);
    //     writer.Write(intel);
    //     writer.Write(vit);
    //     writer.Write(wil);
    //     writer.Write(exp);
    // }

    // public override void LoadPlayer(BinaryReader reader, bool cloudSave)
    // {
    //     str = reader.ReadInt32();
    //     dex = reader.ReadInt32();
    //     intel = reader.ReadInt32();
    //     vit = reader.ReadInt32();
    //     wil = reader.ReadInt32();
    //     exp = reader.ReadInt64();
    // }

    // public override void NetSend(BinaryWriter writer)
    // {
    //     writer.Write(str);
    //     writer.Write(dex);
    //     writer.Write(intel);
    //     writer.Write(vit);
    //     writer.Write(wil);
    //     writer.Write(exp);
    // }

    // public override void NetReceive(BinaryReader reader)
    // {
    //     str = reader.ReadInt32();
    //     dex = reader.ReadInt32();
    //     intel = reader.ReadInt32();
    //     vit = reader.ReadInt32();
    //     wil = reader.ReadInt32();
    //     exp = reader.ReadInt64();
    // }
}
