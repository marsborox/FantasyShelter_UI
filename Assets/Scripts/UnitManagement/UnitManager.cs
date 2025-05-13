using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private UnitSpawner _unitSpawner;
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
    public void AddHeroToGroup(Hero hero, HeroGroup heroGroup,List<Hero> heroList)
    { 
        hero.transform.parent = heroGroup.transform;
        
        heroList.Add(hero);
    }
}
