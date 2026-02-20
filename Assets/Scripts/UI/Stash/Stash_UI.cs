using UnityEngine;

public class Stash_UI : UI
{
    [SerializeField] Stash stash;
    [SerializeField] ItemSlot_UI itemSlot;

    private void OnEnable()
    {

        DestroyChildren();
        DisplayInventorySlots();
    }
    public void DisplayInventorySlots()
    {
        foreach (Item item in stash.itemGearList)
        {
            ItemSlot_UI itemSlotSpawned = Instantiate(itemSlot);
            itemSlotSpawned.transform.SetParent(transform);
            itemSlotSpawned.SetSlotProperties(item);
        }
    }
}
