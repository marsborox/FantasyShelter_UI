using System;
using UnityEngine;
using UnityEngine.Windows;

public class UnitStats : MonoBehaviour
{
    private Role _role;
    public string role;
    public int health;
    public int attack;
    public int defense;
    public int energy;

    public Unit unit;
    private void Start()
    {

    }

    public void SetStats(TestUnit_SO inputSO)
    {
        CheckIfStatsNull(inputSO);

        unit.unitName = inputSO.name;
        _role = inputSO.role;
        role = inputSO.SetRoleString();
        health = inputSO.health;
        attack = inputSO.attack;
        defense = inputSO.defense;
        energy = inputSO.energy;

    }
    #region TestMethods
    void CheckIfStatsNull(TestUnit_SO inputSO)
    {
        if (inputSO == null)
        {
            //Debug.Log("unitStats.inputSO is null");
        }
        else
        {
            //Debug.Log("unitStats.inputSO is not null");
        }

    }
    #endregion
}
