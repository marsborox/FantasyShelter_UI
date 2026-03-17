using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class HeroList_UI : UI
{
    [SerializeField]private UIDocument _uiDocument;
    private VisualElement _rootElement;
    private VisualElement _sortingButtons;
    private VisualElement _bulkCommandButtons;
    private VisualElement _heroBarToolBar;
    private VisualElement _displayedHeroes;
    
    private List<VisualElement> _heroListVisual = new List<VisualElement>();
    public bool isUiOpen = false;

    void Awake()
    {
        _rootElement = _uiDocument.rootVisualElement;
        _sortingButtons = _rootElement.Q(name: "SortingButtons");
        _bulkCommandButtons = _rootElement.Q(name: "BulkComandButtons");
        _heroBarToolBar = _rootElement.Q(name: "HeroBarToolBar"); 
        _displayedHeroes = _rootElement.Q(name: "DisplayedHeroes");
    }
    void OnEnable()
    {

    }
    public void DisplayUI()
    {
        if(!isUiOpen)
        {
            isUiOpen = true;
            OpenUI();
        }
        else
        {
            isUiOpen = false;
            CloseUI();
        }
    }

    public void OpenUI()
    {
        //Debug.Log("opening UI");
        DisplayBulkCommandButtons();
        DisplaySortingButtons();
        DisplayHeroListHeader();
        foreach (Hero hero in HeroManager.instance.heroList)
        {
            DisplayOneHeroInList(hero);
        }
    }


    public void CloseUI()
    {
        //Debug.Log("closing UI");
        /*foreach(VisualElement element in _heroListVisual)
        
        {
           element.RemoveFromHierarchy();
           
        }
        _heroListVisual.Clear();*/
        _sortingButtons.Clear();//need to spawn sorting buttons too
        _bulkCommandButtons.Clear();
        _heroBarToolBar.Clear();
        _displayedHeroes.Clear();
    }
    private void DisplaySortingButtons()
    {
        
    }
    private void DisplayBulkCommandButtons()
    {        //************************************************************ WORK HERE
        //BulkCommandButtons
        Button moveToGroupButton = ReturnButton(/*MY_BUTTON+" "+*/BASIC_TEXT_CONTAINER_LARGE,"MoveToGroup");
        this._bulkCommandButtons.Add(moveToGroupButton);

        Button dummyButton = ReturnButton(BASIC_TEXT_CONTAINER_120px,"DummyBTN");
        this._bulkCommandButtons.Add(dummyButton);
        
    }
    public void DisplayHeroListHeader()
    {
        //SortingButtons


        //Name
        VisualElement heroNameField = ReturnTextWindow(BASIC_TEXT_CONTAINER_LARGE,"HeroName");
        _heroBarToolBar.Add(heroNameField);        
        //Level
        VisualElement heroLevelField = ReturnTextWindow(BASIC_TEXT_CONTAINER_SMALL,"LVL");
        _heroBarToolBar.Add(heroLevelField);
        //Activity
        VisualElement heroActivityField = ReturnTextWindow(BASIC_TEXT_CONTAINER_MEDIUM,"Activity");
        _heroBarToolBar.Add(heroActivityField);
        //Health
        VisualElement heroHealthField = ReturnTextWindow(BASIC_TEXT_CONTAINER_SMALL,"HP");
        _heroBarToolBar.Add(heroHealthField);
        //damage
        VisualElement heroDamageField = ReturnTextWindow(BASIC_TEXT_CONTAINER_SMALL,"DMG");
        _heroBarToolBar.Add(heroDamageField);
        //defense
        VisualElement heroDefenseField = ReturnTextWindow(BASIC_TEXT_CONTAINER_SMALL,"DEF");
        _heroBarToolBar.Add(heroDefenseField);
        //energy
        VisualElement heroEnergyField = ReturnTextWindow(BASIC_TEXT_CONTAINER_SMALL,"EN");
        _heroBarToolBar.Add(heroEnergyField);
        //group
        VisualElement heroGroupField = ReturnTextWindow(BASIC_TEXT_CONTAINER_MEDIUM,"Group");
        _heroBarToolBar.Add(heroGroupField);
        //prof skill
        VisualElement heroProfSkillField = ReturnTextWindow(BASIC_TEXT_CONTAINER_MEDIUM,"Prof. Skill");
        _heroBarToolBar.Add(heroProfSkillField);
        //status
        VisualElement heroStatusField = ReturnTextWindow(BASIC_TEXT_CONTAINER_MEDIUM,"Status");
        _heroBarToolBar.Add(heroStatusField);
    }

    public void DisplayOneHeroInList(Hero hero)
    {
        VisualElement heroInList = new VisualElement();
        _heroListVisual.Add(heroInList);
        heroInList.AddToClassList("heroes-bar");
        
        //name
        VisualElement heroNameField = ReturnTextWindow(BASIC_TEXT_CONTAINER_LARGE,hero.ReturnName());
        heroInList.Add(heroNameField);
        InitiateElement(heroNameField,UIManager.instance.OpenHeroUI,hero);

        //level
        VisualElement heroLevelField = ReturnTextWindow(BASIC_TEXT_CONTAINER_SMALL,"LVL");
        heroInList.Add(heroLevelField);
        //Activity
        VisualElement heroActivityField = ReturnTextWindow(BASIC_TEXT_CONTAINER_MEDIUM,"Activity");
        heroInList.Add(heroActivityField);
        //Health
        VisualElement heroHealthField = ReturnTextWindow(BASIC_TEXT_CONTAINER_SMALL,hero.ReturnHealthCurrent().ToString());
        heroInList.Add(heroHealthField);
        //damage
        VisualElement heroDamageField = ReturnTextWindow(BASIC_TEXT_CONTAINER_SMALL,hero.ReturnDamageCurrent().ToString());
        heroInList.Add(heroDamageField);
        //defense
        VisualElement heroDefenseField = ReturnTextWindow(BASIC_TEXT_CONTAINER_SMALL,hero.ReturnDefenseCurrent().ToString());
        heroInList.Add(heroDefenseField);
        //energy
        VisualElement heroEnergyField = ReturnTextWindow(BASIC_TEXT_CONTAINER_SMALL,hero.ReturnEnergyCurrent().ToString());
        heroInList.Add(heroEnergyField);
        //group
        VisualElement heroGroupField = ReturnTextWindow(BASIC_TEXT_CONTAINER_MEDIUM,hero.heroGroupImInName/*"Group"*/); //remove coment
        heroInList.Add(heroGroupField);
        //prof skill
        VisualElement heroProfSkillField = ReturnTextWindow(BASIC_TEXT_CONTAINER_MEDIUM,"Prof. Skill");
        heroInList.Add(heroProfSkillField);
        //status
        VisualElement heroStatusField = ReturnTextWindow(BASIC_TEXT_CONTAINER_MEDIUM,"Status");
        heroInList.Add(heroStatusField);

        _displayedHeroes.Add(heroInList);
    }

}
