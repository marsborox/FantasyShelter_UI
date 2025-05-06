using UnityEngine;

[CreateAssetMenu(fileName = "TestHero_SO", menuName = "Scriptable Objects/TestHero_SO")]
public class TestHero_SO : ScriptableObject
{
    public string name;

    public int health;
    public int attack;
    public int defense;
    public int energy;
}
