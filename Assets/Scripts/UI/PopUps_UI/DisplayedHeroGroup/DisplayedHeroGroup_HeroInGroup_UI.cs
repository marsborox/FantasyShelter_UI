using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayedHeroGroup_HeroInGroup_UI : UI
{
    [SerializeField] TextMeshProUGUI _heroName;
    [SerializeField] TextMeshProUGUI _heroRole;
    [SerializeField] TextMeshProUGUI _heroLvl;
    [SerializeField] TextMeshProUGUI _heroHealth;
    [SerializeField] TextMeshProUGUI _heroAttack;
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

        _heroHealth.text = hero.ReturnHealth().ToString();
        _heroAttack.text = hero.ReturnAttack().ToString();
        _heroDefense.text = hero.ReturnDefense().ToString();
        _heroEnergy.text = hero.ReturnEnergy().ToString();

    }
    private void KickHero()
    { 
        heroManager.MoveHeroToBaseGroup(hero);
        heroGroupUI_Heroes.DisplayHeroesInList();
    }

}
