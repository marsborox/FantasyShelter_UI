using System;

using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class HeroInList_UI : UI
{
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] Button _nameButton;
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
    private DisplayedHero_UI _displayedHeroUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetValuesFromStatsDirectly();

        InitiateButton(_nameButton, OpenHeroUI,hero);
    }

    // Update is called once per frame
    void Update()
    {
        SetValuesFromStatsDirectly();
    }

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
    }
    public void SetHeroUI_Reference(DisplayedHero_UI displayedHero_UI)
    {
        _displayedHeroUI = displayedHero_UI;
    }
    void OpenHeroUI(Unit hero)
    {
        _displayedHeroUI.gameObject.active = true;
        _displayedHeroUI.displayedHero = (Hero)hero;
    }
}
