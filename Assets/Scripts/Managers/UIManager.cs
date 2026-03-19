using Unity.VisualScripting;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public static new UIManager instance => Singleton<UIManager>.instance;
    public GameObject heroGroupUI;
    public GameObject heroGroupsUI;
    public TopPanel_UI_Old topPanel_UI_Old;
    public DisplayedHero_UI displayedHero_UI;
    [SerializeField] private HeroList_UI _herolist_UI;
    public Stash_UI stash_UI;
    //set color of button
    protected override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        GlobalEventHandler.instance.OnStashChanged += RefreshStashUI;
    }
    private void OnDisable()
    {
        GlobalEventHandler.instance.OnStashChanged -= RefreshStashUI;
    }
    public void RefreshGroupsUI()
    {
        topPanel_UI_Old.RefreshGroupList();
    }
    public void RefreshStashUI()
    {
        if (stash_UI.gameObject.activeSelf)
        {
            Debug.Log("refreshing UI");
            topPanel_UI_Old.RefershStashUI();
        }
    }
    public void OpenHeroList()
    {
        _herolist_UI.DisplayUI();
    }
    public void RefreshHeroList()
    {
        if(_herolist_UI.isUiOpen)
        {
            _herolist_UI.CloseUI();
            _herolist_UI.OpenUI();
        }
    }
    public void OpenHeroUI()
    {
        
    }
    public void OpenHeroUI(Unit hero)
    {
        displayedHero_UI.displayedHero = (Hero)hero;
        displayedHero_UI.gameObject.SetActive(true);
    }        
}
