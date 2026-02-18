using System.Collections.Generic;
using MessagePack;

[MessagePackObject]
public class Hero_SaveData
{
    [Key(0)] public List<Item_Gear_SaveData> itemSaveList = new List<Item_Gear_SaveData>();
}
