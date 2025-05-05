using NUnit.Framework;

using System;
using System.Collections.Generic;
using UnityEngine;

interface IAddUnitToList
{
    void AddUnitToList(Unit unit,List<Unit> list)
    { 
        list.Add(unit);
    }
    void AddUnitToList(Hero unit, List<Hero> list)
    {
        list.Add(unit);
    }
    void AddUnitToList(Creep unit, List<Creep> list)
    {
        list.Add(unit);
    }
}
