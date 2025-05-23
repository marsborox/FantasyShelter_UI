using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class UnitSpawner : MonoBehaviour, IAddUnitToGroup
{
    [SerializeField] private Hero _heroPrefab;
    private Hero _heroTemplate;

    [SerializeField] private HeroGroup _heroGroupPrefab;

    [SerializeField] private EnemyNPC _creepPrefab;
    private EnemyNPC _creepTemplate;

    [SerializeField] private HeroManager _heroManager;

    [SerializeField] private HeroGroupManager _heroGroupManager;

    private TestUnitSpawner _testHeroSpawner;

    void Awake()
    { 
        _testHeroSpawner = GetComponent<TestUnitSpawner>();
    }

    public void SpawnHero()
    {
        Hero hero = Instantiate(_heroPrefab);
        hero.SetHeroGroupManagerReference(_heroGroupManager);

        hero.transform.parent = _heroManager.transform;
        SetStatsFromRandomSO(ref hero);
        ((IAddUnitToGroup)this).AddUnitToGroup(hero,_heroManager.heroList);
        

        IEnumerable<HeroGroup> baseGroupQuerry = from heroGroup in _heroGroupManager.heroGroupList where heroGroup.name == "Base" select heroGroup;
        HeroGroup heroGroupToAdd = baseGroupQuerry.FirstOrDefault();

        hero.MoveHeroToGroup(heroGroupToAdd);
        //heroGroupToAdd.AddUnitToDesignatedList(hero);
        
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

    private void SetStatsFromRandomSO(ref Hero hero)
    {
        var list_SO = _testHeroSpawner.testHero_SOs;
        int randomIndex = UnityEngine.Random.Range(0, list_SO.Count /*- 1*/);
        //Debug.Log("unitSpawner.list Lenght is: " + list_SO.Count.ToString()) ;
        //Debug.Log("unitSpawner.list Index= "+randomIndex.ToString());

        string textToPrint;
        string index;
        if (list_SO[randomIndex] == null)
        {
            textToPrint = "uiSpawner.So is Null";
            index = "";
        }
        else 
        {
            textToPrint = "uiSpawner.So is NOT Null, index: ";
            index = randomIndex.ToString();
        }
        //Debug.Log(textToPrint + index);
        hero.stats.SetStats(list_SO[randomIndex]);
    }
    private TestUnit_SO SetRandomStatsFromSO()
    {
        var list_SO = _testHeroSpawner.testHero_SOs;
        int randomIndex = UnityEngine.Random.Range(0, list_SO.Count /*- 1*/);
        //Debug.Log("unitSpawner.list Lenght is: " + list_SO.Count.ToString());
        //Debug.Log("unitSpawner.list Index= " + randomIndex.ToString());

        string textToPrint;
        string index;
        if (list_SO[randomIndex] == null)
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
        return list_SO[randomIndex];
    }
}
