using UnityEngine;
using System;
[System.Serializable]
    public class StatField
    {
        //nejak vopchat do constructora metodu z hera
        public bool isDisplayed;
        public string name;
        public string containerClass;
        public string defaultText;
        public string value;
        //public Hero heroIRepresent;

        public void SetStatFieldValueText(Func<Hero,string> displayValue,Hero hero)
        {
            
        }
        public StatField(string inputDefaultText, string inputName,string inputContainerClass)
        {
            isDisplayed = true;
            name = inputName;
            containerClass = inputContainerClass;
            defaultText = inputDefaultText;
        }
        public StatField(string inputDefaultText, string inputName,string inputContainerClass, Func<Hero,string> displayValue,Hero hero)
        {
            //for header
            isDisplayed = true;
            name = inputName;
            containerClass = inputContainerClass;
            defaultText = inputDefaultText;
            //value = displayValue(heroIRepresent);
        }

        public StatField(HeroList_UI heroList, string inputDefaultText, string inputName,string inputContainerClass, string inputDisplayValue)
        {
            //for header
            isDisplayed = true;
            name = inputName;
            containerClass = inputContainerClass;
            defaultText = inputDefaultText;
            value = inputDisplayValue;
            
            void DisplayStatField()
            {
                heroList.ReturnTextWindow(containerClass,defaultText);
            }
        }
    }
