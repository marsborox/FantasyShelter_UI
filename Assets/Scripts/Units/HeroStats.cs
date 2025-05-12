using System;

using UnityEngine;

public class HeroStats : UnitStats,ICalcStat
{
    public int healthBase;
    public int healthCurrent;

    public int attackBase;
    public int attackCurrent;

    public int defenseBase;
    public int defenseCurrent;

    public int energyBase;
    public int energyCurrent;

    HeroInventoy heroInventory;
    private void Awake()
    {
        heroInventory = GetComponent<HeroInventoy>();
    }
    void CalculateStats()
    {
        health = healthBase+((ICalcStat)this).CalcStat(inputObject => inputObject.health,heroInventory.gear);
        attack = attackBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.attack, heroInventory.gear);
        defense = defenseBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.defense, heroInventory.gear);
        energy = energyBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.energy, heroInventory.gear);

    }
    void CalculateStatsLocal()
    {//discontinued
        health = CalcStat(healthBase, item => item.health);
        attack = CalcStat(attackBase, item => item.attack);
        defense = CalcStat(defenseBase, item => item.defense);
        energy = CalcStat(energyBase, item => item.energy);
    }
    int CalcStat(int statBase, Func<Item, int> getItemStat)
    {
        int returnStat = statBase;
        foreach (Item item in heroInventory.gear)
        {
            returnStat += getItemStat(item);
        }
        return returnStat;
    }
}
