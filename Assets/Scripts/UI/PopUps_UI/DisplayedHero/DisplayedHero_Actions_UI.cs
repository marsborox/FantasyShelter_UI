using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.ComponentModel.Design;
public class DisplayedHero_Actions_UI : UI
{
    [SerializeField] DisplayedHero_Tabs_UI _displayedHero_UI;

    [SerializeField] Button _groupButton;
    [SerializeField] TextMeshProUGUI _groupButtonText;

    [SerializeField] TextMeshProUGUI _professionText;
    [SerializeField] Button _professionButton;
    [SerializeField] TextMeshProUGUI _professionButtonText;
    [SerializeField] DisplayedHero_Actions_MiniHeroGroups_UI _heroGroupsMini_UI;

    private void Start()
    {
        base.Start();
        InitateButtons();
    }
    private void OnEnable()
    {
        
    }
    private void Update()
    {
        SetHeroActionProperties();   
    }
    public void SetHeroActionProperties()
    {
        SetGroupName();
    }

    public void SetGroupName()
    { 
        _groupButtonText.text=_displayedHero_UI.displayedHero.heroGroupImInName;
    }
    void InitateButtons()
    {
        InitiateButtonUIPanel(_groupButton, _heroGroupsMini_UI);
    }
}
