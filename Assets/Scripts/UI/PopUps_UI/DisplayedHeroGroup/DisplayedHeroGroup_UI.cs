using UnityEngine;
using UnityEngine.UI;

public class DisplayedHeroGroup_UI : UI
{
    public HeroGroup displayedHeroGroup;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _disbandButton;



    private void Start()
    {
        InitiateButton(_closeButton, CloseTab, this);
        InitiateButton(_disbandButton, displayedHeroGroup.DisbandHeroGroup);
    }
}
