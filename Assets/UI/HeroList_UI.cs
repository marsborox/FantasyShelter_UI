using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeroList_UI : UI
{
    public HeroGroup_MiniPopUps heroGroup_MiniPopUpSpawner;
    [SerializeField]private DisplayedHero_Actions_MiniHeroGroups_UI _bulkMoveHeroesToGroup;
    // minipopupspawner here
    [SerializeField]private StatField_List _statFieldList_CONST;

    [SerializeField]private UIDocument _rootUIDocument;
    [SerializeField]private Texture _checkmarkImage;
    private VisualElement _rootElement;
    private VisualElement _header;
    private VisualElement _sortingButtons;
    private VisualElement _bulkCommandButtons;
    private VisualElement _heroList;
    private VisualElement _heroBarToolBar;
    private VisualElement _displayedHeroes;

    public const string HERO_NAME = "HeroName";
    public const string LEVEL = "Level";
    public const string ACTIVITY = "Activity";
    public const string HEALTH = "Health";
    public const string DAMAGE = "Damage";
    public const string DEFENSE = "Defense";
    public const string ENERGY = "Energy";
    public const string GROUP = "Group";
    public const string PROFESSION_SKILL = "ProfessionSkill";
    public const string STATUS = "Status";

    private List<StatField> _statFieldList = new List<StatField>();
    private StatField _heroNameField = new StatField("HeroName",HERO_NAME,BASIC_TEXT_CONTAINER_LARGE);
    private StatField _heroLevelField = new StatField("LVL",LEVEL,BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroActivityField = new StatField("Activity",ACTIVITY,BASIC_TEXT_CONTAINER_MEDIUM);
    private StatField _heroHealthField = new StatField("HP",HEALTH,BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroDamageField = new StatField("DMG",DAMAGE,BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroDefenseField = new StatField("DEF",DEFENSE,BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroEnergyField = new StatField("EN",ENERGY,BASIC_TEXT_CONTAINER_SMALL);
    private StatField _heroGroupField = new StatField("Group",GROUP,BASIC_TEXT_CONTAINER_MEDIUM);
    private StatField _heroProfSkillField = new StatField("Prof. Skill",PROFESSION_SKILL,BASIC_TEXT_CONTAINER_MEDIUM);
    private StatField _heroStatusField = new StatField("Status",STATUS,BASIC_TEXT_CONTAINER_MEDIUM);
    



    private List<VisualElement> _heroListVisual = new List<VisualElement>();
    public List<HeroInList> _heroInListVisual = new List<HeroInList>();
    public bool isUiOpen = false;

    private string _heroListClass = "hero-list";
    /* header a kazdy heroInList - spawnut StatField na kazdy stat aky existuje a asi spravit list - 
    na kazdeho heroInList a header a eoInList vsetky + header do listu*/
    void Awake()
    {
        _rootElement = _rootUIDocument.rootVisualElement;

        _header = _rootElement.Q(name: "Header");
        _sortingButtons = _rootElement.Q(name: "SortingButtons");
        _bulkCommandButtons = _rootElement.Q(name: "BulkComandButtons");
        _heroList = _rootElement.Q(name: "Hero-List");
        _heroBarToolBar = _rootElement.Q(name: "HeroBarToolBar"); 
        _displayedHeroes = _rootElement.Q(name: "DisplayedHeroes");

        AddStatFieldsToList();

    }
    void OnEnable()
    {

    }

    void Start()
    {
        
        base.Start();
        SetHeader();
        CloseUI();

    }
    public override void DisplayUI()
    {
        //Debug.Log("heroListBtn");
        if(!isUiOpen)
        {
            OpenUI();
        }
        else
        {
            CloseUI();
        }
    }

    public override void OpenUI()
    {
        //Debug.Log("opening UI");
        _heroList.AddToClassList(_heroListClass);
        
        DisplayBulkCommandButtons();
        DisplaySortingButtons();
        DisplayHeroListHeader();
        foreach (Hero hero in HeroManager.instance.heroList)
        {
            DisplayOneHeroInList(hero);
        }
        
        ShowElement(_heroList);
        isUiOpen = true;
    }

    public override void CloseUI()
    {
        //Debug.Log("Closing heroList UI");
        _heroList.RemoveFromClassList(_heroListClass);
        _heroListVisual.Clear();
        _sortingButtons.Clear();
        _bulkCommandButtons.Clear();
        _heroBarToolBar.Clear();
        _displayedHeroes.Clear();
        HideElement(_heroList);
        isUiOpen = false;
    }
    public override void SetHeader()
    {
        VisualElement topUI_BAR = ReturnTopUI_Bar(uiPanelName,CloseUI);
        _header.Add(topUI_BAR);
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
    {   //************************************************************ WORK HERE
        //BulkCommandButtons
        
        Button moveToGroupButton = ReturnButton(BASIC_TEXT_CONTAINER_LARGE,"MoveToGroup");
        this._bulkCommandButtons.Add(moveToGroupButton);
        InitiateButton(moveToGroupButton,heroGroup_MiniPopUpSpawner.DisplayUI);

        Button dummyButton = ReturnButton(BASIC_TEXT_CONTAINER_120px,"DummyBTN");
        this._bulkCommandButtons.Add(dummyButton);
        
    }
    public void DisplayHeroListHeader()
    {
        VisualElement heroNameField = ReturnTextWindow(BASIC_TEXT_CONTAINER_LARGE,HERO_NAME);
        _heroBarToolBar.Add(heroNameField);

        //may add pictograms here
        VisualElement checkmark = ReturnPictogram("Checkmark",_checkmarkImage);
        Image checkmarkImg = (Image)checkmark.Q(name: "Checkmark");

        checkmarkImg.AddToClassList(IMAGE_COLOR_GREEN);
        
        _heroBarToolBar.Add(checkmark);
        
        VisualElement heroFace = ReturnPictogram(HERO_NAME);
        _heroBarToolBar.Add(heroFace);

        foreach(StatField statfield in _statFieldList)
        {//add names
            if(statfield.isDisplayed == false || statfield.name == HERO_NAME) {continue;}
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
        InitiateElement(heroNameField,UIManager.instance.DisplayHeroUI,hero);

        //may add pictograms here
        VisualElement checkmark = ReturnPictogram("Checkmark",_checkmarkImage);
        Image checkmarkImg = (Image)checkmark.Q(name: "Checkmark");
        checkmarkImg.AddToClassList(IMAGE_COLOR_GREEN);
        InitiateElement(checkmark, heroInList.Select);
        checkmarkImg.style.display = DisplayStyle.None;
        heroInListVisual.Add(checkmark);
        
        VisualElement heroFace = ReturnPictogram("Heroface");

        heroInListVisual.Add(heroFace);

        foreach(StatField statfield in _statFieldList)
        {//add names
            if(statfield.isDisplayed == false|| statfield.name == HERO_NAME) {continue;}
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
            case HERO_NAME: return hero.ReturnName();
            case LEVEL: return "LVL";
            case ACTIVITY: return "Activity";
            case HEALTH: return hero.ReturnHealthCurrent().ToString();
            case DAMAGE: return hero.ReturnDamageCurrent().ToString();
            case DEFENSE: return hero.ReturnDefenseCurrent().ToString();
            case ENERGY: return hero.ReturnEnergyCurrent().ToString();
            case GROUP: return hero.ReturnGroupImInName();
            case PROFESSION_SKILL: return "Prof. Skill";
            case STATUS: return "Status";
            default: return "UNKNOWN";  
        }
        
    }


        /*private string ReturnCorrectStatValue2(Hero hero, string statName)
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
            case "Group": return hero.ReturnGroupImInName();
            case "ProfessionSkill": return "Prof. Skill";
            case "Status": return "Status";
        }
        return "UNKNOWN";  
    }
       */


    public List<Hero> ReturnSelectedHeroes()
    {
        List<Hero> selectedHeroes = new List<Hero>();
        //if opened close
        foreach(HeroInList heroVisual in _heroInListVisual)
        {
            if (heroVisual.isSelected)
            {
                selectedHeroes.Add(heroVisual.heroIRepresent);
            }
        }
        return selectedHeroes;
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

