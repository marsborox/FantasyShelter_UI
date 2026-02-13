using UnityEngine;

public class DisplayedHero_GearItems_UI : MonoBehaviour
{
    public DisplayedHero_UI displayedHero_UI;

    public DisplayedHero_GearItemStats_UI headSlotItem;
    public DisplayedHero_GearItemStats_UI chestSlotItem;
    public DisplayedHero_GearItemStats_UI weaponSlotItem;
    public DisplayedHero_GearItemStats_UI offhandSlotItem;
    public DisplayedHero_GearItemStats_UI itemsTotal;

    private void Update()
    {
        DisplayAllStats();
    }
    private void DisplayAllStats()
    { 
        HeroInventory heroInventory = displayedHero_UI.displayedHero.heroInventory;

        DisplayItemStats(headSlotItem,heroInventory.headSlot.item);
        DisplayItemStats(chestSlotItem,heroInventory.chestSlot.item);
        DisplayItemStats(weaponSlotItem,heroInventory.weaponSlot.item);
        DisplayItemStats(offhandSlotItem,heroInventory.offhandSlot.item);

    }
    private void DisplayItemStats(DisplayedHero_GearItemStats_UI itemSlot, Item_Gear item)
    {
        if (item == null)
        {
            itemSlot.health.text = "0";
            itemSlot.damage.text = "0";
            itemSlot.defense.text = "0";
            itemSlot.energy.text = "0";
            itemSlot.image = null;
            return;
        }
        int dummyHealth;
        int dummyDamage;
        int dummyDefense;
        int dummyAttackSeed;
        int dummyMovementSpeed;
        int dummyEnergy;

        item.ReturnStats(out dummyHealth, out dummyDamage, out dummyDefense, out dummyAttackSeed,out dummyMovementSpeed,out dummyEnergy);

        itemSlot.health.text = dummyHealth.ToString();
        itemSlot.damage.text = dummyDamage.ToString();
        itemSlot.defense.text = dummyDefense.ToString();
        itemSlot.energy.text = dummyEnergy.ToString();

        //itemSlot.image.sprite = item.sprite;//does not work but why
    }
}
