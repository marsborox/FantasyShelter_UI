using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class HeroManager : MonoBehaviour
{
    [SerializeField] private UnitSpawner _unitSpawner;
    [SerializeField] private HeroGroupManager _heroGroupManager;
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
    public void MoveHeroToGroup(Hero hero, HeroGroup _heroGroup)
    {
        Debug.Log("heroManager. MovingHeroToGroup");
        if (!(hero.heroGroupImInName == ""))
        {
            string groupName = hero.heroGroupImInName;
            Debug.Log("heromanager groupToRemoveName = "+groupName);
            IEnumerable<HeroGroup> baseGroupQuerry = from heroGroup in _heroGroupManager.heroGroupList where heroGroup.name == groupName select heroGroup;
            HeroGroup heroGroupToRemove = baseGroupQuerry.FirstOrDefault();
            heroGroupToRemove.RemoveUnitFromDesignatedList(hero);
        }

        _heroGroup.AddUnitToDesignatedList(hero);
        hero.heroGroupImInName = _heroGroup.name;
    }
}

