using System;
using System.Collections.Generic;

using UnityEngine;

using static UnitStats;
public enum Slot {HEAD,CHEST,WEAPON_1H,OFFHAND, DUMMY }
public class Item_Gear : Item
{
    public Slot slot;

    public string name;

    public int health;
    public int damage;
    public int defense;
    public int attackSpeed;
    public int movementSpeed;
    public int energy;

    /*public UnitStat healthStat = new UnitStat(Constants.HEALTH_STRING);
    public UnitStat damageStat = new UnitStat(Constants.DAMAGE_STRING);
    public UnitStat defenseStat = new UnitStat(Constants.DEFENSE_STRING);
    public UnitStat attackSpeedStat = new UnitStat(Constants.ATTACKSPEED_STRING);
    public UnitStat movementSpeedStat = new UnitStat(Constants.MOVEMENT_SPEED_STRING);
    public UnitStat energyStat = new UnitStat(Constants.ENERGY_STRING);

    public List<UnitStat> unitStatList = new List<UnitStat>();*/

    public Item_Gear_SO itemGearSO;
    public void SetItemProperties(Item_Gear_SO providedSO)
    { 
        name = providedSO.name;
        sprite = providedSO.sprite;

        slot = providedSO.slot;
        health = providedSO.health;
        damage = providedSO.damage;
        defense = providedSO.defense;
        attackSpeed = providedSO.attackSpeed;
        movementSpeed = providedSO.movementSpeed;
        energy = providedSO.energy;

        itemGearSO = providedSO;
    }
    public void ReturnStats(out int returnHealth, out int returnDamage, out int returnDefense, out int returnAttackSpeed,out int returnMovementSpeed,out int returnEnergy)
    {
        returnHealth = health;
        returnDamage = damage;
        returnDefense = defense;
        returnAttackSpeed = attackSpeed;
        returnMovementSpeed = movementSpeed;
        returnEnergy = energy;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DressItem(Hero hero)
    { 
        hero.DressItem(this);
    }
}
