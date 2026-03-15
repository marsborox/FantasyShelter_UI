using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemSlot_UI : MonoBehaviour, IOnRayHit_UI
{
    public Item item;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI index;
    private void OnEnable()
    {
        if (!item)
        { return; }

    }
    private void Update()
    {
        
    }

    public void SetSlotProperties(Item inputItem)
    {
        item = inputItem;
        image.sprite = item.sprite;
    }
    public void Click()
    {
        //throw new System.NotImplementedException();
    }
    public void ClickAndHold()
    {
        //throw new System.NotImplementedException();
    }
    public void RMBClick()
    {
        DressIfGear();
        //throw new System.NotImplementedException();
    }

    private void DressIfGear()
    {
        if (!(item is Item_Gear))
        { return; }
        var displayedHeroUI = UIManager.instance.displayedHero_UI;
        if (displayedHeroUI.gameObject.activeSelf)
        {
            displayedHeroUI.displayedHero.DressItem(item as Item_Gear);
        }
    }
}
