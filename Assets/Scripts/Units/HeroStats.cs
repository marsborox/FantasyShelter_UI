using System;

using UnityEngine;

public class HeroStats : UnitStats,ICalcStat
{

    //public int healthBase;
    //public int healthCurrent;

    //public int damageBase;
    //public int damageCurrent;

    //public int defenseBase;
    //public int defenseCurrent;

    //public int energyBase;
    //public int energyCurrent;

    private HeroInventoy _heroInventory;
    private void Awake()
    {
        base.Awake();
        _heroInventory = GetComponent<HeroInventoy>();
    }
    public override void AddInventoryStats()
    {//from inventory
        /* //remove this //*******************************
        health = healthBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.health,_heroInventory.gear);
        damage = damageBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.damage, _heroInventory.gear);
        defense = defenseBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.defense, _heroInventory.gear);
        energy = energyBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.energy, _heroInventory.gear);
        */

        /*healthStat.valueTotal = healthStat.valueBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.health, _heroInventory.gear);
        damageStat.valueTotal = damageStat.valueBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.damage, _heroInventory.gear);
        defenseStat.valueTotal = defenseStat.valueBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.defense, _heroInventory.gear);
        energyStat.valueTotal = energyStat.valueBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.energy, _heroInventory.gear);*/
        base.AddInventoryStats();

    }

}
