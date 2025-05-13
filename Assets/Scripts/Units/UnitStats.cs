using System;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public int health;
    public int attack;
    public int defense;
    public int energy;

    public TestUnit_SO testUnit_SO;

    private void Start()
    {

    }

    private void SetStatsDifferentMethod()
    {
        health = testUnit_SO.health;
        attack = testUnit_SO.attack;
        defense = testUnit_SO.defense;
        energy = testUnit_SO.energy;
    }
    public void SetStats(TestUnit_SO inputSO)
    {
        health = inputSO.health;
        attack = inputSO.attack;
        defense = inputSO.defense;
        energy = inputSO.energy;
    }
}
