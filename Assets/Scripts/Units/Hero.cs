using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Hero : Unit
{
    public HeroGroup heroGroupImIn;// must finish when hero is assigned
    public HeroInventory heroInventory;

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
    public void DoBasicSetup()
    {
        stats.AddStatsToList();
    }
    public void SetHeroGroupManagerReference(HeroGroupManager heroGroupManager)
    { 
        _heroGroupManager = heroGroupManager;
    }
    public int ReturnHealthBase()
    {
        return ((HeroStats)stats).healthStat.valueBase;
    }
    public int ReturnDamageBase()
    {
        return ((HeroStats)stats).damageStat.valueCurrent;
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
    public int ReturnDamageCurrent()
    {
        return ((HeroStats)stats).damageStat.valueCurrent;
    }
    public int ReturnDefenseCurrent()
    {
        return ((HeroStats)stats).defenseStat.valueCurrent;
    }
    public int ReturnEnergyCurrent()
    {
        return ((HeroStats)stats).energyStat.valueCurrent;
    }
    public void DressItem(Item_Gear item)
    { 
        heroInventory.DressItem(item);
    }
    public Hero_SaveData SaveHero()
    { 
        Hero_SaveData data = new Hero_SaveData();

        return data;
    }
    public void LoadHero(Hero_SaveData data)
    { 
    
    }
}
