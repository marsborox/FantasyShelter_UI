using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Hero : Unit
{
    private HeroGroupManager _heroGroupManager;
    public string heroGroupImInName;
    public int heroGroupImInID;
    private void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHeroGroupManagerReference(HeroGroupManager heroGroupManager)
    { 
        _heroGroupManager = heroGroupManager;
    }
    public int ReturnHealthBase()
    {
        return ((HeroStats)stats).healthStat.valueBase;
    }
    public int ReturnAttackBase()
    {
        return ((HeroStats)stats).attackStat.valueCurrent;
    }
    public int ReturnDefenseBase()
    {
        return ((HeroStats)stats).defenseStat.valueCurrent;
    }
    public int ReturnEnergyBase()
    {
        return ((HeroStats)stats).energyStat.valueCurrent;
    }

    public int ReturnHealthCurrent()
    {
        return ((HeroStats)stats).healthStat.valueCurrent;
    }
    public int ReturnAttackCurrent()
    {
        return ((HeroStats)stats).attackStat.valueCurrent;
    }
    public int ReturnDefenseCurrent()
    {
        return ((HeroStats)stats).defenseStat.valueCurrent;
    }
    public int ReturnEnergyCurrent()
    {
        return ((HeroStats)stats).energyStat.valueCurrent;
    }
}
