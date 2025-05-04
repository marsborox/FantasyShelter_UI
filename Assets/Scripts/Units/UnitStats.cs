using System;

using NUnit.Framework;

using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public int healthBase;
    public int health;
    public int healthCurrent;
    
    public int attackBase;
    public int attack;
    public int attackCurrent;

    public int defenseBase;
    public int defense;
    public int defenseCurrent;

    public int energyBase;
    public int energy;
    public int energyCurrent;

    HeroInventoy heroInventory;
    private void Awake()
    {
        heroInventory = GetComponent<HeroInventoy>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CalculateStats()
    {
        health = CalcStat(healthBase, item =>item.health);
        attack = CalcStat(attackBase, item =>item.attack);
        defense = CalcStat(defenseBase, item =>item.defense);
        energy = CalcStat(energyBase, item =>item.energy);
    }
    int CalcStat(int statBase,Func<Item, int>getItemStat )
    {
        int returnStat = statBase;
        foreach (Item item in heroInventory.gear)
        {
            returnStat += getItemStat(item);
        }
        return returnStat;
    }

}
