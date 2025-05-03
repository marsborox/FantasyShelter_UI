using UnityEngine;

public class HeroInventoy : MonoBehaviour
{
    Item headSlot;
    Item chestSlot;
    Item weaponSlot;
    Item offhandSlot;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckSlot(Item item)
    {
        switch (item.slot) 
        {
            case "headSlot":
                PutOnItem(item,ref headSlot);
                break;
            case "chestSlot":
                PutOnItem(item, ref chestSlot);
                break;
            case "weaponSlot":
                PutOnItem(item, ref weaponSlot);
                break;
            case "offHandSlot":
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
            //empty slo to inventory
            slot = item;
        }


    }




}
 