using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitStats stats;
    public int uniqueID;
    public string unitName;
    public int level;

    public int health;
    public int damage;
    public int defense;
    public int energy;


    public void Start()
    {
        
    }

    void Update()
    {
        
    }

    public string ReturnName()
    {
        return unitName;
    }
    public int ReturnID()
    { 
        return uniqueID;
    }
    //ENEMY
    //might miss in enemy
    /*public int ReturnHealth()
    {
        return stats.health;
    }
    public int ReturnDamage()
    {
        return stats.damage;
    }
    public int ReturnDefense()
    {
        return stats.defense;
    }
    public int ReturnEnergy()
    {
        return stats.energy;
    }*/
}
