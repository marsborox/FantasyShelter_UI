using UnityEngine;
using UnityEngine.UI;

public class DisplayedHero_TopBar_UI : UI
{

    [SerializeField] Button _closeButton;
    [SerializeField] UI _displayedHero_UI;



    private void Start()
    {
        //InitiateButtonUIPanel(_closeButton,_displayedHero_UI);
        InitiateButton(_closeButton,CloseTab,_displayedHero_UI);
    }
    void CloseThisMenu()
    { 
        _displayedHero_UI.gameObject.active=false;
    }
}
