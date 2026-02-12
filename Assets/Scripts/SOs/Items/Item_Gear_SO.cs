using UnityEngine;

[CreateAssetMenu(fileName = "Item_Gear_SO", menuName = "Scriptable Objects/Item_SOs/Item_Gear_SO")]
public class Item_Gear_SO : Item_SO
{
    public Slot slot;

    public int health;
    public int damage;
    public int defense;
    public int attackSpeed;
    public int movementSpeed;
    public int energy;
}
