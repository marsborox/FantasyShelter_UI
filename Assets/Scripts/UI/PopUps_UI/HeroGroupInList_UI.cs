using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class HeroGroupInList_UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _groupName;
    [SerializeField] Image pictogram;
    [SerializeField] TextMeshProUGUI _avgLVL;
    [SerializeField] TextMeshProUGUI _heroCount;
    [SerializeField] TextMeshProUGUI _health;
    [SerializeField] TextMeshProUGUI _attack;
    [SerializeField] TextMeshProUGUI _defense;
    [SerializeField] TextMeshProUGUI _energy;

    public HeroGroup heroGroup;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    private void SetValue(TextMeshProUGUI fieldToFill, string text)
    {
        fieldToFill.text = text;
    }
    private void SetValue(TextMeshProUGUI fieldToFill, int text)
    {
        fieldToFill.text = text.ToString();
    }
    private void SetValue(TextMeshProUGUI fieldToFill, Hero hero)
    {

        /*fieldToFill.text;*/  /*text.ToString();*/
    }
}
