using System;

using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HeroInList_UI : UI
{
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] Button _nameButton;
    [SerializeField] Button _checkMarkButton;
    [SerializeField] Image _checkMarkImage;
    [SerializeField] TextMeshProUGUI _level;
    [SerializeField] Image _typeImage;
    [SerializeField] TextMeshProUGUI _activity;
    [SerializeField] TextMeshProUGUI _health;
    [SerializeField] TextMeshProUGUI _attack;
    [SerializeField] TextMeshProUGUI _defense;
    [SerializeField] TextMeshProUGUI _energy;
    [SerializeField] TextMeshProUGUI _group;
    [SerializeField] TextMeshProUGUI _profSkill;
    [SerializeField] TextMeshProUGUI _status;

    public Unit hero;
    public UnitStats stats;
    private DisplayedHero_Tabs_UI _displayedHeroTabs_UI;
    private DisplayedHero_UI _displayedHero_UI;

    private Color32 _checkMarkUnpressedColor = new Color32(0,118,0,0);
    private Color32 _checkMarkPressedColor = new Color32(0, 118, 0, 255);
    public bool checkMarkPressedBool = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetValuesFromStatsDirectly();

        InitiateButton(_nameButton, OpenHeroUI,hero);
        InitiateButton(_checkMarkButton,CheckMarkButton);
    }

    // Update is called once per frame
    void Update()
    {
        SetValuesFromStatsDirectly();
    }

    public void SetHeroUI_Reference(DisplayedHero_Tabs_UI displayedHero_Tabs_UI, DisplayedHero_UI displayedHero_UI)
    {
        _displayedHeroTabs_UI = displayedHero_Tabs_UI;
        _displayedHero_UI = displayedHero_UI;
    }
    private void SetValues()
    {
        var heroStats = hero.stats;
        SetButtonTextValue(_name, heroStats.unit.unitName);
        SetButtonTextValue(_health, heroStats.health);
        SetButtonTextValue(_attack, heroStats.attack);
        SetButtonTextValue(_defense, heroStats.defense);
        SetButtonTextValue(_energy, heroStats.energy);

    }
    private void SetValuesFromStatsDirectly()
    {
        
        SetButtonTextValue(_name, stats.unit.unitName);
        SetButtonTextValue(_health, stats.health);
        SetButtonTextValue(_attack, stats.attack);
        SetButtonTextValue(_defense, stats.defense);
        SetButtonTextValue(_energy, stats.energy);
        SetButtonTextValue(_group, ((Hero)hero).heroGroupImInName);
    }
    private void OpenHeroUI(Unit hero)
    {
        _displayedHero_UI.gameObject.SetActive(true);
        _displayedHeroTabs_UI.displayedHero = (Hero)hero;
    }
    public void CheckMarkButton()
    {
        if (checkMarkPressedBool)
        {
            checkMarkPressedBool = false;
            _checkMarkImage.color=_checkMarkUnpressedColor;
        }
        else 
        {
            checkMarkPressedBool= true;
            _checkMarkImage.color = _checkMarkPressedColor;
        }
    }
}
