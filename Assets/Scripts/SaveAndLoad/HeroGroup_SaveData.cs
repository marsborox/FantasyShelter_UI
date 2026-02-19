using UnityEngine;
using MessagePack;
using System.Collections.Generic;


[MessagePackObject]
public class HeroGroup_SaveData 
{
    [Key(0)] public string heroGroupName;
    [Key(1)] public int uniqueID;
    [Key(2)] public List<int> heroID_List = new List<int>();
    [Key(3)] public List<int> enemyID_List = new List<int>();

    //[Key(4)] public HeroGroupStash
}
