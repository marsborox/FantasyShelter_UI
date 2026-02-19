using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

public class UnitSpawner : Singleton<UnitSpawner> 
{
    public static new UnitSpawner instance => Singleton<UnitSpawner>.instance;
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
        base.Awake();
        _testHeroSpawner = GetComponent<TestUnitSpawner>();
    }

    public void SpawnHero()
    {
        Hero hero = Instantiate(_heroPrefab);
        hero.uniqueID = ID_Manager.instance.ReturnID();
        hero.DoBasicSetup();
        hero.SetHeroGroupManagerReference(_heroGroupManager);
        
        //hero.transform.parent = _heroManager.transform;
        SetStatsFromRandomSO(ref hero);
        _heroManager.heroList.Add(hero);
             
        //add to baseGroup

        _heroManager.MoveHeroToBaseGroup(hero);
    }
    public Hero ReturnHeroForLoad()
    {
        Hero hero = Instantiate(_heroPrefab);
        hero.DoBasicSetup();
        hero.SetHeroGroupManagerReference(_heroGroupManager);

        //hero.transform.parent = _heroManager.transform;
        //SetStatsFromRandomSO(ref hero);
        _heroManager.heroList.Add(hero);

        //add to baseGroup

        //_heroManager.MoveHeroToBaseGroup(hero);
        return hero;
    }
    public void SpawnNpc(HeroGroup heroGroup)
    { 
        EnemyNPC creep = Instantiate(_creepPrefab);
        heroGroup.enemyNPCList.Add(creep);
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
        hero.stats.SetBaseStatsFromSO(list_SO[randomIndex]);
        
    }

}
