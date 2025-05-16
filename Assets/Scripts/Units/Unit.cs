using UnityEngine;

public class Unit : MonoBehaviour
{
    public virtual UnitStats stats
    {
        get; set;
    }
    public string name;
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
}
