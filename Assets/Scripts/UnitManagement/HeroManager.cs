using System.Collections.Generic;

using NUnit.Framework;

using UnityEngine;

public class HeroManager : MonoBehaviour
{
    [SerializeField] UnitSpawner unitSpawner;
    public List <Hero> heroList = new List<Hero>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHeroToList(Hero hero)
    { 
        heroList.Add(hero);
    }
}
