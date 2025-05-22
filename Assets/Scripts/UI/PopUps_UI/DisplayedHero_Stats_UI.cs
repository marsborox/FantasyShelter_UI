using UnityEngine;
using TMPro;

public class DisplayedHero_Stats_UI : UI
{
    [SerializeField] DisplayedHero_UI _displayedHeroUI;

    [SerializeField] DisplayedHero_Stat_UI _health;
    [SerializeField] DisplayedHero_Stat_UI _attack;
    [SerializeField] DisplayedHero_Stat_UI _defense;
    [SerializeField] DisplayedHero_Stat_UI _energy;

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

        SetBaseStatValue(_health.statBase,heroStatsToDisplay.healthBase);
        SetBaseStatValue(_health.statCurrent, heroStatsToDisplay.health);

        SetBaseStatValue(_attack.statBase,heroStatsToDisplay.attackBase);
        SetBaseStatValue(_attack.statCurrent, heroStatsToDisplay.attack);


        SetBaseStatValue(_defense.statBase,heroStatsToDisplay.defenseBase);
        SetBaseStatValue(_defense.statCurrent, heroStatsToDisplay.defense);

        SetBaseStatValue(_energy.statBase,heroStatsToDisplay.energyBase);
        SetBaseStatValue(_energy.statCurrent, heroStatsToDisplay.energy);


    }
    void SetBaseStatValue(TextMeshProUGUI heroStatPanel, int valueToDisplay)
    {
        heroStatPanel.text = valueToDisplay.ToString();
    }
}
