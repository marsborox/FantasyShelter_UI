using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroGroup : MonoBehaviour
{
    public string name;
    
    public int health;
    public int attack;
    public int defense;
    public int energy;

    HeroGroupStash heroGroupStash;
    public List<Hero> heroList = new List<Hero>();
    public List<Unit> enemyNPCList = new List<Unit>();

    private void Awake()
    {
        heroGroupStash = GetComponent<HeroGroupStash>();
    }
    public void CalcStats()
    {
        health = CalcStat(hero =>hero.unitStats.health);
    }

    int CalcStat(Func<Hero,int>getHeroStat)
    {
        int returnStat = 0;
        foreach (Hero hero in heroList)
        {
            returnStat += getHeroStat(hero);
        }
        return returnStat;
    }


}
