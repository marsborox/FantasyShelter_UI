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

    private HeroInventoy _heroInventory;
    private void Awake()
    {
        _heroInventory = GetComponent<HeroInventoy>();
    }
    private void CalculateStats()
    {
        health = healthBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.health,_heroInventory.gear);
        attack = attackBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.attack, _heroInventory.gear);
        defense = defenseBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.defense, _heroInventory.gear);
        energy = energyBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.energy, _heroInventory.gear);

    }
    private void CalculateStatsLocal()
    {//discontinued
        health = CalcStat(healthBase, item => item.health);
        attack = CalcStat(attackBase, item => item.attack);
        defense = CalcStat(defenseBase, item => item.defense);
        energy = CalcStat(energyBase, item => item.energy);
    }
    private int CalcStat(int statBase, Func<Item, int> getItemStat)
    {
        int returnStat = statBase;
        foreach (Item item in _heroInventory.gear)
        {
            returnStat += getItemStat(item);
        }
        return returnStat;
    }
}
