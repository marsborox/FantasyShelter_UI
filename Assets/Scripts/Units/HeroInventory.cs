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
        public int itemSO_ID;

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
    void Awake()
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
            Stash.instance.AddItemGearToStash(gearSlotToUse.item);
            Stash.instance.RemoveItemFromStash(item);
            gearSlotToUse.item = item;
        }
        gearSlotToUse.itemSO_ID = item.itemSO_ID;
        _heroEventHandler.OnStatsChangedEvent();

    }

    public void SaveInventory(Hero_SaveData heroSaveData)
    {
        foreach (GearSlot slot in gearSlots) 
        {
            if (slot.item == null)
            { continue; }
            Item_Gear_SaveData item_Gear_SaveData = new Item_Gear_SaveData();

            item_Gear_SaveData.itemSO_ID = slot.itemSO_ID;

            //might use this if we make items like in diablo
            /*item_Gear_SaveData.slot = slot.item.slot;
            item_Gear_SaveData.health = slot.item.health;
            item_Gear_SaveData.damage = slot.item.damage;
            item_Gear_SaveData.defense = slot.item.defense;
            item_Gear_SaveData.attackSpeed = slot.item.attackSpeed;
            item_Gear_SaveData.movementSpeed = slot.item.movementSpeed;
            item_Gear_SaveData.energy = slot.item.energy;
            */


            heroSaveData.itemSaveList.Add(item_Gear_SaveData);
        }
        
    }
    public void LoadInventory(Hero_SaveData heroSaveData)
    {
        foreach (Item_Gear_SaveData itemGearData in heroSaveData.itemSaveList)
        {
            foreach (Item_Gear_SO itemGearSO in ItemSpawner.instance.itemGearSOs)
            {
                if (itemGearSO.itemSO_ID == itemGearData.itemSO_ID)
                {
                    DressItem(ItemSpawner.instance.ReturnItemGear(itemGearSO));
                    break;
                }
            }
            //ItemSpawner.instance
        }
    }
}
 