using UnityEditor;

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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        unitStats = GetComponent<UnitStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
