using UnityEngine;

using UnityEngine.UIElements;
    [System.Serializable]
    public class HeroInList
    {
        public Hero heroIRepresent;
        public bool isSelected = false;
        public VisualElement heroInListVisual;

        public void Select()
        {
            Image image = (Image)heroInListVisual.Q(name: "Checkmark");
            if(isSelected) 
            {
                isSelected=false;
                //enable disable
                Debug.Log("CheckmarkOff");
                Debug.Log(image.name);
                image.style.display = DisplayStyle.None;
            }
            else 
            {
                isSelected = true;
                Debug.Log("CheckmarkOn");
                image.style.display = DisplayStyle.Flex;
            }
            Debug.Log("some hero checkmark: "+isSelected);
        }
        public HeroInList(Hero hero, VisualElement visualElement)
        {
            heroIRepresent = hero;
            heroInListVisual = visualElement;
        }
    }
