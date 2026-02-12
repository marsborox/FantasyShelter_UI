using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    private Role _role;
    public string role;


    [System.Serializable]
    public class UnitStat
    {
        public string name = "StatName";
        public int valueBase = 0;
        public int valueTotal = 0;
        public int valueItems = 0;
        public int valueCurrent = 0;
        public UnitStat()
        {
            name = "StatName";
            //valueTotal = 0;
            //SetCurrentValueTotal();
        }
        public UnitStat(string inputName)
        {
            name = inputName;

            //SetCurrentValueTotal();
        }
        public UnitStat(string inputName,int inputValueMax)
        { 
            name = inputName;
            //valueTotal = inputValueMax;
            //SetCurrentValueTotal();
        }

        public void SetCurrentValueTotal()
        {// will be changed 
            valueCurrent = valueTotal;
        }
    }
    
    
    //may remove
    /*public UnitStat healthStat = new UnitStat(Constants.HEALTH_STRING, 100);
    public UnitStat damageStat = new UnitStat(Constants.DAMAGE_STRING,20);
    public UnitStat defenseStat = new UnitStat(Constants.DEFENSE_STRING,10);
    public UnitStat attackSpeedStat = new UnitStat(Constants.ATTACKSPEED_STRING, 50);
    public UnitStat movementSpeedStat = new UnitStat(Constants.MOVEMENT_SPEED_STRING ,10);
    public UnitStat energyStat = new UnitStat(Constants.ENERGY_STRING,100);*/

    public UnitStat healthStat = new UnitStat(Constants.HEALTH_STRING);
    public UnitStat damageStat = new UnitStat(Constants.DAMAGE_STRING);
    public UnitStat defenseStat = new UnitStat(Constants.DEFENSE_STRING);
    public UnitStat attackSpeedStat = new UnitStat(Constants.ATTACKSPEED_STRING);
    public UnitStat movementSpeedStat = new UnitStat(Constants.MOVEMENT_SPEED_STRING);
    public UnitStat energyStat = new UnitStat(Constants.ENERGY_STRING);

    public List<UnitStat> unitStatList = new List<UnitStat>();

    //these values are used only by npc / enemy
    public int health = 999;
    public int damage = 999;
    public int defense = 999;
    public int energy = 999;

    public Unit unit;
    public void Awake()
    {
        //AddStatsToList();//must be run right after unit is created
        //SetStatValuesCurrent();
        
    }
    public void AddStatsToList()
    {
        unitStatList.Add(healthStat);
        unitStatList.Add(damageStat);
        unitStatList.Add(defenseStat);
        unitStatList.Add(attackSpeedStat);
        unitStatList.Add(movementSpeedStat);
        unitStatList.Add(energyStat);
    }
    
    public void SetBaseStatsFromSO(TestUnit_SO inputSO)
    {//logic must be changed to like take from SO, then add form items, then set to current
        //when gets buff then recalc current
        CheckIfStatsNull(inputSO);

        unit.unitName = inputSO.name;
        _role = inputSO.role;
        role = inputSO.SetRoleString();

        /*health = inputSO.health;
        damage = inputSO.damage;
        defense = inputSO.defense;
        energy = inputSO.energy;*/

        healthStat.valueBase = inputSO.health;
        damageStat.valueBase = inputSO.damage;
        defenseStat.valueBase = inputSO.defense;
        attackSpeedStat.valueBase = inputSO.attackSpeed;
        movementSpeedStat.valueBase = inputSO.movementSpeed;
        energyStat.valueBase = inputSO.energy;

        AddInventoryStats();
        SetStatValuesCurrent();
    }

    public virtual void AddInventoryStats()
    {//from inventory

        CalcStat(healthStat);
        CalcStat(damageStat);
        CalcStat(defenseStat);
        CalcStat(attackSpeedStat);
        CalcStat(movementSpeedStat);
        CalcStat(energyStat);

        /*healthStat.valueTotal = healthStat.valueBase;
        damageStat.valueTotal = damageStat.valueBase;
        defenseStat.valueTotal = defenseStat.valueBase;
        attackSpeedStat.valueTotal = attackSpeedStat.valueBase;
        movementSpeedStat.valueTotal = movementSpeedStat.valueBase;
        energyStat.valueTotal = energyStat.valueBase;*/

        void CalcStat(UnitStat stat)
        { 
            stat.valueTotal = stat.valueBase+stat.valueItems;
        }
    }
    public virtual void SetStatValuesCurrent()
    {
        foreach (UnitStat unitStat in unitStatList)
        {
            unitStat.SetCurrentValueTotal();
        }
    }

    #region TestMethods
    void CheckIfStatsNull(TestUnit_SO inputSO)
    {
        if (inputSO == null)
        {
            //Debug.Log("unitStats.inputSO is null");
        }
        else
        {
            //Debug.Log("unitStats.inputSO is not null");
        }

    }
    #endregion
}
