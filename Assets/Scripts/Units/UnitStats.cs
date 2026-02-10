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

    public UnitStat healthStat = new UnitStat("Health",100);
    public UnitStat damageStat = new UnitStat("Damage",20);
    public UnitStat defenseStat = new UnitStat("Defense",10);
    public UnitStat energyStat = new UnitStat("Energy",100);

    public List<UnitStat> unitStatList = new List<UnitStat>();

    public int health = 999;
    public int damage = 999;
    public int defense = 999;
    public int energy = 999;

    public Unit unit;
    private void Start()
    {
        AddStatsToList();
        SetStatValuesCurrent();
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
        energyStat.valueBase = inputSO.energy;
        AddInventoryStats();
        SetStatValuesCurrent();
    }
    private void AddStatsToList()
    {
        unitStatList.Add(healthStat);
        unitStatList.Add(damageStat);
        unitStatList.Add(defenseStat);
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
