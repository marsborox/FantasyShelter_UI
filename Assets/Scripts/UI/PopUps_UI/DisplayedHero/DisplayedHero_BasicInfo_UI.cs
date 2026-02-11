using TMPro;
using UnityEngine;

public class DisplayedHero_BasicInfo_UI : MonoBehaviour
{
    //hero image - needs implementation
    [SerializeField] private DisplayedHero_Tabs_UI _displayedHeroUI;
    [SerializeField] private TextMeshProUGUI _heroName;
    [SerializeField] private TextMeshProUGUI _levelValue;
    [SerializeField] private TextMeshProUGUI _experienceValues;
    //experience bar image - needs implementation
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private TextMeshProUGUI _damage;
    [SerializeField] private TextMeshProUGUI _defense;
    [SerializeField] private TextMeshProUGUI _energy;

    private void Update()
    {
        SetStats();
    }
    public void SetStats()
    {
        HeroStats heroStatsToDisplay = (HeroStats)_displayedHeroUI.displayedHero.stats;

        _heroName.text = heroStatsToDisplay.unit.unitName;
        //levelValue
        //exp values
        _health.text = _displayedHeroUI.displayedHero.ReturnHealthCurrent().ToString();
        _damage.text = _displayedHeroUI.displayedHero.ReturnDamageCurrent().ToString();
        _defense.text = _displayedHeroUI.displayedHero.ReturnDefenseCurrent().ToString();
        _energy.text = _displayedHeroUI.displayedHero.ReturnEnergyCurrent().ToString();
    }
}
