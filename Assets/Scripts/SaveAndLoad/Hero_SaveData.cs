using System.Collections.Generic;
using MessagePack;

[MessagePackObject]
public class Hero_SaveData
{
    [Key(0)] public List<Item_Gear_SaveData> itemSaveList = new List<Item_Gear_SaveData>();

    [Key(1)] public string heroName;
    [Key(2)] public int uniqueID;

    [Key(3)] public int health;
    [Key(4)] public int damage;
    [Key(5)] public int defense;
    [Key(6)] public int attackSpeed;
    [Key(7)] public int movementSpeed;
    [Key(8)] public int energy;


    [Key(9)] public int idGroupHeroIsIn;

}
