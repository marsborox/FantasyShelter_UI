using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeroList_UI : UI
{
    [SerializeField]private UIDocument _uiDocument;
    private VisualElement _rootElement;
    private VisualElement _displayedHeroes;

    private List<VisualElement> _heroListVisual = new List<VisualElement>();
    private bool isUiOpen = false;
    void Awake()
    {
        _rootElement = _uiDocument.rootVisualElement;
        _displayedHeroes = _rootElement.Q(name: "DisplayedHeroes");
    }
    void OnEnable()
    {}
    public void DisplayUI()
    {
        if(!isUiOpen)
        {
            isUiOpen = true;
            OpenUI();
        }
        else
        {
            isUiOpen = false;
            CloseUI();
        }
    }

    private void OpenUI()
    {
        Debug.Log("opening UI");
        foreach (Hero hero in HeroManager.instance.heroList)
        {
            DisplayOneHeroInList(hero);
        }
    }

    public void DisplayOneHeroInList(Hero hero)
    {
        VisualElement heroInList = new VisualElement();
        _heroListVisual.Add(heroInList);
        heroInList.AddToClassList("heroes-bar");
        //name
        VisualElement heroNameField = new VisualElement();
        heroInList.Add(heroNameField);
        heroNameField.AddToClassList("basic-text-container-large");
        Label heroNameText = new Label();
        heroNameField.Add(heroNameText);
        heroNameText.AddToClassList("basic-text-text");
        heroNameText.text = hero.ReturnName();
        //level
        VisualElement heroLevelField = new VisualElement();
        heroInList.Add(heroLevelField);
        heroLevelField.AddToClassList("basic-text-container-small");
        Label heroLevelText = new Label();
        heroLevelField.Add(heroLevelText);
        heroLevelText.AddToClassList("basic-text-text");
        heroLevelText.text = "LVL";//fix later
        //Activity
        VisualElement heroActivityField = new VisualElement();
        heroInList.Add(heroActivityField);
        heroActivityField.AddToClassList("basic-text-container-medium");
        Label heroActivityText = new Label();
        heroActivityField.Add(heroActivityText);
        heroActivityText.AddToClassList("basic-text-text");
        heroActivityText.text = "Activity";//fix later
        //Health
        VisualElement heroHealthField = new VisualElement();
        heroInList.Add(heroHealthField);
        heroHealthField.AddToClassList("basic-text-container-small");
        Label heroHealthText = new Label();
        heroHealthField.Add(heroHealthText);
        heroHealthText.AddToClassList("basic-text-text");
        heroHealthText.text = hero.ReturnHealthCurrent().ToString();//fix later



        _displayedHeroes.Add(heroInList);
    }
    

    public void CloseUI()
    {
        Debug.Log("closing UI");
        /*foreach(VisualElement element in _heroListVisual)
        
        {
           element.RemoveFromHierarchy();
           
        }
        _heroListVisual.Clear();*/
        _displayedHeroes.Clear();
    }
}
