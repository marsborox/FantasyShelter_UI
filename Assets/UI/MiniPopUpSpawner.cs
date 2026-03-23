using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class MiniPopUpSpawner : MonoBehaviour
{
    public Vector2 tempSpawnPosition =  new Vector2(400,400);
    [SerializeField] private UIDocument _miniPopUpsDocument;

    private VisualElement _rootElement;
    private VisualElement _miniHeroGroups;
    private int _verticalSize = 1080;

    void OnEnable()
    {
        _rootElement = _miniPopUpsDocument.rootVisualElement;
        _miniHeroGroups = _rootElement.Q(name: "HeroGroups");
    }

    void Start()
    {
        DisplayMiniHeroGroupsAt(tempSpawnPosition);
    } 
    void Update()
    {
        MouseClickMove();
    }
    void DisplayMiniHeroGroupsAt(Vector2 position)
    {
        _miniHeroGroups.style.top = (_verticalSize-position.y);
        _miniHeroGroups.style.left = position.x;
        
    }
        void DisplayMiniHeroGroupsAtMouse()
    {
        Vector2 mouseClickPosition = Mouse.current.position.ReadValue();
        _miniHeroGroups.style.top = (_verticalSize-mouseClickPosition.y);
        _miniHeroGroups.style.left = mouseClickPosition.x;
        
    }
    void MouseClickMove()
    {
        if(Input.GetMouseButtonDown(0))
        {
            DisplayMiniHeroGroupsAtMouse();
            /*
            Debug.Log("testClick");
            Vector2 mouseClickPosition = Mouse.current.position.ReadValue();
            Debug.Log(mouseClickPosition);
            DisplayMiniHeroGroupsAt(mouseClickPosition);*/
        }
    }
}
