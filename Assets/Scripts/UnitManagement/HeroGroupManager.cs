using System.Collections.Generic;
using UnityEngine;

public class HeroGroupManager : MonoBehaviour
{
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

}
