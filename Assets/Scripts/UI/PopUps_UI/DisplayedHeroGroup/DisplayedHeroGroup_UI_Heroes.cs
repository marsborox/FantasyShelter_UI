using UnityEngine;

public class DisplayedHeroGroup_UI_Heroes : UI
{
    [SerializeField] DisplayedHeroGroup_UI _displayedHeroGroup_UI;
    [SerializeField] DisplayedHeroGroup_HeroInGroup_UI _HeroInGroup_UI_Prefab;

    private void OnEnable()
    {
        
        DisplayHeroesInList();
    }
    private void DisplayHeroesInList()
    {
        DestroyChildren();
        foreach (Unit unit in _displayedHeroGroup_UI.displayedHeroGroup.heroList)
        {
            DisplayedHeroGroup_HeroInGroup_UI spawnedHeroTab = Instantiate(_HeroInGroup_UI_Prefab);
            spawnedHeroTab.transform.parent = transform;
            spawnedHeroTab.hero = (Hero)unit;
        }
    }
}
