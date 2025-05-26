using UnityEngine;

public enum Role {TANK,DAMAGE,GENERIC,SUPPORT }
[CreateAssetMenu(fileName = "TestUnit_SO", menuName = "Scriptable Objects/TestUnit_SO")]
public class TestUnit_SO : ScriptableObject
{
    public string name;

    public Role role;
    
    public int health;
    public int attack;
    public int defense;
    public int energy;


    public string SetRoleString()
    { 
        return role.ToString();
    }
}