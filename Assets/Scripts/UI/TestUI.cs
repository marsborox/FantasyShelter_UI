using UnityEngine;
using UnityEngine.UI;

public class TestUI : UI
{
    [SerializeField] Button spawnHero;
    [SerializeField] Button spawnCreep;
    [SerializeField] Button createHeroGroup;
    [SerializeField] UnitSpawner unitSpawner;
    [SerializeField] HeroGroupManager heroGroupManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitiateButton(spawnHero, SpawnHero);
        InitiateButton(createHeroGroup, CreateHeroGroup);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnHero()
    { }
    void SpawnCreep()
    { }
    void CreateHeroGroup()
    { }
}
