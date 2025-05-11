using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroGroup : MonoBehaviour
{
    public string name;
    
    public int heroHealth;
    public int heroAttack;
    public int heroDefense;
    public int heroEnergy;

    public int enemyNPCHhealth;
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
        heroHealth = CalcHeroStats(hero =>hero.unitStats.health);
        heroAttack = CalcHeroStats(hero =>hero.unitStats.attack);
        
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
