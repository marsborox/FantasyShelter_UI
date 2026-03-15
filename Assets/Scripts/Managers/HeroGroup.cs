using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroGroup : MonoBehaviour, ICalcStat
{
    public HeroGroupManager heroGroupManager;
    public HeroManager heroManager;

    public string heroGroupName;
    public int uniqueID;
    //public int id = 0;//remove and scrape
    
    public int heroGroupHealth;
    public int heroGroupDamage;
    public int heroGroupDefense;
    public int heroGroupEnergy;

    public int enemyNPCHealth;
    public int enemyNPCDamage;
    public int enemyNPCDefense;
    public int enemyNPCEnergy;

    public List<Hero> heroList = new List<Hero>();
    public List<Unit> enemyNPCList = new List<Unit>();

    HeroGroupStash _heroGroupStash;

    private void Awake()
    {
        _heroGroupStash = GetComponent<HeroGroupStash>();
    }
    public void CalcStats()
    {
        heroGroupHealth = CalcHeroStats(hero =>hero.stats.health);
        heroGroupDamage = CalcHeroStats(hero =>hero.stats.damage);
        heroGroupDefense = CalcHeroStats(hero => hero.stats.defense);
    }

    
    public void AddUnitToDesignatedList(EnemyNPC enemyNPC)
    {
        enemyNPCList.Add(enemyNPC);
        CalcEnemyNPCStats();
    }
    public void AddUnitToDesignatedList(Hero hero)
    {
        heroList.Add(hero);
        CalcHeroStats();
    }
    public void RemoveUnitFromDesignatedList(EnemyNPC enemyNPC)
    {
        enemyNPCList.Remove(enemyNPC);
        CalcEnemyNPCStats();
    }
    public void RemoveUnitFromDesignatedList(Hero hero)
    {
        heroList.Remove(hero);
        CalcHeroStats();
    }
    public void DisbandHeroGroup()
    {
        bool disbanding = true;
        while (disbanding)
        {
            if (heroList.Count > 0)
            {
                heroManager.MoveHeroToBaseGroup(heroList[0]);
            }
            else { disbanding = false; }
        }
        //ID_Manager.instance.MakeIDAvailable(uniqueID);
        heroGroupManager.DestroyHeroGroup(this);
        //close HeroGroup
        //refresh UI HeroGroups if opened
    }
    public void CalcHeroStats()
    {
        //DebugLogUnitStats(heroList);
        //heroGroupHealth = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.health, heroList);
        //heroGroupDamage = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.damage, heroList);
        //heroGroupDefense = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.defense, heroList);
        //heroGroupEnergy = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.energy, heroList);

        heroGroupHealth = ((ICalcStat)this).CalcStat(inputObject => inputObject.ReturnHealthCurrent(),heroList);
        heroGroupDamage = ((ICalcStat)this).CalcStat(inputObject => inputObject.ReturnDamageCurrent(), heroList);
        heroGroupDefense = ((ICalcStat)this).CalcStat(inputObject => inputObject.ReturnDefenseCurrent(), heroList);
        heroGroupEnergy = ((ICalcStat)this).CalcStat(inputObject => inputObject.ReturnEnergyCurrent(), heroList);
    }
    public void CalcEnemyNPCStats()
    {
        enemyNPCHealth = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.health, enemyNPCList);
        enemyNPCDamage = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.damage, enemyNPCList);
        enemyNPCDefense = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.defense, enemyNPCList);
        enemyNPCEnergy = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.energy, enemyNPCList);
    }

    
    private int CalcHeroStats(Func<Unit,int>getHeroStat)
    {
        int returnStat = 0;
        foreach (Unit hero in heroList)
        {
            returnStat += getHeroStat(hero);
        }
        return returnStat;
    }
    private int CalcUnitStats(Func<Unit, int> getUnitStat, List<Unit> list)
    {
        int returnStat = 0;
        foreach (Unit unit in list)
        {
            returnStat += getUnitStat(unit);
        }
        return returnStat;
    }
    public HeroGroup_SaveData SaveHeroGroup()
    {
        HeroGroup_SaveData data = new HeroGroup_SaveData();

        data.heroGroupName = heroGroupName;
        data.uniqueID = uniqueID;

        foreach (Hero hero in heroList)
        {
            data.heroID_List.Add(hero.ReturnID());
        }
        return data;
        
    }
    public void LoadHeroGroup(HeroGroup_SaveData data)
    { 
        heroGroupName = data.heroGroupName;
        uniqueID = data.uniqueID;

        foreach (int heroID in data.heroID_List)
        { 
            
        }
    }

    #region Test&Debug
    void DebugLogUnitStats(List<Unit> list)
    {
        int unitsInListAmmount = 0;
        int unitStatsNullAmmount = 0;
        foreach (Unit unit in list)
        {

            unitsInListAmmount++;
            if (unit.stats == null)
            {
                unitStatsNullAmmount++;
            }
        }

        Debug.Log(" heroGroup units in unitList : " + unitsInListAmmount);
        Debug.Log("heroGroup ammount of unitl.stats null in unitList: " + unitStatsNullAmmount);
    }

    #endregion
}
