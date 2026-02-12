using UnityEngine;
using System;
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

    

    public Item_Gear_SO itemGearSO;
    public void SetItemProperties(Item_Gear_SO providedSO)
    { 
        name = providedSO.name;
        slot = providedSO.slot;
        health = providedSO.health;
        damage = providedSO.damage;
        defense = providedSO.defense;
        attackSpeed = providedSO.attackSpeed;
        movementSpeed = providedSO.movementSpeed;
        energy = providedSO.energy;

        itemGearSO = providedSO;
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
