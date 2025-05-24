using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DisplayedHero_Actions_MiniHeroGroup_BUTTON : UI
{
    public Button button;
    [SerializeField] TextMeshProUGUI _buttonText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void SetButtonText(string text)
    { 
        _buttonText.text = text;
    }
}
