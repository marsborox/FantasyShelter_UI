using System.Collections.Generic;
using UnityEngine;

public class HeroGroupManager : MonoBehaviour
{
    public HeroManager heroManager;
    public UIManager uiManager;
    public int idCoutner = 0;//0 reserved for base
    [SerializeField] private HeroGroup _heroGroupPrefab;
    public List<HeroGroup> heroGroupList = new List<HeroGroup>();

    public int IncreaseAndReturn_HeroGroup_IDCounter()
    { 
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
        heroGroup.id = IncreaseAndReturn_HeroGroup_IDCounter();
        heroGroup.heroGroupManager = this;
        heroGroup.heroManager = heroManager;
    }
    public void DestroyHeroGroup(HeroGroup heroGroup)
    { 
        heroGroupList.Remove(heroGroup);
        Destroy(heroGroup);
        uiManager.GroupDisband();
        //close HeroGroup
        //refresh UI HeroGroups if opened
    }
    
}
