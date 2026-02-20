using System.Collections.Generic;

using UnityEngine;

public class Stash : Singleton<Stash>
{
    public static new Stash instance => Singleton<Stash>.instance;
    
    public List<Item> itemGearList = new List<Item>();
    public List<Item> materialList = new List<Item>();

    private void Awake()
    {
        base.Awake();
    }

    public void AddItemGearToStash(Item_Gear item)
    { 
        itemGearList.Add(item);
        GlobalEventHandler.instance.StashChanged();
    }
    public void AddItemToStash(Item_Material item)
    {
        materialList.Add(item);
        GlobalEventHandler.instance.StashChanged();
    }



    public void RemoveItemFromStash(Item_Gear item)
    { 
        itemGearList.Remove(item);
        GlobalEventHandler.instance.StashChanged();
    }
    public void RemoveItemFromStash(Item_Material item)
    {
        materialList.Remove(item);
        GlobalEventHandler.instance.StashChanged();
    }

    public Stash_SaveData SaveStash()
    { 
        Stash_SaveData data = new Stash_SaveData();

        foreach (Item item in itemGearList) 
        {
            data.itemStash_ItemSO_IDs.Add(item.itemSO_ID);
        }
        return data;
    }
    public void LoadStash(Stash_SaveData data)
    {
        foreach(int id in data.itemStash_ItemSO_IDs)
        {
            foreach(Item_Gear_SO itemGearSO in ItemSpawner.instance.itemGearSOs)
            {
                if (id == itemGearSO.itemSO_ID)
                {
                    ItemSpawner.instance.CreateItem(itemGearSO);
                    break;
                }
            }
        }
    }
}
