using UnityEngine;

public class Unit : MonoBehaviour
{
    public string name;
    public int level;

    public int health;
    public int attack;
    public int defense;
    public int energy;

    public UnitStats unitStats;

    void Start()
    {
        unitStats = GetComponent<UnitStats>();
    }

    void Update()
    {
        
    }
}
