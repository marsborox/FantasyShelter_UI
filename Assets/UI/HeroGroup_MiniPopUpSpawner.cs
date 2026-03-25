using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class HeroGroup_MiniPopUpSpawner : UI
{
    public Vector2 tempSpawnPosition =  new Vector2(400,400);
    public bool isUiOpen = false;
    [SerializeField] private UIDocument _miniPopUpsDocument;

    private VisualElement _rootElement;
    private VisualElement _miniHeroGroups;
    public HeroList_UI heroList_UI;
    private int _verticalSize = 1080;


    private Vector2 _clickRelativeToAnchor;
    void OnEnable()
    {
        _rootElement = _miniPopUpsDocument.rootVisualElement;
        _miniHeroGroups = _rootElement.Q(name: "HeroGroups");
    }

    void Start()
    {
        MoveMiniHeroGroupsAt(tempSpawnPosition);
    } 
    void Update()
    {
        //MouseClickMove();
    }
    public void DisplayUI()
    {
                //Debug.Log("heroListBtn");
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
        Debug.Log("opening miniPopUps HerroGroup");
        VisualElement topUI_BAR = ReturnTopUI_Bar(uiPanelName,CloseUI);

        _miniHeroGroups.Add(topUI_BAR);
        DisplayHeroGroups();
        MoveMiniHeroGroupsAt(Mouse.current.position.ReadValue());
        Button exitButton = (Button)topUI_BAR.Q(name = EXIT_BUTTON);
        //InitiateButton(exitButton,CloseUI);

        ShowElement(_miniHeroGroups);
    }

    public void CloseUI()
    {
        _miniHeroGroups.Clear();
        HideElement(_miniHeroGroups);

    }
    void MoveMiniHeroGroupsAt(Vector2 position)
    {
        _miniHeroGroups.style.top = (_verticalSize-position.y);
        _miniHeroGroups.style.left = position.x;
        
    }
        void DisplayMiniHeroGroupsAtMouse()
    {
        Vector2 mouseClickPosition = Mouse.current.position.ReadValue();
        _miniHeroGroups.style.top = _verticalSize-mouseClickPosition.y;
        _miniHeroGroups.style.left = mouseClickPosition.x;
        
    }

    void MoveMiniHeroGroupsAtMouse()
    {
        float leftPosition = _miniHeroGroups.style.left.value.value;
        float topPosition = _miniHeroGroups.style.top.value.value;
        
        Vector2 oldAnchorPosition = new Vector2(leftPosition,topPosition);
        
        Vector2 mouseClickPosition = Mouse.current.position.ReadValue();
        Vector2 newAnchorPosition = mouseClickPosition -_clickRelativeToAnchor;

        _miniHeroGroups.style.top = _verticalSize-newAnchorPosition.y;
        _miniHeroGroups.style.left = newAnchorPosition.x;
        
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
            Button heroGroupBTN = ReturnButton(BASIC_TEXT_CONTAINER_120px,heroGroup.heroGroupName);
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
    void PrintSomething()
    {
        Debug.Log("some group btn pressed");
    }
}
