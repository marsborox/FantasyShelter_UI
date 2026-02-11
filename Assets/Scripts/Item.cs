using UnityEngine;
using System;
public enum Slot {HEAD,CHEST,WEAPON_1H,OFFHAND }
public class Item : MonoBehaviour
{
    public Slot slot;
    
    public int health;
    public int damage;
    public int defense;
    public int attackSpeed;
    public int movementSpeed;
    public int energy;

    public Sprite pictogramImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
