using System;

using UnityEngine;

using static HeroInventory;

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

    [SerializeField] private HeroEventHandler _heroEventHandler;
    [SerializeField] private HeroInventory _heroInventory;
    private void Awake()
    {
        base.Awake();
        _heroInventory = GetComponent<HeroInventory>();
    }
    void OnEnable()
    {
        _heroEventHandler.OnStatsChanged += AddInventoryStats;
        
    }

    void OnDisable()
    {
        _heroEventHandler.OnStatsChanged -= AddInventoryStats;
    }
    public override void AddInventoryStats()
    {//from inventory //for now this calculates all stats

        /*healthStat.valueTotal = healthStat.valueBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.health, _heroInventory.gear);
        damageStat.valueTotal = damageStat.valueBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.damage, _heroInventory.gear);
        defenseStat.valueTotal = defenseStat.valueBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.defense, _heroInventory.gear);
        energyStat.valueTotal = energyStat.valueBase + ((ICalcStat)this).CalcStat(inputObject => inputObject.energy, _heroInventory.gear);*/

        CalcStatsFromItems();//temp placement
        base.AddInventoryStats();
        SetStatValuesCurrent();
    }
    public void CalcStatsFromItems()
    {

        healthStat.valueItems = CalcStatFromItems(inputItem => inputItem.health);
        damageStat.valueItems = CalcStatFromItems(inputItem => inputItem.damage);
        defenseStat.valueItems = CalcStatFromItems(inputItem => inputItem.defense);
        attackSpeedStat.valueItems = CalcStatFromItems(inputItem => inputItem.attackSpeed);
        movementSpeedStat.valueItems = CalcStatFromItems(inputItem => inputItem.movementSpeed);
        energyStat.valueItems = CalcStatFromItems(inputItem => inputItem.energy);
    }

    int CalcStatFromItems(Func<Item_Gear,int> getStat)
    {
        int returnStat = 0;
        foreach (GearSlot slot in _heroInventory.gearSlots)
        {
            if (slot.item == null)
            { continue; }
            returnStat += getStat(slot.item);
        }
        return returnStat;
    }
    #region calcStatFromInventoryMethods
    /*
    int CalcHealthFromItems()
    {
        int returnStat = 0;
        foreach (GearSlot item in _heroInventory.gearSlots)
        {
            if (item.item == null)
            { continue; }
            returnStat += item.item.health;
        }
        return returnStat;
    }
    int CalcDamageFromItems()
    {
        int returnStat = 0;
        foreach (GearSlot item in _heroInventory.gearSlots)
        {
            if (item.item == null)
            { continue; }
            returnStat += item.item.damage;
        }
        return returnStat;
    }
    int CalcDefenseFromItems()
    {
        int returnStat = 0;
        foreach (GearSlot item in _heroInventory.gearSlots)
        {
            if (item.item == null)
            { continue; }
            returnStat += item.item.defense;
        }
        return returnStat;
    }
    int CalcAttackSpeedFromItems()
    {
        int returnStat = 0;
        foreach (GearSlot item in _heroInventory.gearSlots)
        {
            if (item.item == null)
            { continue; }
            returnStat += item.item.attackSpeed;
        }
        return returnStat;
    }
    int CalcMovementSpeedFromItems()
    {
        int returnStat = 0;
        foreach (GearSlot item in _heroInventory.gearSlots)
        {
            if (item.item == null)
            { continue; }
            returnStat += item.item.movementSpeed;
        }
        return returnStat;
    }
    int CalcEnergyFromItems()
    {
        int returnStat = 0;
        foreach (GearSlot item in _heroInventory.gearSlots)
        {
            if (item.item == null)
            { continue; }
            returnStat += item.item.energy;
        }
        return returnStat;
    }*/
    #endregion
}
