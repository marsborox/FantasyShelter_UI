using System.Collections.Generic;
using MessagePack;

using UnityEngine;
[MessagePackObject]
public class Stash_SaveData
{
    //for now we assume wow items
    [Key(0)] public List<int> itemStash_ItemSO_IDs = new List<int>();
}
