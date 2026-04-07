using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;


public class HeroGroup_MiniPopUps : UI
{
    public Vector2 tempSpawnPosition =  new Vector2(400,400);
    public bool isUiOpen = false;
    [SerializeField] private UIDocument _miniPopUpsDocument;

    private VisualElement _rootElement;
    private VisualElement _heroGroupsElement;
    private VisualElement _header;
    private VisualElement _miniHeroGroups;
    public HeroList_UI heroList_UI;
    private int _verticalSize = 1080;


    private Vector2 _clickRelativeToAnchor;
    void OnEnable()
    {
        _rootElement = _miniPopUpsDocument.rootVisualElement;
        _heroGroupsElement = _rootElement.Q(name: "Hero-Groups");
        _header = _rootElement.Q(name: "Header");
        _miniHeroGroups = _rootElement.Q(name: "HeroGroupsList");//magic number

    }

    void Start()
    {
        MoveMiniHeroGroupsAt(tempSpawnPosition);
        SetHeader();
        CloseUI();
    } 
    void Update()
    {
        //MouseClickMove();
    }
    public override void DisplayUI()
    {
        //Debug.Log("heroListBtn");
        if(!isUiOpen)
        {
            //isUiOpen = true;
            OpenUI();
        }
        else
        {
            //isUiOpen = false;
            CloseUI();
        }
    }
    
    public override void OpenUI()
    {
        //Debug.Log("opening miniPopUps HerroGroup");

        DisplayHeroGroups();
        MoveMiniHeroGroupsAt(Mouse.current.position.ReadValue());
        //Button exitButton = (Button)topUI_BAR.Q(name = EXIT_BUTTON);
        //InitiateButton(exitButton,CloseUI);
        
        //ShowElement(_miniHeroGroups);
        ShowElement(_heroGroupsElement);
        
        isUiOpen = true;
    }

    public override void CloseUI()
    {
        _miniHeroGroups.Clear();
        //_header.Clear();
        //HideElement(_miniHeroGroups);
        HideElement(_heroGroupsElement);
        isUiOpen = false;
    }
    public override void SetHeader()
    {
        VisualElement topUI_BAR = ReturnTopUI_Bar(uiPanelName,CloseUI);
        _header.Add(topUI_BAR);
    }
    void MoveMiniHeroGroupsAt(Vector2 position)
    {
        _heroGroupsElement.style.top = _verticalSize-position.y;
        _heroGroupsElement.style.left = position.x;
        
    }
        void DisplayMiniHeroGroupsAtMouse()
    {
        Vector2 mouseClickPosition = Mouse.current.position.ReadValue();
        _heroGroupsElement.style.top = _verticalSize-mouseClickPosition.y;
        _heroGroupsElement.style.left = mouseClickPosition.x;
        
    }

    void MoveMiniHeroGroupsAtMouse()
    {
        float leftPosition = _heroGroupsElement.style.left.value.value;
        float topPosition = _heroGroupsElement.style.top.value.value;
        
        Vector2 oldAnchorPosition = new Vector2(leftPosition,topPosition);
        
        Vector2 mouseClickPosition = Mouse.current.position.ReadValue();
        Vector2 newAnchorPosition = mouseClickPosition -_clickRelativeToAnchor;

        _heroGroupsElement.style.top = _verticalSize-newAnchorPosition.y;
        _heroGroupsElement.style.left = newAnchorPosition.x;
        
    }
    void MouseClickMove()
    {
        if(Input.GetMouseButtonDown(0))
        {
            DisplayMiniHeroGroupsAtMouse();
        }
    }
    void DisplayHeroGroups()
    {
        foreach(HeroGroup heroGroup in HeroGroupManager.instance.heroGroupList)
        {
            //Button heroGroupBTN = ReturnButton(BASIC_TEXT_CONTAINER_120px,heroGroup.heroGroupName);
            Button heroGroupBTN = ReturnButton(BASIC_TEXT_CONTAINER_STRETCH,heroGroup.heroGroupName);
            _miniHeroGroups.Add(heroGroupBTN);
            
            //InitiateButton(heroGroupBTN,PrintSomething);
            InitiateButton(heroGroupBTN,MoveBulkHeroesToGroup,heroGroup);
        }
    }
    void MoveBulkHeroesToGroup(HeroGroup heroGroup)
    {
        foreach (Hero hero in heroList_UI.ReturnSelectedHeroes())
        {HeroManager.instance.MoveHeroToGroup(hero,heroGroup);}
        CloseUI();
    }

}
