using UnityEngine;
using UnityEngine.UI;

public class DisplayedHeroGroup_UI : UI
{
    public HeroGroup displayedHeroGroup;
    [SerializeField] Button _closeButton;

    private void Start()
    {
        InitiateButton(_closeButton, CloseThisTab, _closeButton);
    }
}
