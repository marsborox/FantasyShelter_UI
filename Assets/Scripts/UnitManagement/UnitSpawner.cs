using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class UnitSpawner : MonoBehaviour, IAddUnitToGroup
{
    [SerializeField] Hero heroPrefab;
    Hero heroTemplate;

    [SerializeField] HeroGroup heroGroupPrefab;

    [SerializeField] EnemyNPC creepPrefab;
    EnemyNPC creepTemplate;

    [SerializeField] UnitManager heroManager;

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
        Hero hero = Instantiate(heroPrefab);
        heroManager.AddHeroToList(hero);
        hero.transform.parent = heroManager.transform;
        ((IAddUnitToGroup)this).AddUnitToGroup(hero,heroManager.heroList);
        heroManager.heroList.Add(hero);

        IEnumerable<HeroGroup> baseGroupQuerry = from heroGroup in heroGroupManager.heroGroupList where heroGroup.name == "Base" select heroGroup;
        //baseGroup.heroList.Add(hero);
        if (baseGroupQuerry == null)
        {
            Debug.Log("unitSpawner.baseGroupQuerry is null");
        }
        else
        {
            Debug.Log("unitSpawner.baseGroupQuerry is NOT null");
            Debug.Log("unitSpawner.baseGroupQuerry count =  "+ baseGroupQuerry.Count());
        }
        HeroGroup heroGroupToAdd = baseGroupQuerry.FirstOrDefault();
        if (heroGroupToAdd == null) 
        {
            Debug.Log("unitSpawner.heroGroupToAdd is null"); 
        }
        else
        {
            ((IAddUnitToGroup)this).AddUnitToGroup(hero, heroGroupToAdd/*.heroList*/);
        }
        //
        SetRandomStatsFromSO(hero);

    }

    public void SpawnEnpcS(HeroGroup heroGroup)
    { 
        
        EnemyNPC creep = Instantiate(creepPrefab);
        heroGroup.enemyNPCList.Add(creep);
    }
    public void CreateHeroGroup()
    { 
        HeroGroup heroGroup = Instantiate (heroGroupPrefab);
        heroGroup.transform.parent=heroGroupManager.transform;
        heroGroupManager.heroGroupList.Add(heroGroup);
        heroGroup.name = "Group Name";
    }
    
    void SetHeroStatsFromSO(Hero hero)
    { 
        
    }
    void SetRandomStatsFromSO(Hero hero)
    { 
        
    }
}
