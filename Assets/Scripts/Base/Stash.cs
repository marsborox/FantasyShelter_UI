using System.Collections.Generic;

using UnityEngine;

public class Stash : Singleton<Stash>
{
    public static new Stash instance => Singleton<Stash>.instance;
    
    public List<Item> itemStashList = new List<Item>();


    public void AddItemToStash(Item item)
    { 
        itemStashList.Add(item);
    }
    public void RemoveItemFromStash(Item item)
    { 
        itemStashList.Remove(item);
    }
}
