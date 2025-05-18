using UnityEngine;

public class HeroGroups_UI : UI
{
    [SerializeField] HeroGroupManager _heroGroupManager;
    [SerializeField] HeroGroupInList_UI _heroGroupInListPrefab;
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
            var heroInList = Instantiate(_heroGroupInListPrefab);
            heroInList.transform.parent = this.transform;
            heroInList.heroGroup = heroGroup;
            //heroInList.stats = heroGroup.stats;
        }
    }
}
