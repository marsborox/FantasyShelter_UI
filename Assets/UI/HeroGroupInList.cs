using UnityEngine;

using UnityEngine.UIElements;
public class HeroGroupInList
{
    public HeroGroup heroGroupIRepresent;
    public VisualElement heroGroupInListVisual;

    public HeroGroupInList(HeroGroup heroGroup, VisualElement visualElement)
    {
        heroGroupIRepresent = heroGroup;
        heroGroupInListVisual = visualElement;
    }
}
