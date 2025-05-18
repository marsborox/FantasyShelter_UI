using NUnit.Framework;

using System.Collections.Generic;
using UnityEngine;

public class HeroGroupManager : MonoBehaviour
{
    [SerializeField] private HeroGroup _heroGroupPrefab;
    public List<HeroGroup> heroGroupList = new List<HeroGroup>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    /*
    public void CreateGroup()
    {
        HeroGroup heroGroupToSpawn = heroGroupPrefab;
        Instantiate(heroGroupToSpawn);
        heroGroupList.Add(heroGroupToSpawn);
        heroGroupToSpawn.transform.parent = transform;
    }*/

}
