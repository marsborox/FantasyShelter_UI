using UnityEngine;
using UnityEngine.UI;

public class TestUI : UI
{
    [SerializeField] private Button _spawnHero;
    [SerializeField] private Button _spawnCreep;
    [SerializeField] private Button _createHeroGroup;
    [SerializeField] private UnitSpawner _unitSpawner;
    [SerializeField] private HeroGroupManager _heroGroupManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitiateButton(_spawnHero, SpawnHero);
        InitiateButton(_createHeroGroup, CreateHeroGroup);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnHero()
    { }
    private void SpawnCreep()
    { }
    private void CreateHeroGroup()
    { }
}
