using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public interface ICountStat
{
    
    public void CountStat(ref int globalStat, List<int> listWeCountIn)
    {
        globalStat = 0;
        
        for (int i = 0; i < listWeCountIn.Count - 1; i++)
        { 
            
        }
    }
       
}
