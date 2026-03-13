using UnityEngine;
using UnityEngine.UI;

public class DisplayedHeroGroup_UI : UI_Old
{
    public HeroGroup displayedHeroGroup;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _disbandButton;
    [SerializeField] private UIManager _uiManager;


    private void Start()
    {
        InitiateButton(_closeButton, CloseTab, this);
    }
    private void OnEnable()
    {
        InitiateButton(_disbandButton, displayedHeroGroup.DisbandHeroGroup);
        InitiateButton(_disbandButton, _uiManager.RefreshGroupsUI);
        InitiateButton(_disbandButton,CloseTab, this);
    }
    private void OnDisable()
    {
        RemoveListeners(_disbandButton);
    }
}
