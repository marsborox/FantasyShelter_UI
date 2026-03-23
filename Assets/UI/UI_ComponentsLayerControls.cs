using UnityEngine;
using UnityEngine.UIElements;

public class UI_ComponentsLayerControls : MonoBehaviour
{
    [SerializeField]private UIDocument _rootUIDocument;
    [SerializeField] private UIDocument _miniPopUpsDocument;

    void Start()
    {
        _rootUIDocument.sortingOrder=0;
        _miniPopUpsDocument.sortingOrder = 100;
    }
}
