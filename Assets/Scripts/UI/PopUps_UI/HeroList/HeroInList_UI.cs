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

        //InitiateButton(_nameButton, OpenHeroUI,hero);//remove
        InitiateButton(_nameButton, UIManager.instance.OpenHeroUI,hero);
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
        SetTextValue(_name, heroStats.unit.unitName);
        SetTextValue(_health, heroStats.health);
        SetTextValue(_damage, heroStats.damage);
        SetTextValue(_defense, heroStats.defense);
        SetTextValue(_energy, heroStats.energy);

    }
    private void SetValuesFromStatsDirectly()
    {
        SetTextValue(_name, hero.ReturnName());
        SetTextValue(_health, ((Hero)hero).ReturnHealthCurrent());
        SetTextValue(_damage, ((Hero)hero).ReturnDamageCurrent());
        SetTextValue(_defense, ((Hero)hero).ReturnDefenseCurrent());
        SetTextValue(_energy, ((Hero)hero).ReturnEnergyCurrent());
        SetTextValue(_group, ((Hero)hero).heroGroupImInName);
    }
    private void OpenHeroUI(Unit hero)
    {// delete this
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
