using System;

using UnityEngine;
using UnityEngine.UI;

public class HeroList_UI_BulkCommands : UI
{
    [SerializeField] Button _moveToGroup;

    [SerializeField] DisplayedHero_Actions_MiniHeroGroups_UI _bulkMoveHeroesToGroup;
    private void Start()
    {
        InitiateButton(_moveToGroup, DisplayHeroGroups);
    }
    private void DisplayHeroGroups()
    {
        if (_bulkMoveHeroesToGroup.gameObject.active)
        { 
            _bulkMoveHeroesToGroup.gameObject.SetActive(false);
        }
        else
        {
            _bulkMoveHeroesToGroup.gameObject.SetActive(true);
        }
    }
}
