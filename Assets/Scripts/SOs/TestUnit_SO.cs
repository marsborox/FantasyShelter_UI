using UnityEngine;

[CreateAssetMenu(fileName = "TestUnit_SO", menuName = "Scriptable Objects/TestUnit_SO")]
public class TestUnit_SO : ScriptableObject
{
    public string name;

    public int health;
    public int attack;
    public int defense;
    public int energy;
}
