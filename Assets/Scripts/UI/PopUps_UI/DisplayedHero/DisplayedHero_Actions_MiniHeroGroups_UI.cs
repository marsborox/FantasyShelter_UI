using UnityEngine;
using UnityEngine.UI;

public class DisplayedHero_Actions_MiniHeroGroups_UI : UI
{
    [SerializeField] Button _closeButton;
    [SerializeField] Button _groupButton;

    private void Start()
    {
        //InitiateButton(_closeButton,Close);
        InitiateButton(_closeButton,CloseThisTab,_closeButton);

    }
    public void Close()
    { 
        ResetButtonColor(_groupButton);
        gameObject.SetActive(false);
    }
}
