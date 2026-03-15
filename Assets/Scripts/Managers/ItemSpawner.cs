using System.Collections.Generic;

using UnityEngine;

public class ItemSpawner : Singleton<ItemSpawner>
{
    public List<Item_Gear_SO> itemGearSOs = new List<Item_Gear_SO>();
    public Item_Gear_SO testItemGearSO;

    [SerializeField] private Item_Gear itemGearPrefab;
    [SerializeField] private Item_Material itemMaterialPrefab;
    //some instance / prefab of item
    private void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        //TestSpawnXAmountItems();
        //TestSpawnEachItem();
    }
    public void CreateItem(Item_SO itemSO)
    {
        if (itemSO is Item_Gear_SO) 
        {
            CreateItemGear(itemSO);
        }
    }
    public void CreateItemGear(Item_SO itemSO)
    { 
        Item_Gear newItem = Instantiate(itemGearPrefab);
        newItem.SetItemProperties(((Item_Gear_SO)itemSO));
        Stash.instance.AddItemGearToStash(newItem);
    }
    public void CreateItemMaterial(Item_SO itemSO)
    { 
        Item_Material newItem = Instantiate(itemMaterialPrefab);
        newItem.SetItemProperties(((Item_Material_SO)itemSO));
        Stash.instance.AddItemToStash(newItem);
    }

    public Item_Gear ReturnItemGear(Item_SO itemSO)
    {
        Item_Gear newItem = Instantiate(itemGearPrefab);
        newItem.SetItemProperties(((Item_Gear_SO)itemSO));
        return newItem;
    }

    #region TestMethods
    private void TestSpawnXAmountItems()
    {
        int x = 8;
        for (int i = 0; i < x; i++) 
        {
            TestCreateItem();
        }
    }
    public void TestSpawnEachItem()
    {
        foreach (Item_Gear_SO item_Gear_SO in itemGearSOs) 
        {
            CreateItemGear(item_Gear_SO);
        }
    }
    public void TestCreateItem()
    {
        CreateItemGear(testItemGearSO);
    }
    #endregion
}
