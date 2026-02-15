using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public static new UIManager instance => Singleton<UIManager>.instance;
    public GameObject heroGroupUI;
    public GameObject heroGroupsUI;
    public TopPanel_UI topPanel_UI;
    public DisplayedHero_UI displayedHero_UI;
    //set color of button
    protected override void Awake()
    {
        base.Awake();
    }

        public void RefreshGroupsUI()
    {
        topPanel_UI.RefreshGroupList();
    }
}
