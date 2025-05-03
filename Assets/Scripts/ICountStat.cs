using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public interface ICountStat
{
    
    public void CountStat<T>(ref int globalStat, List<T> listWeCountIn)
    {
        globalStat = 0;
        //var returnStat;
        
        for (int i = 0; i < listWeCountIn.Count - 1; i++)
        {
            //globalStat = globalStat + listWeCountIn[i]/*.stat*/;
        }
    }
       
}
