using NUnit.Framework;

using System;
using System.Collections.Generic;
using UnityEngine;

interface IAddUnitToGroup
{
    void AddUnitToGroup(Unit unit,List<Unit> list)
    { 
        list.Add(unit);
    }
    void AddUnitToGroup(Hero unit, List<Hero> list)
    {
        list.Add(unit);
    }
    void AddUnitToGroup(EnemyNPC unit, List<EnemyNPC> list)
    {
        list.Add(unit);
    }
    void AddUnitToGroup(Unit unit, HeroGroup heroGroup, List<Unit> list)
    {
        unit.transform.parent = heroGroup.transform;
        list.Add(unit);
    }
    void AddUnitToGroup(Hero unit, HeroGroup heroGroup, List<Hero> list)
    {
        unit.transform.parent = heroGroup.transform;
        list.Add(unit);
        heroGroup.heroList.Add(unit);
    }
    void AddUnitToGroup(EnemyNPC unit, HeroGroup heroGroup, List<EnemyNPC> list)
    {
        unit.transform.parent = heroGroup.transform;
        list.Add(unit);
        heroGroup.enemyNPCList.Add(unit);
    }
    void AddUnitToGroup(Unit unit, HeroGroup heroGroup)
    {
        unit.transform.parent = heroGroup.transform;
        //list.Add(unit);
        Debug.Log("IAddUnitToGroup. unit not added to a group");
    }
    void AddUnitToGroup(Hero unit, HeroGroup heroGroup)
    {
        unit.transform.parent = heroGroup.transform;
        
        heroGroup.heroList.Add(unit);
    }
    void AddUnitToGroup(EnemyNPC unit, HeroGroup heroGroup)
    {
        unit.transform.parent = heroGroup.transform;
        
        heroGroup.enemyNPCList.Add(unit);
    }
}
