using System.Collections.Generic;
using MessagePack;

[MessagePackObject]
public class Game_SaveData
{

    [Key(0)] public List<Hero_SaveData> heroSaveList = new List<Hero_SaveData>();
    [Key(1)] public List<Item_Gear_SaveData> itemSaveList = new List<Item_Gear_SaveData>();
    //[Key(2)]
}
