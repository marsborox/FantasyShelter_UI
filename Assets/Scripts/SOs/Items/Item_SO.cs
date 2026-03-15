using UnityEngine;

//[CreateAssetMenu(/*fileName = "Item_SO",*/ /*menuName = "Scriptable Objects/Item_SO")*/]
public class Item_SO : ScriptableObject
{
    public string itemSoName;
    public Sprite sprite;
    public bool isStackable = false;
    public int itemSO_ID;
    
}
