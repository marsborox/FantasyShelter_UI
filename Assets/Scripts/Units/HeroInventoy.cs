using NUnit.Framework;

using System;
using System.Collections.Generic;

using UnityEngine;

public class HeroInventoy : MonoBehaviour
{
    Item headSlot;
    Item chestSlot;
    Item weaponSlot;
    Item offhandSlot;

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

    void AddItemSLotsToList()
    { 
        gear.Add(headSlot);
        gear.Add(chestSlot);
        gear.Add(weaponSlot);
        gear.Add(offhandSlot);
    }

    void CheckSlot(Item item)
    {
        switch (item.slot) 
        {
            case Slot.HEAD:
                PutOnItem(item,ref headSlot);
                break;
            case Slot.CHEST:
                PutOnItem(item, ref chestSlot);
                break;
            case Slot.WEAPON_1H:
                PutOnItem(item, ref weaponSlot);
                break;
            case Slot.OFFHAND:
                PutOnItem(item, ref offhandSlot);
                break;
             default:
                Debug.Log("heroInventory. item wrong slot");
                break;
        }
    }

    void PutOnItem(Item item, ref Item slot)
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
 