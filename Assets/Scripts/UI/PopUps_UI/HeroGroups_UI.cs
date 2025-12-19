using UnityEngine;

public class HeroGroups_UI : UI
{
    [SerializeField] private HeroGroupManager _heroGroupManager;
    [SerializeField] private HeroGroupInList_UI _heroGroupInListPrefab;
    [SerializeField] private DisplayedHeroGroup_UI _displayedHeroGroup_UI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void OnEnable()
    {
        DisplayHeroGroups();
    }

    private void DisplayHeroGroups()
    {
        DestroyChildren();
        foreach (HeroGroup heroGroup in _heroGroupManager.heroGroupList)
        {
            HeroGroupInList_UI heroGroupInList = Instantiate(_heroGroupInListPrefab);
            heroGroupInList.transform.parent = this.transform;

            //heroGroupInList. set displayedHeroGroup
            //set 
            heroGroupInList.SetGroupUI_Reference(_displayedHeroGroup_UI);
            heroGroupInList.heroGroup = heroGroup;
            heroGroupInList.heroManager = heroManager;

            //heroInList.stats = heroGroup.stats;
        }
    }
}
