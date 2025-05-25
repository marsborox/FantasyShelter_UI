using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Hero : Unit
{
    private HeroGroupManager _heroGroupManager;
    public string heroGroupImInName;
    public int heroGroupImInID;
    private void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetHeroGroupManagerReference(HeroGroupManager heroGroupManager)
    { 
        _heroGroupManager = heroGroupManager;
    }

}
