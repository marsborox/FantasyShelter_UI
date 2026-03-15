using System.Collections.Generic;
using MessagePack;

[MessagePackObject]
public class IDManager_SaveData
{
    [Key(0)] public int nextFreeID;
    [Key(1)] public List<int> freeIDs = new List<int>();
}
