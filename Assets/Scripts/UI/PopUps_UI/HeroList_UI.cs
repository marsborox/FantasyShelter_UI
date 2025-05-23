using UnityEngine;

public class HeroList_UI : UI
{
    
    [SerializeField] HeroInList_UI _heroInListPrefab;
    [SerializeField] UI _displayedHeroTabs_UI;
    [SerializeField] UI _displayedHero_UI;
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
        DisplayHeroes();
    }
    private void OnDisable()
    {

    }
    private void DisplayHeroes()
    {
        foreach (Unit hero in heroManager.heroList)
        { 
            var heroInList= Instantiate(_heroInListPrefab);
            heroInList.transform.parent = this.transform;
            heroInList.hero = hero;
            heroInList.stats = hero.stats;
            heroInList.SetHeroUI_Reference((DisplayedHero_Tabs_UI)_displayedHeroTabs_UI, (DisplayedHero_UI)_displayedHero_UI);
        }
    }

}
