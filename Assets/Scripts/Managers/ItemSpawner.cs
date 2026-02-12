using System.Collections.Generic;

using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<Item_Gear_SO> itemGearSOs = new List<Item_Gear_SO>();
    public Item_Gear_SO testItemGearSO;

    [SerializeField] private Item_Gear itemGearPrefab;
    //some instance / prefab of item
    private void Start()
    {
        TestSpawnXAmountItems();
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
        Stash.instance.AddItemToStash(newItem);
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
    public void TestCreateItem()
    {
        CreateItemGear(testItemGearSO);

    }
    #endregion
}
