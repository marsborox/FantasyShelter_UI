using System.Collections.Generic;
using UnityEngine;

public class HeroGroupManager : Singleton<HeroGroupManager>
{
    public static new HeroGroupManager instance => Singleton<HeroGroupManager>.instance;
    public HeroManager heroManager;
    public UIManager uiManager;
    public int idCoutner = 0;//0 reserved for base
    [SerializeField] private HeroGroup _heroGroupPrefab;
    public List<HeroGroup> heroGroupList = new List<HeroGroup>();

    private void Awake()
    {
        base.Awake();
    }
    int IncreaseAndReturn_HeroGroup_IDCounter()
    { //discontinued - Must solve base
        idCoutner++;
        return idCoutner;
    }


    /*
    public void CreateGroup()
    {
        HeroGroup heroGroupToSpawn = heroGroupPrefab;
        Instantiate(heroGroupToSpawn);
        heroGroupList.Add(heroGroupToSpawn);
        heroGroupToSpawn.transform.parent = transform;
    }*/
    public void CreateHeroGroup()
    {
        HeroGroup heroGroup = Instantiate(_heroGroupPrefab);
        heroGroup.transform.parent = transform;
        heroGroupList.Add(heroGroup);
        heroGroup.heroGroupName = "Group Name";
        //heroGroup.id = IncreaseAndReturn_HeroGroup_IDCounter();
        heroGroup.uniqueID = ID_Manager.instance.ReturnID();
        heroGroup.heroGroupManager = this;
        heroGroup.heroManager = heroManager;
    }
    public HeroGroup ReturnHeroGroupForLoad()
    {
        HeroGroup heroGroup = Instantiate(_heroGroupPrefab);
        heroGroup.transform.parent = transform;
        heroGroupList.Add(heroGroup);
        heroGroup.heroGroupManager = this;
        heroGroup.heroManager = heroManager;

        return heroGroup;
    }
    public void DestroyHeroGroup(HeroGroup heroGroup)
    { 
        heroGroupList.Remove(heroGroup);
        //uiManager.GroupDisband();
        ID_Manager.instance.MakeIDAvailable(heroGroup.uniqueID);
        Destroy(heroGroup.gameObject);
        //close HeroGroup
        //refresh UI HeroGroups if opened
    }
    
}
