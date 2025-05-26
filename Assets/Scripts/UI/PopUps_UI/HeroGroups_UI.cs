using UnityEngine;

public class HeroGroups_UI : UI
{
    [SerializeField] HeroGroupManager _heroGroupManager;
    [SerializeField] HeroGroupInList_UI _heroGroupInListPrefab;
    [SerializeField] DisplayedHeroGroup_UI _displayedHeroGroup_UI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void OnEnable()
    {
        DestroyChildren();
        DisplayHeroGroups();
    }

    private void DisplayHeroGroups()
    {
        foreach (HeroGroup heroGroup in _heroGroupManager.heroGroupList)
        {
            var heroGroupInList = Instantiate(_heroGroupInListPrefab);
            heroGroupInList.transform.parent = this.transform;
            //heroGroupInList. set displayedHeroGroup
            //set 
            heroGroupInList.SetGroupUI_Reference(_displayedHeroGroup_UI);
            heroGroupInList.heroGroup = heroGroup;
            

            //heroInList.stats = heroGroup.stats;
        }
    }
}
