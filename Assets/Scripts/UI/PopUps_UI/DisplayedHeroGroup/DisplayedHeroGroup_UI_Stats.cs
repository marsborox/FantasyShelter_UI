using TMPro;

using UnityEngine;

public class DisplayedHeroGroup_UI_Stats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _Health;
    [SerializeField] TextMeshProUGUI _Attack;
    [SerializeField] TextMeshProUGUI _Defense;
    [SerializeField] TextMeshProUGUI _Energy;

    [SerializeField] DisplayedHeroGroup_UI _DisplayedHeroGroup_UI;
    private void Update()
    {
        SetValues();
    }
    public void SetValues()
    { 
        _Health.text = _DisplayedHeroGroup_UI.displayedHeroGroup.heroGroupHealth.ToString();
        _Attack.text = _DisplayedHeroGroup_UI.displayedHeroGroup.heroGroupAttack.ToString();
        _Defense.text = _DisplayedHeroGroup_UI.displayedHeroGroup.heroGroupDefense.ToString();
        _Energy.text = _DisplayedHeroGroup_UI.displayedHeroGroup.heroGroupEnergy.ToString();
    }
}
