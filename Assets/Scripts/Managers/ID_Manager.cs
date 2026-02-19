using System.Collections.Generic;
using UnityEngine;

public class ID_Manager : Singleton<ID_Manager>
{//used for Units and HeroGroups (forNow)

    public static new ID_Manager instance => Singleton<ID_Manager>.instance;
    public int nextFreeID = 1;//ID 0 is saved for BaseHeroGroup
    List <int> freeIDs = new List<int>();

    private void Awake()
    {
        base.Awake();
    }
    public int ReturnID()
    {
        int idToReturn;
        if (freeIDs.Count > 0)
        {
            idToReturn = freeIDs[0];
            freeIDs.RemoveAt(0);
        }
        else 
        {
            idToReturn = nextFreeID;
            nextFreeID++;
        }
        return idToReturn;
    }
    public void MakeIDAvailable(int id)
    { 
        freeIDs.Add(id);
    }
    public IDManager_SaveData SaveID_Manager()
    {
        IDManager_SaveData data = new IDManager_SaveData();
        data.nextFreeID = nextFreeID;
        data.freeIDs = freeIDs;
        return data;
    }
    public void LoadID_Manager(IDManager_SaveData data)
    {
        nextFreeID = data.nextFreeID;
        freeIDs = data.freeIDs;
    }
}
