using System;
using System.Collections.Generic;
using UnityEngine;

public interface ICalcStat
{
    public int CalcStat<T>(Func<T, int> getStat, List<T> list)
    {
        int returnStat = 0;
        foreach (var inputObject in list)
        {
            returnStat += getStat(inputObject);
        }
        return returnStat;
    }
    //******************************* discontinued methods

    public void CountStat<T>(ref int globalStat, List<T> listWeCountIn)
    {
        globalStat = 0;
        //var returnStat;
        
        for (int i = 0; i < listWeCountIn.Count - 1; i++)
        {
            //globalStat = globalStat + listWeCountIn[i]/*.stat*/;
        }
    }

    /*int CalcStats(Func<Unit, int> getUnitStat, List<Unit> list)
    {
        int returnStat = 0;
        foreach (Unit unit in list)
        {
            returnStat += getUnitStat(unit);
        }
        return returnStat;
    }*/
}
