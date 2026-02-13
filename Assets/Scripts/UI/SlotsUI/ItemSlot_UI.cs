using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemSlot_UI : MonoBehaviour
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
        OnMouseDown();
    }
    void OnMouseDown()
    {
        Debug.Log("clickedOnObject");
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Rightclick on itemSlot stash");
            if (UIManager.instance.displayedHero_UI.gameObject.activeSelf&&item is Item_Gear)
            {
                Debug.Log("Dressing Item");
                UIManager.instance.displayedHero_UI.displayedHero.DressItem((Item_Gear)item);
            }
        }
    }

   
    void OnRightClick()
    {
        /*// somehow pass the hero reference
        Hero hero;
        if (item is Item_Gear)
        {
            ((Item_Gear)item).DressItem(hero);
        }*/
    }
    public void SetSlotProperties(Item inputItem)
    {
        item = inputItem;
        image.sprite = item.sprite;
    }
}
