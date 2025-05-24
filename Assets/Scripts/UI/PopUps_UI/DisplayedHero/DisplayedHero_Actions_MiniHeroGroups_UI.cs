using UnityEngine;
using UnityEngine.UI;

public class DisplayedHero_Actions_MiniHeroGroups_UI : UI
{
    [SerializeField] Button _closeButton;
    [SerializeField] Button _groupButton;

    private void Start()
    {
        InitiateButton(_closeButton,Close);

    }
    public void Close()
    { 
        gameObject.SetActive(false);
        ResetButtonColor(_groupButton);
    }
}
