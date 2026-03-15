using TMPro;
using UnityEngine;

using static UnitStats;

public class DisplayedHero_Stats_UI : UI_Old
{
    [SerializeField] private DisplayedHero_UI _displayedHeroUI;

    [SerializeField] private DisplayedHero_Stat_UI _health;
    [SerializeField] private DisplayedHero_Stat_UI _damage;
    [SerializeField] private DisplayedHero_Stat_UI _defense;
    [SerializeField] private DisplayedHero_Stat_UI _attackSpeed;
    [SerializeField] private DisplayedHero_Stat_UI _movementSpeed;
    [SerializeField] private DisplayedHero_Stat_UI _energy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetStats();
    }

    void SetStats()
    {
        HeroStats heroStatsToDisplay = (HeroStats)_displayedHeroUI.displayedHero.stats;

        /*SetBaseStatValue(_health.statBase,heroStatsToDisplay.healthBase);
        SetBaseStatValue(_health.statCurrent, heroStatsToDisplay.health);

        SetBaseStatValue(_damage.statBase,heroStatsToDisplay.damagekBase);
        SetBaseStatValue(_damage.statCurrent, heroStatsToDisplay.damage);


        SetBaseStatValue(_defense.statBase,heroStatsToDisplay.defenseBase);
        SetBaseStatValue(_defense.statCurrent, heroStatsToDisplay.defense);

        SetBaseStatValue(_energy.statBase,heroStatsToDisplay.energyBase);
        SetBaseStatValue(_energy.statCurrent, heroStatsToDisplay.energy);*/

        DisplayStatValue(_health, heroStatsToDisplay.healthStat);
        DisplayStatValue(_damage, heroStatsToDisplay.damageStat);
        DisplayStatValue(_defense, heroStatsToDisplay.defenseStat);
        DisplayStatValue(_attackSpeed, heroStatsToDisplay.attackSpeedStat);
        DisplayStatValue(_movementSpeed, heroStatsToDisplay.movementSpeedStat);
        DisplayStatValue(_energy, heroStatsToDisplay.energyStat);

    }
    void SetBaseStatValue(TextMeshProUGUI heroStatPanel, int valueToDisplay)
    {
        heroStatPanel.text = valueToDisplay.ToString();
    }
    private void DisplayStatValue(DisplayedHero_Stat_UI displayedHeroStat, UnitStat unitStat)
    {
        displayedHeroStat.statBase.text = unitStat.valueBase.ToString();
        displayedHeroStat.statTotal.text = unitStat.valueTotal.ToString();
        displayedHeroStat.statItems.text = unitStat.valueItems.ToString();
        displayedHeroStat.statCurrent.text = unitStat.valueCurrent.ToString();

    }
}
