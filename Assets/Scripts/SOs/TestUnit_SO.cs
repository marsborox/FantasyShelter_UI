using UnityEngine;

enum Type {TANK,DAMAGE,GENERIC,SUPPORT }
[CreateAssetMenu(fileName = "TestUnit_SO", menuName = "Scriptable Objects/TestUnit_SO")]
public class TestUnit_SO : ScriptableObject
{
    public string name;

    [SerializeField] Type _type;
    
    public int health;
    public int attack;
    public int defense;
    public int energy;


    public string SetTypeString()
    { 
        return _type.ToString();
    }
}