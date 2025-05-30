using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class HeroGroupInList_UI : UI
{

    [SerializeField] TextMeshProUGUI _groupName;
    [SerializeField] Button _nameButton;
    [SerializeField] Image pictogram;
    [SerializeField] TextMeshProUGUI _avgLVL;
    [SerializeField] TextMeshProUGUI _heroCount;
    [SerializeField] TextMeshProUGUI _health;
    [SerializeField] TextMeshProUGUI _attack;
    [SerializeField] TextMeshProUGUI _defense;
    [SerializeField] TextMeshProUGUI _energy;


    public HeroGroup heroGroup;

    private DisplayedHeroGroup_UI _displayedHeroGroup_UI;
    void Start()
    {
        InitiateButton(_nameButton, OpenHeroGroupUI, heroGroup);
    }

    // Update is called once per frame
    void Update()
    {
        SetValues();
    }

    public void SetValues()
    {
        SetButtonTextValue(_groupName, heroGroup.heroGroupName);
        SetButtonTextValue(_heroCount, heroGroup.heroList.Count);
        SetButtonTextValue(_health, heroGroup.heroGroupHealth);
        SetButtonTextValue(_attack, heroGroup.heroGroupAttack);
        SetButtonTextValue(_defense, heroGroup.heroGroupDefense);
        SetButtonTextValue(_energy, heroGroup.heroGroupEnergy);
    }
    /*
    private void SetValues()
    {
        var heroStats = hero.stats;
        SetValue(_name, heroStats.name);
        SetValue(_health, heroStats.health);
        SetValue(_attack, heroStats.attack);
        SetValue(_defense, heroStats.defense);
        SetValue(_energy, heroStats.energy);
    }
    private void SetValuesFromStatsDirectly()
    {

        SetValue(_name, stats.name);
        SetValue(_health, stats.health);
        SetValue(_attack, stats.attack);
        SetValue(_defense, stats.defense);
        SetValue(_energy, stats.energy);
    }*/
    public void SetGroupUI_Reference(DisplayedHeroGroup_UI displayedHeroGroup_UI)
    {
        _displayedHeroGroup_UI = displayedHeroGroup_UI;
    }
    void OpenHeroGroupUI(HeroGroup heroGroup)
    {
        _displayedHeroGroup_UI.displayedHeroGroup = heroGroup;
        _displayedHeroGroup_UI.gameObject.SetActive(true);
    }
   
}
