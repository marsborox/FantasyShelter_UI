using UnityEngine;
using System;
public enum Slot {HEAD,CHEST,WEAPON_1H,OFFHAND }
public class Item : MonoBehaviour
{
    public Slot slot;
    
    public int health;
    public int attack;
    public int defense;
    public int energy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
