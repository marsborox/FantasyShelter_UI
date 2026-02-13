using System.Collections.Generic;
using UnityEngine;


public class HeroInventory : MonoBehaviour
{
    [SerializeField] private HeroEventHandler _heroEventHandler;
    [System.Serializable]
    public class GearSlot 
    {
        public Slot slot;
        public Item_Gear item;

        public GearSlot(Slot inputSlot)
        { 
            slot = inputSlot;
        }
    }

    public GearSlot headSlot = new GearSlot(Slot.HEAD);
    public GearSlot chestSlot = new GearSlot(Slot.CHEST);
    public GearSlot weaponSlot = new GearSlot(Slot.WEAPON_1H);
    public GearSlot offhandSlot = new GearSlot(Slot.OFFHAND);

    public GearSlot dummySlot = new GearSlot(Slot.DUMMY);
    // this is just to fill  unassigned variable a dummy slot
    public List<GearSlot> gearSlots = new List<GearSlot>();
    
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
        gearSlots.Add(headSlot);
        gearSlots.Add(chestSlot);
        gearSlots.Add(weaponSlot);
        gearSlots.Add(offhandSlot);
    }

    public void DressItem(Item_Gear item)
    {
        Slot itemSlot = item.slot;

        GearSlot gearSlotToUse = dummySlot;
        foreach (GearSlot slot in gearSlots)
        {
            if (itemSlot == slot.slot)
            { 
                gearSlotToUse = slot;
                break;
            }
        }
        if (gearSlotToUse == dummySlot)
        {
            Debug.Log("wrong slot must fix");
            return;
        }
        if (gearSlotToUse.item == null)
        {
            Stash.instance.RemoveItemFromStash(item);
            gearSlotToUse.item = item;
        }
        else
        {//if item is already in slot and we are replacing it
            Stash.instance.AddItemToStash(gearSlotToUse.item);
            Stash.instance.RemoveItemFromStash(item);
            gearSlotToUse.item = item;
        }
        _heroEventHandler.OnStatsChangedEvent();
    }
}
 