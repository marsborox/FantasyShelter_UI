using System;
using System.Collections;
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
        //public Hero heroIRepresent;

        public void SetStatFieldValueText(Func<Hero,string> displayValue,Hero hero)
        {
            
        }
        public StatField(string inputDefaultText, string inputName,string inputContainerClass)
        {
            isDisplayed = true;
            name = inputName;
            containerClass = inputContainerClass;
            defaultText = inputDefaultText;
        }
        public StatField(string inputDefaultText, string inputName,string inputContainerClass, Func<Hero,string> displayValue,Hero hero)
        {
            //for header
            isDisplayed = true;
            name = inputName;
            containerClass = inputContainerClass;
            defaultText = inputDefaultText;
            //value = displayValue(heroIRepresent);
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
    public class HeroInList
    {
        public Hero heroIRepresent;
        public bool isSelected = false;
        public VisualElement heroInListVisual;

        public void Select()
        {
            if(isSelected) 
            {
                isSelected=false;
                Image image = (Image)heroInListVisual.Q(name: "Checkmark");
                //enable disable
                Debug.Log("CheckmarkOff");
                Debug.Log(image.name);
            }
            else 
            {
                isSelected = true;
                Debug.Log("CheckmarkOn");
            }
            Debug.Log("some hero checkmark: "+isSelected);
        }
        public HeroInList(Hero hero, VisualElement visualElement)
        {
            heroIRepresent = hero;
            heroInListVisual = visualElement;
        }
    }

    [SerializeField]private UIDocument _uiDocument;
    private VisualElement _rootElement;
    private VisualElement _sortingButtons;
    private VisualElement _bulkCommandButtons;
    private VisualElement _heroBarToolBar;
    private VisualElement _displayedHeroes;
    
    private List<StatField> _statFieldList = new List<StatField>();
    private StatField _heroNameField = new StatField("HeroName","HeroName",BASIC_TEXT_CONTAINER_LARGE);
    private StatField _heroLevelField = new StatField("LVL","Level",BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroActivityField = new StatField("Activity","Activity",BASIC_TEXT_CONTAINER_MEDIUM);
    private StatField _heroHealthField = new StatField("HP","Health",BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroDamageField = new StatField("DMG","Damage",BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroDefenseField = new StatField("DEF","Defense",BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroEnergyField = new StatField("EN","Energy",BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroGroupField = new StatField("Group","Droup",BASIC_TEXT_CONTAINER_MEDIUM);
    private StatField _heroProfSkillField = new StatField("Prof. Skill","ProfessionSkill",BASIC_TEXT_CONTAINER_MEDIUM);
    private StatField _heroStatusField = new StatField("Status","Status",BASIC_TEXT_CONTAINER_MEDIUM);


    private List<VisualElement> _heroListVisual = new List<VisualElement>();
    private List<HeroInList> _heroInListVisual = new List<HeroInList>();
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

        _heroListVisual.Clear();
        _sortingButtons.Clear();//need to spawn sorting buttons too
        _bulkCommandButtons.Clear();
        _heroBarToolBar.Clear();
        _displayedHeroes.Clear();
    }
    private void DisplaySortingButtons()
    {
        foreach(StatField statfield in _statFieldList)

        {
            Button button = ReturnButton(BASIC_TEXT_CONTAINER_120px,statfield.defaultText);
            _sortingButtons.Add(button);
            button.name = statfield.name;
        }
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
        VisualElement heroNameField = ReturnTextWindow(BASIC_TEXT_CONTAINER_LARGE,"HeroName");
        _heroBarToolBar.Add(heroNameField);

        //may add pictograms here
        VisualElement checkmark = ReturnPictogram("Checkmark");
        _heroBarToolBar.Add(checkmark);
        
        VisualElement heroFace = ReturnPictogram("HeroFace");
        _heroBarToolBar.Add(heroFace);

        foreach(StatField statfield in _statFieldList)
        {//add names
            if(statfield.isDisplayed == false || statfield.name =="HeroName") {continue;}
            VisualElement element = ReturnTextWindow(statfield.containerClass,statfield.defaultText);
            element.name = statfield.name;
            _heroBarToolBar.Add(element); 
        }
    }

    public void DisplayOneHeroInList(Hero hero)
    {
        VisualElement heroInListVisual = new VisualElement();
        _heroListVisual.Add(heroInListVisual);
        heroInListVisual.AddToClassList("heroes-bar");

        _displayedHeroes.Add(heroInListVisual);
        HeroInList heroInList = new HeroInList(hero,heroInListVisual);
        _heroInListVisual.Add(heroInList);
        
        VisualElement heroNameField = ReturnTextWindow(BASIC_TEXT_CONTAINER_LARGE,hero.ReturnName());
        heroInListVisual.Add(heroNameField);
        InitiateElement(heroNameField,UIManager.instance.OpenHeroUI,hero);

        //may add pictograms here
        VisualElement checkmark = ReturnPictogram("Checkmark");
        InitiateElement(checkmark, heroInList.Select);
        heroInListVisual.Add(checkmark);
        
        VisualElement heroFace = ReturnPictogram("Heroface");
        heroInListVisual.Add(heroFace);


        foreach(StatField statfield in _statFieldList)
        {//add names
            if(statfield.isDisplayed == false|| statfield.name == "HeroName") {continue;}
            VisualElement element = ReturnTextWindow(statfield.containerClass,ReturnCorrectStatValue(hero,statfield.name));
            element.name = statfield.name;
            heroInListVisual.Add(element);
            //InitiateElement(element,UIManager.instance.OpenHeroUI,hero);//tho whole bar will open hero
        }
        
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

    private string ReturnCorrectStatValue(Hero hero, string statName)
    {
        
        switch(statName)
        {
            case "HeroName": return hero.ReturnName();
            case "Level": return "LVL";
            case "Activity": return "Activity";
            case "Health": return hero.ReturnHealthCurrent().ToString();
            case "Damage": return hero.ReturnDamageCurrent().ToString();
            case "Defense": return hero.ReturnDefenseCurrent().ToString();
            case "Energy": return hero.ReturnEnergyCurrent().ToString();
            case "Group": return hero.heroGroupImInName;
            case "ProfessionSkill": return "Prof. Skill";
            case "Status": return "Status";
        }
        return "UNKNOWN";        
    }
    private void HideShowColumns()
    {
        
    }

}
    /*public void DisplayHeroListHeader()
    {

        
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
        */

           /* public void DisplayOneHeroInList(Hero hero)
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
        VisualElement heroGroupField = ReturnTextWindow(BASIC_TEXT_CONTAINER_MEDIUM,hero.heroGroupImInName); //remove coment
        heroInList.Add(heroGroupField);
        //prof skill
        VisualElement heroProfSkillField = ReturnTextWindow(BASIC_TEXT_CONTAINER_MEDIUM,"Prof. Skill");
        heroInList.Add(heroProfSkillField);
        //status
        VisualElement heroStatusField = ReturnTextWindow(BASIC_TEXT_CONTAINER_MEDIUM,"Status");
        heroInList.Add(heroStatusField);

        _displayedHeroes.Add(heroInList)
    }
    */

