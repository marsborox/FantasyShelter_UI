using System;
using System.Collections.Generic;

using UnityEngine;

public class HeroInventoy : MonoBehaviour
{
    private Item _headSlot;
    private Item _chestSlot;
    private Item _weaponSlot;
    private Item _offhandSlot;

    public List <Item> gear = new List<Item>();



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
    private void CheckSlot(Item item)
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
    private void PutOnItem(Item item, ref Item slot)
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
 