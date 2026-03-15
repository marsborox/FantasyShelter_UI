using System;

using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HeroInList_UI : UI_Old
{
    
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] Button _nameButton;
    [SerializeField] Button _checkMarkButton;
    [SerializeField] Image _checkMarkImage;
    [SerializeField] TextMeshProUGUI _level;
    [SerializeField] Image _typeImage;
    [SerializeField] TextMeshProUGUI _activity;
    [SerializeField] TextMeshProUGUI _health;
    [SerializeField] TextMeshProUGUI _damage;
    [SerializeField] TextMeshProUGUI _defense;
    [SerializeField] TextMeshProUGUI _energy;
    [SerializeField] TextMeshProUGUI _group;
    [SerializeField] TextMeshProUGUI _profSkill;
    [SerializeField] TextMeshProUGUI _status;

    public Unit hero;
    public UnitStats stats;
    
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

    public void SetHeroUI_Reference(DisplayedHero_UI displayedHero_UI)
    {
        _displayedHero_UI = displayedHero_UI;
    }
    private void SetValues()
    {//used on NPC apparently
        var heroStats = hero.stats;
        SetButtonTextValue(_name, heroStats.unit.unitName);
        SetButtonTextValue(_health, heroStats.health);
        SetButtonTextValue(_damage, heroStats.damage);
        SetButtonTextValue(_defense, heroStats.defense);
        SetButtonTextValue(_energy, heroStats.energy);

    }
    private void SetValuesFromStatsDirectly()
    {

        SetButtonTextValue(_name, hero.ReturnName());
        SetButtonTextValue(_health, ((Hero)hero).ReturnHealthCurrent());
        SetButtonTextValue(_damage, ((Hero)hero).ReturnDamageCurrent());
        SetButtonTextValue(_defense, ((Hero)hero).ReturnDefenseCurrent());
        SetButtonTextValue(_energy, ((Hero)hero).ReturnEnergyCurrent());
        SetButtonTextValue(_group, ((Hero)hero).heroGroupImInName);
    }
    private void OpenHeroUI(Unit hero)
    {
        _displayedHero_UI.gameObject.SetActive(true);
        _displayedHero_UI.displayedHero = (Hero)hero;
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
