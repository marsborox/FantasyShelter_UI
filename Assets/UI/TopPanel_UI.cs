using UnityEngine;
using UnityEngine.UIElements;
public class TopPanel_UI : UI
{
    [SerializeField] private UIDocument _uiDoc;
    private VisualElement _rootElement;
    private VisualElement _topPanel;
    private Button _heroesButton;
    private Button _groupsButton;
    private Button _baseButton;
    private Button _stashButton;
    private Button _mapButton;


    void OnEnable()
    {
        _rootElement = _uiDoc.rootVisualElement;
        SetUpTopPanelButtons();
        InitiateButtons();
    }
    void SetUpTopPanelButtons()
    {
        _topPanel = _rootElement.Q(className: "top-panel");
        
        _heroesButton = _topPanel.Q<Button>(name: "HeroesButton");
        _groupsButton = _topPanel.Q<Button>(name: "GroupsButton");
        _baseButton = _topPanel.Q<Button>(name: "BaseButton");
        _stashButton = _topPanel.Q<Button>(name: "StashButton");
        _mapButton = _topPanel.Q<Button>(name: "MapButton");
    }

    #region OldUI_Stuff

    [SerializeField] private GameObject _heroesUI;
    [SerializeField] private GameObject _groupsUI;
    [SerializeField] private GameObject _baseUI;
    [SerializeField] private GameObject _stashUI;
    [SerializeField] private GameObject _mapUI;

    void InitiateButtons()
    {
        //OldUI
        
        InitiateButtonUIPanel(_heroesButton, _heroesUI);
        InitiateButtonUIPanel(_groupsButton, _groupsUI);
        InitiateButtonUIPanel(_baseButton, _baseUI);
        InitiateButtonUIPanel(_stashButton, _stashUI);
        //InitiateButtonUIPanel(_mapButton, _mapUI);
        InitiateButton(_mapButton, TestPrint);
    }
    #endregion

    void TestPrint()
    {
        Debug.Log("test print");
    }
}
