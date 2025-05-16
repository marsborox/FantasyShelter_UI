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
        heroGroupHealth = CalcHeroStats(hero =>hero.stats.health);
        heroGroupAttack = CalcHeroStats(hero =>hero.stats.attack);
        heroGroupDefense = CalcHeroStats(hero => hero.stats.defense);
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
    public void AddEnemyNPCToList(Unit eNPC)
    {
        enemyNPCList.Add(eNPC);
    }
    public void RemoveHeroFromList()
    { }
    public void RemoveEnemyNPCFromList()
    { }
    public void CalcHeroStats()
    {
        heroGroupHealth = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.health, heroList);
        heroGroupAttack = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.attack, heroList);
        heroGroupDefense = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.defense, heroList);
        heroGroupEnergy = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.energy, heroList);
    }
    public void CalcEnemyNPCStats()
    {
        enemyNPCHealth = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.health, enemyNPCList);
        enemyNPCAttack = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.attack, enemyNPCList);
        enemyNPCDefense = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.defense, enemyNPCList);
        enemyNPCEnergy = ((ICalcStat)this).CalcStat(inputObject => inputObject.stats.energy, enemyNPCList);
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
