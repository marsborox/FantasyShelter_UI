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

    HeroGroupStash heroGroupStash;
    public List<Unit> heroList = new List<Unit>();
    public List<Unit> enemyNPCList = new List<Unit>();

    private void Awake()
    {
        heroGroupStash = GetComponent<HeroGroupStash>();
    }
    public void CalcStats()
    {
        heroGroupHealth = CalcHeroStats(hero =>hero.unitStats.health);
        heroGroupAttack = CalcHeroStats(hero =>hero.unitStats.attack);
        heroGroupDefense = CalcHeroStats(hero => hero.unitStats.defense);
    }

    void CalcHeroStats()
    {
        heroGroupHealth = ((ICalcStat)this).CalcStat(inputObject => inputObject.health, heroList);
        heroGroupAttack = ((ICalcStat)this).CalcStat(inputObject => inputObject.attack, heroList);
        heroGroupDefense = ((ICalcStat)this).CalcStat(inputObject => inputObject.defense, heroList);
        heroGroupEnergy = ((ICalcStat)this).CalcStat(inputObject => inputObject.energy, heroList);
    }
    void CalcEnemyNPCStats()
    {
        enemyNPCHealth = ((ICalcStat)this).CalcStat(inputObject => inputObject.health, enemyNPCList);
        enemyNPCAttack = ((ICalcStat)this).CalcStat(inputObject => inputObject.attack, enemyNPCList);
        enemyNPCDefense = ((ICalcStat)this).CalcStat(inputObject => inputObject.defense, enemyNPCList);
        enemyNPCEnergy = ((ICalcStat)this).CalcStat(inputObject => inputObject.energy, enemyNPCList);
    }

    int CalcHeroStats(Func<Hero,int>getHeroStat)
    {
        int returnStat = 0;
        foreach (Hero hero in heroList)
        {
            returnStat += getHeroStat(hero);
        }
        return returnStat;
    }
    int CalcUnitStats(Func<Unit, int> getUnitStat, List<Unit> list)
    {
        int returnStat = 0;
        foreach (Unit unit in list)
        {
            returnStat += getUnitStat(unit);
        }
        return returnStat;
    }

}
