using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class UnitSpawner : MonoBehaviour, IAddUnitToGroup
{
    [SerializeField] private Hero _heroPrefab;
    private Hero _heroTemplate;

    [SerializeField] private HeroGroup _heroGroupPrefab;

    [SerializeField] private EnemyNPC _creepPrefab;
    private EnemyNPC _creepTemplate;

    [SerializeField] private UnitManager _heroManager;

    [SerializeField] private HeroGroupManager _heroGroupManager;

    private TestUnitSpawner _testHeroSpawner;


    void Awake()
    { 
        _testHeroSpawner = GetComponent<TestUnitSpawner>();
    }
    void Start()
    {
        
    }



    public void SpawnHero()
    {
        Hero hero = Instantiate(_heroPrefab);
        _heroManager.AddHeroToList(hero);
        hero.transform.parent = _heroManager.transform;
        ((IAddUnitToGroup)this).AddUnitToGroup(hero,_heroManager.heroList);
        _heroManager.heroList.Add(hero);

        IEnumerable<HeroGroup> baseGroupQuerry = from heroGroup in _heroGroupManager.heroGroupList where heroGroup.name == "Base" select heroGroup;
        //baseGroup.heroList.Add(hero);
        if (baseGroupQuerry == null)
        {
            Debug.Log("_unitSpawner.baseGroupQuerry is null");
        }
        else
        {
            Debug.Log("_unitSpawner.baseGroupQuerry is NOT null");
            Debug.Log("_unitSpawner.baseGroupQuerry count =  "+ baseGroupQuerry.Count());
        }
        HeroGroup heroGroupToAdd = baseGroupQuerry.FirstOrDefault();
        if (heroGroupToAdd == null) 
        {
            Debug.Log("_unitSpawner.heroGroupToAdd is null"); 
        }
        else
        {
            ((IAddUnitToGroup)this).AddUnitToGroup(hero, heroGroupToAdd/*.heroList*/);
        }
        //
        SetRandomStatsFromSO(ref hero);

    }

    public void SpawnEnpc(HeroGroup heroGroup)
    { 
        EnemyNPC creep = Instantiate(_creepPrefab);
        heroGroup.enemyNPCList.Add(creep);
    }
    public void CreateHeroGroup()
    { 
        HeroGroup heroGroup = Instantiate (_heroGroupPrefab);
        heroGroup.transform.parent=_heroGroupManager.transform;
        _heroGroupManager.heroGroupList.Add(heroGroup);
        heroGroup.name = "Group Name";
    }
    
    void SetHeroStatsFromSO(Hero hero)
    { 
        
    }
    void SetRandomStatsFromSO(ref Hero hero)
    {
        var list_SO = _testHeroSpawner.testHero_SOs;
        int randomIndex = UnityEngine.Random.Range(0, list_SO.Count /*- 1*/);
        Debug.Log("unitSpawner.list Lenght is: " + list_SO.Count.ToString()) ;
        Debug.Log("unitSpawner.list Index= "+randomIndex.ToString());



        string textToPrint;
        string index;
        if (list_SO[randomIndex] = null)
        {
            textToPrint = "uiSpawner.So is Null";
            index = "";
        }
        else 
        {
            textToPrint = "uiSpawner.So is NOT Null, index: ";
            index = randomIndex.ToString();
        }
        Debug.Log(textToPrint + index);
        hero.unitStats.SetStats(list_SO[randomIndex]);
    }
}
