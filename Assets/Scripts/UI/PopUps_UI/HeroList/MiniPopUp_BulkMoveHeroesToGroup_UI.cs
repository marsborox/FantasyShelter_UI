using System.Runtime.CompilerServices;

using UnityEngine;

public class MiniPopUp_BulkMoveHeroesToGroup_UI : UI
{

    [SerializeField] HeroGroupManager _heroGroupManager;
    [SerializeField] HeroList_UI _heroListUI;

    //[SerializeField] DisplayedHero_Tabs_UI _displayedHeroTabs_UI;
    [SerializeField] DisplayedHero_Actions_MiniHeroGroups_UI _displayedHeroGroups_UI;
    [SerializeField] DisplayedHero_Actions_MiniHeroGroup_BUTTON _heroGroupButtonPrefab;

    private void OnEnable()
    {
        DestroyChildren();
        DisplayHeroGroups();
    }
    private void DisplayHeroGroups()
    {
        foreach (HeroGroup heroGroup in _heroGroupManager.heroGroupList)
        {
            DisplayedHero_Actions_MiniHeroGroup_BUTTON spawnedButton = Instantiate(_heroGroupButtonPrefab);
            spawnedButton.transform.SetParent(transform);
            InitiateButton(spawnedButton.button, SetButtonForChangeHeroGroup, heroGroup);
            spawnedButton.SetButtonText(heroGroup.heroGroupName);
        }
    }
    private void SetButtonForChangeHeroGroup(HeroGroup heroGroup )
    {
        //could be Link??
        foreach (HeroInList_UI heroInList in _heroListUI.heroInList_UI_list)
            if (heroInList.checkMarkPressedBool)
            {
                heroManager.MoveHeroToGroup((Hero)heroInList.hero, heroGroup);
                heroInList.CheckMarkButton();
            }
        CloseTab(_displayedHeroGroups_UI);
    }
}
