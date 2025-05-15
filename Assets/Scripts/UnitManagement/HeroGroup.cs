using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroGroup : MonoBehaviour, ICalcStat
{
    public string name;
    
    public int heroGroupHealth;
    public int heroGroupAttack;
    public int heroGroupDefense;
    public int heroGroupEnergy;

    public int enemyNPCHealth;
    public int enemyNPCAttack;
    public int enemyNPCDefense;
    public int enemyNPCEnergy;

    public List<Unit> heroList = new List<Unit>();
    public List<Unit> enemyNPCList = new List<Unit>();

    HeroGroupStash _heroGroupStash;
    private void Awake()
    {
        _heroGroupStash = GetComponent<HeroGroupStash>();
    }
    public void CalcStats()
    {
        heroGroupHealth = CalcHeroStats(hero =>hero.unitStats.health);
        heroGroupAttack = CalcHeroStats(hero =>hero.unitStats.attack);
        heroGroupDefense = CalcHeroStats(hero => hero.unitStats.defense);
    }
    public void AddUnitToDesignatedList(Unit unit)
    {
        List<Unit> list=new List<Unit>();
        Action action = null;
        if (unit is Hero)
        {
            list = heroList;
            action = CalcHeroStats;
        }
        else if (unit is EnemyNPC)
        { 
            list =enemyNPCList;
            action = CalcEnemyNPCStats;
        }
        try
        {
            list.Add(unit);
            action();
        }
        catch (Exception e) 
        {
            
        }
    }
    public void AddHeroToList(Unit hero)
    { 
        heroList.Add(hero);

    }
    public void AddENPCToList(Unit eNPC)
    {
        enemyNPCList.Add(eNPC);
    }
    public void CalcHeroStats()
    {
        heroGroupHealth = ((ICalcStat)this).CalcStat(inputObject => inputObject.unitStats.health, heroList);
        heroGroupAttack = ((ICalcStat)this).CalcStat(inputObject => inputObject.unitStats.attack, heroList);
        heroGroupDefense = ((ICalcStat)this).CalcStat(inputObject => inputObject.unitStats.defense, heroList);
        heroGroupEnergy = ((ICalcStat)this).CalcStat(inputObject => inputObject.unitStats.energy, heroList);
    }
    public void CalcEnemyNPCStats()
    {
        enemyNPCHealth = ((ICalcStat)this).CalcStat(inputObject => inputObject.unitStats.health, enemyNPCList);
        enemyNPCAttack = ((ICalcStat)this).CalcStat(inputObject => inputObject.unitStats.attack, enemyNPCList);
        enemyNPCDefense = ((ICalcStat)this).CalcStat(inputObject => inputObject.unitStats.defense, enemyNPCList);
        enemyNPCEnergy = ((ICalcStat)this).CalcStat(inputObject => inputObject.unitStats.energy, enemyNPCList);
    }

    private int CalcHeroStats(Func<Hero,int>getHeroStat)
    {
        int returnStat = 0;
        foreach (Hero hero in heroList)
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

}
