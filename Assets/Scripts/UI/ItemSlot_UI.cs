using UnityEngine.UI;
using UnityEngine;

public class ItemSlot_UI : MonoBehaviour
{
    [SerializeField] private Image _mySpriteRenderer;
    Item item;


    private void OnEnable()
    {
        if (!item)
        { return; }

    }
    void OnRightClick()
    {
        if (item is Item_Gear)
        {
            ((Item_Gear)item).DressItem();
        }
    }
    void SetSlotProperties(Item inputItem)
    {
        _mySpriteRenderer.sprite = item.pictogramImage;
    }
}
