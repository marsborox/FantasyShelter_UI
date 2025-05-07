using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class UnitSpawner : MonoBehaviour, IAddUnitToList
{
    [SerializeField] Hero heroPrefab;
    Hero heroTemplate;

    [SerializeField] HeroGroup heroGroupPrefab;

    [SerializeField] Creep creepPrefab;
    Creep creepTemplate;

    [SerializeField] HeroManager heroManager;

    [SerializeField] HeroGroupManager heroGroupManager;

    TestUnitSpawner testHeroSpawner;

    void Awake()
    { 
        testHeroSpawner = GetComponent<TestUnitSpawner>();
    }
    void Start()
    {
        
    }



    public void SpawnHero()
    {
        Hero hero = heroPrefab;
        Instantiate(hero);
        heroManager.AddHeroToList(hero);
        hero.transform.parent = heroManager.transform;
        ((IAddUnitToList)this).AddUnitToList(hero,heroManager.heroList);
        heroManager.heroList.Add(hero);

        IEnumerable<HeroGroup> baseGroupQuerry = from heroGroup in heroGroupManager.heroGroupList where heroGroup.name == "Base" select heroGroup;
        //baseGroup.heroList.Add(hero);
        HeroGroup heroGroupToAdd = baseGroupQuerry.FirstOrDefault();
        ((IAddUnitToList)this).AddUnitToList(hero, heroGroupToAdd.heroList);
        //
        SetRandomStatsFromSO(hero);

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
    
    void SetHeroStatsFromSO(Hero hero)
    { 
        
    }
    void SetRandomStatsFromSO(Hero hero)
    { 
        
    }
}
