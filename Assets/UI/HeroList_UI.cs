using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class HeroList_UI : UI
{
    [System.Serializable]
    public class StatField
    {
        //nejak vopchat do constructora metodu z hera
        public bool isDisplayed;
        public string name;
        public string containerClass;
        public string defaultText;
        public string value;
        public StatField(string inputDefaultText, string inputName,string inputContainerClass)
        {
            isDisplayed = true;
            name = inputName;
            containerClass = inputContainerClass;
            defaultText = inputDefaultText;
                       

        }
        public StatField(string inputDefaultText, string inputName,string inputContainerClass, Func<string> displayValue)
        {
            //for header
            isDisplayed = true;
            name = inputName;
            containerClass = inputContainerClass;
            defaultText = inputDefaultText;
            value = displayValue();
        }

        public StatField(HeroList_UI heroList, string inputDefaultText, string inputName,string inputContainerClass, string inputDisplayValue)
        {
            //for header
            isDisplayed = true;
            name = inputName;
            containerClass = inputContainerClass;
            defaultText = inputDefaultText;
            value = inputDisplayValue;
            
            void DisplayStatField()
            {
                heroList.ReturnTextWindow(containerClass,defaultText);
            }
        }
    }
    [SerializeField]private UIDocument _uiDocument;
    private VisualElement _rootElement;
    private VisualElement _sortingButtons;
    private VisualElement _bulkCommandButtons;
    private VisualElement _heroBarToolBar;
    private VisualElement _displayedHeroes;
    
    private List<StatField> _statFieldList = new List<StatField>();
    private StatField _heroNameField = new StatField("HeroName","heroName",BASIC_TEXT_CONTAINER_LARGE);
    private StatField _heroLevelField = new StatField("LVL","level",BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroActivityField = new StatField("Activity","activity",BASIC_TEXT_CONTAINER_MEDIUM);
    private StatField _heroHealthField = new StatField("HP","health",BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroDamageField = new StatField("DMG","damage",BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroDefenseField = new StatField("DEF","defense",BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroEnergyField = new StatField("EN","energy",BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroGroupField = new StatField("Group","group",BASIC_TEXT_CONTAINER_MEDIUM);
    private StatField _heroProfSkillField = new StatField("Prof. Skill","profession skill",BASIC_TEXT_CONTAINER_MEDIUM);
    private StatField _heroStatusField = new StatField("Status","status",BASIC_TEXT_CONTAINER_MEDIUM);

    private List<VisualElement> _heroListVisual = new List<VisualElement>();
    public bool isUiOpen = false;

    /* header a kazdy heroInList - spawnut StatField na kazdy stat aky existuje a asi spravit list - 
    na kazdeho heroInList a header a eoInList vsetky + header do listu*/
    void Awake()
    {
        _rootElement = _uiDocument.rootVisualElement;
        _sortingButtons = _rootElement.Q(name: "SortingButtons");
        _bulkCommandButtons = _rootElement.Q(name: "BulkComandButtons");
        _heroBarToolBar = _rootElement.Q(name: "HeroBarToolBar"); 
        _displayedHeroes = _rootElement.Q(name: "DisplayedHeroes");

        AddStatFieldsToList();
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
        foreach(StatField statfield in _statFieldList)
        {
            if(statfield.isDisplayed == false) {continue;}
            VisualElement element = ReturnTextWindow(statfield.containerClass,statfield.defaultText);
            _heroBarToolBar.Add(element); 
        }
        /*
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
        */
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
    private void AddStatFieldsToList()
    {
        _statFieldList.Add(_heroNameField);
        _statFieldList.Add(_heroLevelField);
        _statFieldList.Add(_heroActivityField);
        _statFieldList.Add(_heroHealthField);
        _statFieldList.Add(_heroDamageField);
        _statFieldList.Add(_heroDefenseField);
        _statFieldList.Add(_heroEnergyField);
        _statFieldList.Add(_heroGroupField);
        _statFieldList.Add(_heroProfSkillField);
        _statFieldList.Add(_heroStatusField);
    }
}
