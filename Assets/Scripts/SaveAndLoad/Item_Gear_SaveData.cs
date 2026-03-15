using MessagePack;
using UnityEngine;
[MessagePackObject]
public class Item_Gear_SaveData
{
    [Key(0)] public Slot slot;
    [Key(1)] public int health;
    [Key(2)] public int damage;
    [Key(3)] public int defense;
    [Key(4)] public int attackSpeed;
    [Key(5)] public int movementSpeed;
    [Key(6)] public int energy;
    [Key(7)] public int itemSO_ID;

    //owner - need some ID assigningSystem
}
