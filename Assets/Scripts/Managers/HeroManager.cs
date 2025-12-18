using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    [SerializeField] private UnitSpawner _unitSpawner;
    [SerializeField] private HeroGroupManager _heroGroupManager;
    [SerializeField] HeroGroup _baseHeroGroup;
    public List <Hero> heroList = new List<Hero>();
    
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
        //Debug.Log("heroManager. MovingHeroToGroup");
        if (hero.heroGroupImInName == "Base")
        {
            _baseHeroGroup.RemoveUnitFromDesignatedList(hero);
        }
        else if (!(hero.heroGroupImInName == ""))
        {

            IEnumerable<HeroGroup> baseGroupQuerry = from heroGroup in _heroGroupManager.heroGroupList where heroGroup.id == hero.heroGroupImInID select heroGroup;
            HeroGroup heroGroupToRemove = baseGroupQuerry.FirstOrDefault();
            heroGroupToRemove.RemoveUnitFromDesignatedList(hero);
        }

        _heroGroup.AddUnitToDesignatedList(hero);
        hero.heroGroupImInName = _heroGroup.heroGroupName;
        hero.heroGroupImInID = _heroGroup.id;
        hero.transform.parent=_heroGroup.transform;
    }
    public void MoveHeroToBaseGroup(Hero hero)
    {
        MoveHeroToGroup(hero, _baseHeroGroup);
    }
    #region TestMethods

    void MoveHeroToGroup_TS(string groupName)
    {
        Debug.Log("heromanager groupToRemoveName = " + groupName);
        
    }
    #endregion
}

