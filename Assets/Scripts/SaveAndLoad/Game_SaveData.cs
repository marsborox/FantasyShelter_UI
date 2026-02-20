using System.Collections.Generic;
using MessagePack;

[MessagePackObject]
public class Game_SaveData
{
    [Key(0)] public IDManager_SaveData id_ManagerData;
    [Key(1)] public Stash_SaveData stash_SaveData;

    [Key(2)] public List<Hero_SaveData> heroSaveList = new List<Hero_SaveData>();
    [Key(3)] public List<Item_Gear_SaveData> itemSaveList = new List<Item_Gear_SaveData>();
    [Key(4)] public List<HeroGroup_SaveData> heroGroupSaveList = new List<HeroGroup_SaveData>();
    
    //[Key(2)]
}
