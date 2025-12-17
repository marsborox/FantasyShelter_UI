using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitStats stats;

    public string unitName;
    public int level;

    public int health;
    public int attack;
    public int defense;
    public int energy;


    public void Start()
    {
        
    }

    void Update()
    {
        
    }
    public int ReturnHealth()
    {
        return stats.health;
    }
    public int ReturnAttack()
    {
        return stats.attack;
    }
    public int ReturnDefense()
    {
        return stats.defense;
    }
    public int ReturnEnergy()
    {
        return stats.energy;
    }
}
