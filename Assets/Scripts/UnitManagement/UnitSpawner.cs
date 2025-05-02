using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] Hero hero;
    Hero heroTemplate;

    [SerializeField] Creep creep;
    Creep creepTemplate;


    void Start()
    {
        SetHeroPrefabProperties();
    }


    public void SpawnHero()
    { 

        Instantiate(hero);
    }
    public void SpawnCreep()
    { 
        Instantiate(creep);
    }

    void SetHeroPrefabProperties()
    { 
        
    }
}
