using TMPro;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class HeroInList_UI : UI
{
    [SerializeField] TextMeshProUGUI _name;
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

    public Hero hero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetValues()
    {
        var heroStats = hero.stats;
        SetValue(_name, heroStats.name);
        SetValue(_health, heroStats.health);
        SetValue(_attack, heroStats.attack);
        SetValue(_defense, heroStats.defense);
        SetValue(_energy, heroStats.energy);

        
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
