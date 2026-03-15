using UnityEngine;

public enum MaterialType { STONE,WOOD,HERB,ORE,ORE_BAR}
public class Item_Material : Item
{
    public MaterialType materialType;

    public Item_Material_SO itemMaterialSO;
    public int amount;
    public void SetItemProperties(Item_Material_SO itemMaterialSO)
    {
        materialType = itemMaterialSO.materialType;
        amount = itemMaterialSO.amount;
    }
}
