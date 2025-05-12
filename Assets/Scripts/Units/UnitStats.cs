using System;

using NUnit.Framework;

using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public int health;
    public int attack;
    public int defense;
    public int energy;

    TestUnit_SO testUnit_SO;

    private void Start()
    {
        health = testUnit_SO.health;
        attack = testUnit_SO.attack;
        defense = testUnit_SO.defense;
        energy = testUnit_SO.energy;
    }
}
