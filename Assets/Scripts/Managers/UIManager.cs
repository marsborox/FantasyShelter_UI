using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject heroGroupUI;
    public GameObject heroGroupsUI;
    public void GroupDisband()
    {
        if (heroGroupUI.activeSelf) { heroGroupsUI.SetActive(false); }
        if (heroGroupsUI.activeSelf) 
        { 
            heroGroupsUI.SetActive(false);
            heroGroupsUI.SetActive(true);
        }
    }
}
