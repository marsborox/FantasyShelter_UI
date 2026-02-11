using System;
using System.Collections.Generic;

using UnityEngine;

public class HeroInventoy : MonoBehaviour
{
    private Item_Gear _headSlot;
    private Item_Gear _chestSlot;
    private Item_Gear _weaponSlot;
    private Item_Gear _offhandSlot;

    public List <Item_Gear> gear = new List<Item_Gear>();



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddItemSLotsToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AddItemSLotsToList()
    { 
        gear.Add(_headSlot);
        gear.Add(_chestSlot);
        gear.Add(_weaponSlot);
        gear.Add(_offhandSlot);
    }
    private void CheckSlot(Item_Gear item)
    {
        switch (item.slot) 
        {
            case Slot.HEAD:
                PutOnItem(item,ref _headSlot);
                break;
            case Slot.CHEST:
                PutOnItem(item, ref _chestSlot);
                break;
            case Slot.WEAPON_1H:
                PutOnItem(item, ref _weaponSlot);
                break;
            case Slot.OFFHAND:
                PutOnItem(item, ref _offhandSlot);
                break;
             default:
                Debug.Log("_heroInventory. item wrong slot");
                break;
        }
    }
    private void PutOnItem(Item_Gear item, ref Item_Gear slot)
    {
        if (slot == null)
        { slot = item; }
        else
        { 
            //empty slot item to inventory
            slot = item;
        }
    }
}
 