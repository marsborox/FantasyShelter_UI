using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] Hero heroPrefab;
    Hero heroTemplate;

    [SerializeField] HeroGroup heroGroupPrefab;

    [SerializeField] Creep creepPrefab;
    Creep creepTemplate;

    [SerializeField] HeroManager heroManager;

    [SerializeField] HeroGroupManager heroGroupManager;
    void Start()
    {
        SetHeroPrefabProperties();
    }

    public void SpawnHero()
    {
        Hero hero = heroPrefab;
        Instantiate(hero);
        heroManager.AddHeroToList(hero);
        hero.transform.parent = heroManager.transform;
    }
    public void SpawnCreep(HeroGroup heroGroup)
    { 
        Creep creep = creepPrefab;
        Instantiate(creep);
        heroGroup.enemyNPCList.Add(creep);
    }
    public void CreateHeroGroup()
    { 
        HeroGroup heroGroup = heroGroupPrefab;
        Instantiate (heroGroup);
        heroGroup.transform.parent=heroGroupManager.transform;
        heroGroup.name = "Group Name";
    }

    void SetHeroPrefabProperties()
    { 
        
    }
}
