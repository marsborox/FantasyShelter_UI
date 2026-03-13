using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayedHeroGroup_HeroInGroup_UI : UI_Old
{
    [SerializeField] TextMeshProUGUI _heroName;
    [SerializeField] TextMeshProUGUI _heroRole;
    [SerializeField] TextMeshProUGUI _heroLvl;
    [SerializeField] TextMeshProUGUI _heroHealth;
    [SerializeField] TextMeshProUGUI _heroDamage;
    [SerializeField] TextMeshProUGUI _heroDefense;
    [SerializeField] TextMeshProUGUI _heroEnergy;

    [SerializeField] Button _kickHeroButton;

    public DisplayedHeroGroup_UI_Heroes heroGroupUI_Heroes;
    public Hero hero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitiateButton(_kickHeroButton, KickHero);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayValues();
    }
    private void DisplayValues()
    { 
        _heroName.text = hero.unitName;

        _heroHealth.text = hero.ReturnHealthCurrent().ToString();
        _heroDamage.text = hero.ReturnDamageCurrent().ToString();
        _heroDefense.text = hero.ReturnDefenseCurrent().ToString();
        _heroEnergy.text = hero.ReturnEnergyCurrent().ToString();

    }
    private void KickHero()
    { 
        heroManager.MoveHeroToBaseGroup(hero);
        heroGroupUI_Heroes.DisplayHeroesInList();
    }

}
