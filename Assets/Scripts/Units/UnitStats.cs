using System;
using UnityEngine;
using UnityEngine.Windows;

public class UnitStats : MonoBehaviour
{
    public string type;
    public int health;
    public int attack;
    public int defense;
    public int energy;

    private void Start()
    {

    }

    public void SetStats(TestUnit_SO inputSO)
    {
        CheckIfStatsNull(inputSO);
        type = inputSO.SetTypeString();
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
