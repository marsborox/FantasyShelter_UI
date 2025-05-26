using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayedHero_Actions_MiniHeroGroupsList_UI : UI
{
    [SerializeField] HeroGroupManager _heroGroupManager;
    [SerializeField] DisplayedHero_Tabs_UI _displayedHeroTabs_UI;
    [SerializeField] DisplayedHero_Actions_MiniHeroGroups_UI _displayedHeroGroups_UI;
    [SerializeField] DisplayedHero_Actions_MiniHeroGroup_BUTTON _heroGroupButtonPrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
            InitiateButton(spawnedButton.button,SetButtonForChangeHeroGroup,heroGroup);
            spawnedButton.SetButtonText(heroGroup.heroGroupName);
            if (heroGroup.id == _displayedHeroTabs_UI.displayedHero.heroGroupImInID)
            {
                
                SetButtonPressedColor(spawnedButton.button);
            }
        }
    }
    private void SetButtonForChangeHeroGroup(HeroGroup heroGroup)
    {
        heroManager.MoveHeroToGroup(_displayedHeroTabs_UI.displayedHero,heroGroup);
        _displayedHeroGroups_UI.Close();
        
    }
    

}
