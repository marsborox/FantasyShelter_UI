using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject heroGroupUI;
    public GameObject heroGroupsUI;
    public TopPanel_UI topPanel_UI;
    //set color of button

    public void RefreshGroupsUI()
    {
        topPanel_UI.RefreshGroupList();
    }
}
