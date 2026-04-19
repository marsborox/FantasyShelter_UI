using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UIElements;
using System.Collections;
public class HeroGroups_UI : UI
{
    [SerializeField] private UIDocument _rootUIDocument;
    [SerializeField] private Texture _tempGroupImg;
    private VisualElement _rootElement;
    private VisualElement _header;
    private VisualElement _heroGroupList;
    private VisualElement _heroGroupBarToolBar;
    private VisualElement _displayedHeroGroups;

    private const string GROUP_NAME = "GroupName";
    private const string GROUP_AVERAGE_LVL = "AvgLVL";
    private const string GROUP_GROUP_SIZE = "Group Size";
    private const string GROUP_HEALTH = "Health";
    private const string GROUP_ATTACK = "Attack";
    private const string GROUP_DEFENSE = "Defense";
    private const string GROUP_ENERGY = "Endurance";

    private List<StatField> _statFieldList = new List<StatField>();
    private StatField _nameField = new StatField("GroupName",GROUP_NAME,BASIC_TEXT_CONTAINER_LARGE);
    private StatField _averageLVL = new StatField("AvgLVL",GROUP_AVERAGE_LVL,BASIC_TEXT_CONTAINER_MEDIUM);
    private StatField _groupSize = new StatField("Group Size",GROUP_GROUP_SIZE, BASIC_TEXT_CONTAINER_MEDIUM);
    private StatField _defense = new StatField("DEF",GROUP_DEFENSE,BASIC_TEXT_CONTAINER_SMALL);
    private StatField _energy = new StatField("ATC",GROUP_ENERGY,BASIC_TEXT_CONTAINER_SMALL);
    private StatField _health = new StatField("HP",GROUP_HEALTH,BASIC_TEXT_CONTAINER_SMALL);
    private StatField _attack = new StatField("ATC",GROUP_ATTACK,BASIC_TEXT_CONTAINER_SMALL);

    private List<VisualElement> _heroGroupListVisual = new List<VisualElement>();
    public List<HeroGroupInList> _heroGroupInListVisual = new List<HeroGroupInList>();
    public bool isUiOpen = false;
    private string _heroGroupListClass = "hero-group";

    void Awake()
    {
        _rootElement = _rootUIDocument.rootVisualElement;

        _header = _rootElement.Q(name: "Header");
        _heroGroupList = _rootElement.Q(name:"Hero-Group-List");
        _heroGroupBarToolBar = _rootElement.Q(name: "HeroGroupsToolbar");
        _displayedHeroGroups = _rootElement.Q(name: "DisplayedHeroGroups");
        AddStatFieldsToList();
    }
    void Start()
    {
        base.Start();
        SetHeader();
        CloseUI();

    }
    public override void DisplayUI()
    {
        //Debug.Log("heroGroupBtn");
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
        _heroGroupList.AddToClassList(_heroGroupListClass);

        DisplayHeroGroupListHeader();

        foreach (HeroGroup heroGroup in HeroGroupManager.instance.heroGroupList)
        {
            DisplayOneHeroGroupInList(heroGroup);
        }
        ShowElement(_heroGroupList);
        isUiOpen = true;

    }

    public override void CloseUI()
    {
        Debug.Log("Closing HeroGroupList UI");
        _heroGroupList.RemoveFromClassList(_heroGroupListClass);
        _heroGroupListVisual.Clear();
        _heroGroupBarToolBar.Clear();
        //_heroGroupList.Clear();
        _displayedHeroGroups.Clear();
        HideElement(_heroGroupList);
        isUiOpen = false;
    }

    public override void SetHeader()
    {
        VisualElement topUI_BAR = ReturnTopUI_Bar(uiPanelName,CloseUI);
        _header.Add(topUI_BAR);
    }
    public void DisplayHeroGroupListHeader()
    {
        VisualElement groupNameField = ReturnTextWindow(BASIC_TEXT_CONTAINER_LARGE,GROUP_NAME);
        _heroGroupBarToolBar.Add(groupNameField);

        VisualElement groupImg = ReturnPictogram(GROUP_NAME);
        _heroGroupBarToolBar.Add(groupImg);

        foreach(StatField statfield in _statFieldList)
        {
            if(statfield.isDisplayed == false || statfield.name == GROUP_NAME) {continue;}
            VisualElement element = ReturnTextWindow(statfield.containerClass,statfield.defaultText);
            element.name = statfield.name;
            _heroGroupBarToolBar.Add(element);
        }
    }
    public void DisplayOneHeroGroupInList(HeroGroup heroGroup)
    {
        VisualElement heroGroupInListVisual = new VisualElement();
        _heroGroupListVisual.Add(heroGroupInListVisual);
        heroGroupInListVisual.AddToClassList("heroes-bar");

        _displayedHeroGroups.Add(heroGroupInListVisual);
        HeroGroupInList heroGroupInList = new HeroGroupInList(heroGroup,heroGroupInListVisual);
        _heroGroupInListVisual.Add(heroGroupInList);

        VisualElement heroGroupNameField = ReturnTextWindow(BASIC_TEXT_CONTAINER_LARGE, heroGroup.ReturnHeroGroupName());
        heroGroupInListVisual.Add(heroGroupNameField);
        InitiateElement(heroGroupNameField, UIManager.instance.DisplayHeroGroupUI,heroGroup);
        //image is temporary we will pull from assigned group


        VisualElement groupPictogram = ReturnPictogram("GroupPictogram");
        /*Image groupPictogramImage = (Image)groupPictogram.Q(name: "GroupPictogram");
        groupPictogram.style.display = DisplayStyle.None;*/
        heroGroupInListVisual.Add(groupPictogram);
        
        foreach(StatField statfield in _statFieldList)
        {
            if(statfield.isDisplayed ==false || statfield.name == GROUP_NAME){continue;}

            VisualElement element = ReturnTextWindow(statfield.containerClass, ReturnCorrectStatValue(heroGroup, statfield.name));
            element.name = statfield.name;
            heroGroupInListVisual.Add(element);
            //InitiateElement(element,UIManager.instance.OpenHeroUI,hero);//tho whole bar will open hero //example for later when want to open herogroup details
        }
    }

    private void AddStatFieldsToList()
    {
        _statFieldList.Add(_nameField);
        _statFieldList.Add(_averageLVL);
        _statFieldList.Add(_groupSize);
        _statFieldList.Add(_health);
        _statFieldList.Add(_defense);
        _statFieldList.Add(_energy);
    }
    private string ReturnCorrectStatValue(HeroGroup heroGroup, string statName)
    {
        switch(statName)
        {
            case GROUP_NAME: return heroGroup.ReturnHeroGroupName();
            case GROUP_GROUP_SIZE: return heroGroup.ReturnHeroGroupPartySize().ToString();
            case GROUP_HEALTH: return heroGroup.ReturnHeroGroupHealth().ToString();
            case GROUP_ATTACK: return heroGroup.ReturnHeroGroupDamage().ToString();
            case GROUP_DEFENSE: return heroGroup.ReturnHeroGroupDamage().ToString();
            case GROUP_ENERGY: return heroGroup.ReturnHeroGroupEnergy().ToString();
            default: return "UNKNOWN";
        }
        
    }
}
