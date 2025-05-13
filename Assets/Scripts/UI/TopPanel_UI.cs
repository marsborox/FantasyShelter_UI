using System;

using UnityEngine;
using UnityEngine.UI;

public class TopPanel_UI : UI
{
    [Header("TopButtons")] 
    [SerializeField] private Button _HeroesButton;
    [SerializeField] private GameObject _HeroesUI;
    [SerializeField] private Button _GroupsButton;
    [SerializeField] private GameObject _GroupsUI;
    [SerializeField] private Button _BaseButton;
    [SerializeField] private GameObject _BaseUI;
    [SerializeField] private Button _StashButton;
    [SerializeField] private GameObject _StashUI;
    [SerializeField] private Button _MapButton;
    [SerializeField] private GameObject _MapUI;

    void Start()
    {
        InitiateButtons();
    }
    public void InitiateButtons()
    {
        InitiateButtonUIPanel(_HeroesButton, _HeroesUI);
        InitiateButtonUIPanel(_GroupsButton,_GroupsUI);
        InitiateButtonUIPanel(_BaseButton, _BaseUI);
        InitiateButtonUIPanel(_StashButton, _StashUI);
        InitiateButtonUIPanel(_MapButton, _MapUI);
    }
}
