using System;
using System.Collections.Generic;

using JetBrains.Annotations;

using UnityEngine;

public class UnitStats : MonoBehaviour
{
    private Role _role;
    public string role;


    [System.Serializable]
    public class UnitStat
    {
        public string name = "StatName";
        public int valueBase;
        public int valueMax;
        public int valueCurrent;
        public UnitStat()
        {
            name = "StatName";
            valueMax = 0;
            SetCurrentValueMax();
        }
        public UnitStat(string inputName,int inputValueMax)
        { 
            name = inputName;
            valueMax = inputValueMax;
            SetCurrentValueMax();
        }
        public void SetCurrentValueMax()
        {
            valueCurrent = valueMax;
        }
    }

    string asdf = Constants.HEALTH_STRING;

    public UnitStat healthStat = new UnitStat(Constants.HEALTH_STRING, 100);
    public UnitStat damageStat = new UnitStat(Constants.DAMAGE_STRING,20);
    public UnitStat defenseStat = new UnitStat(Constants.DEFENSE_STRING,10);
    public UnitStat attackSpeedStat = new UnitStat(Constants.ATTACKSPEED_STRING, 50);
    public UnitStat movementSpeedStat = new UnitStat(Constants.MOVEMENT_SPEED_STRING ,10);
    public UnitStat energyStat = new UnitStat(Constants.ENERGY_STRING,100);


    public List<UnitStat> unitStatList = new List<UnitStat>();

    //these values are used only by npc / enemy
    public int health = 999;
    public int damage = 999;
    public int defense = 999;
    public int energy = 999;

    public Unit unit;
    private void Start()
    {
        AddStatsToList();
        SetStatValuesCurrent();
        Debug.Log(asdf);
    }

    public void SetStats(TestUnit_SO inputSO)
    {
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
    private void AddStatsToList()
    {
        unitStatList.Add(healthStat);
        unitStatList.Add(damageStat);
        unitStatList.Add(defenseStat);
        unitStatList.Add(attackSpeedStat);
        unitStatList.Add(movementSpeedStat);
        unitStatList.Add(energyStat);
        
    }
    private void SetStatValuesCurrent()
    {
        foreach (UnitStat unitStat in unitStatList)
        {
            unitStat.SetCurrentValueMax();
        }
    }
    public virtual void AddInventoryStats()
    {//from inventory
        
        healthStat.valueMax = healthStat.valueBase;
        damageStat.valueMax = damageStat.valueBase;
        defenseStat.valueMax = defenseStat.valueBase;
        attackSpeedStat.valueMax = attackSpeedStat.valueBase;
        movementSpeedStat.valueMax = movementSpeedStat.valueBase;
        energyStat.valueMax = energyStat.valueBase;
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
