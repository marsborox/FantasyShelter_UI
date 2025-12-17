using System;

using UnityEngine;

public class HeroStats : UnitStats,ICalcStat
{

    //public int healthBase;
    //public int healthCurrent;

    //public int attackBase;
    //public int attackCurrent;

    //public int defenseBase;
    //public int defenseCurrent;

    //public int energyBase;
    //public int energyCurrent;

    private HeroInventoy _heroInventory;
    private void Awake()
    {
        _heroInventory = GetComponent<HeroInventoy>();
    }
    public override void AddInventoryStats()
    {//from inventory
        /* //remove this //*******************************
        health = healthBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.health,_heroInventory.gear);
        attack = attackBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.attack, _heroInventory.gear);
        defense = defenseBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.defense, _heroInventory.gear);
        energy = energyBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.energy, _heroInventory.gear);
        */
        healthStat.valueMax = healthStat.valueBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.health, _heroInventory.gear);
        attackStat.valueMax = attackStat.valueBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.attack, _heroInventory.gear);
        defenseStat.valueMax = defenseStat.valueBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.defense, _heroInventory.gear);
        energyStat.valueMax = energyStat.valueBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.energy, _heroInventory.gear);
    }

}
