using UnityEngine;
using System;
using NUnit.Framework.Internal;
using NUnit.Framework;
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
        ((IAddUnitToList)this).AddUnitToList(hero,heroManager.heroList);
        heroManager.heroList.Add(hero);
        IEnumerable<HeroGroup> baseGroup = from heroGroup in heroGroupManager.heroGroupList where heroGroup.name == "Base" select heroGroup;
        baseGroup.heroList.Add(hero);
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
