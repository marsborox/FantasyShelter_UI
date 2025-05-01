using System;

using UnityEngine;
using UnityEngine.UI;

public class TopPanel_UI : UI
{
    [Header("TopButtons")] 
    [SerializeField] Button HeroesButton;
    [SerializeField] GameObject HeroesUI;
    [SerializeField] Button GroupsButton;
    [SerializeField] GameObject GroupsUI;
    [SerializeField] Button BaseButton;
    [SerializeField] GameObject BaseUI;
    [SerializeField] Button StashButton;
    [SerializeField] GameObject StashUI;
    [SerializeField] Button MapButton;
    [SerializeField] GameObject MapUI;

    void Start()
    {
        InitiateButtons();
    }
    public void InitiateButtons()
    {
        InitiateButtonUIPanel(HeroesButton, HeroesUI);
        InitiateButtonUIPanel(GroupsButton,GroupsUI);
        InitiateButtonUIPanel(BaseButton, BaseUI);
        InitiateButtonUIPanel(StashButton, StashUI);
        InitiateButtonUIPanel(MapButton, MapUI);
    }
}
