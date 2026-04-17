using UnityEngine;
using UnityEngine.UIElements;
using System;
using TMPro;
using System.Collections.Generic;
using MessagePack.Resolvers;
using System.Runtime.InteropServices.WindowsRuntime;

public abstract class UI : MonoBehaviour
{
    public string uiPanelName;
    /*[SerializeField] public HeroManager heroManager;*/
    /*
    public Color32 pressedColor = new Color32(180,180,180,180);
    public Color32 unpressedColor = new Color32(200,200,200,200);
    */

    public string isTest
    {
        get {return TOP_CENTRAL_NAME_FIELD;}
    }

    private Color32 _pressedColor = new Color32(200, 200, 200, 255);
    private Color32 _unpressedColor = new Color32(245, 245, 216, 255);
    private Color32 _backGroundColor = new Color32(0, 0, 0, 122);
    #region containerClasses
    //public const string TOP_PAMEL_POPUP = "top-panel-popup";
    
    string topPanelPopUp = "ds";
    //public const string TOP_PAMEL_POPUP = "top-panel-popup";
    public static string TOP_PAMEL_POPUP {get {return UI_Constants.TOP_PAMEL_POPUP;}private set{}}
    //public const string TOP_CENTRAL_NAME_FIELD = "top-central-name-field";
    public static string TOP_CENTRAL_NAME_FIELD {get {return UI_Constants.TOP_CENTRAL_NAME_FIELD;}private set{}}
    //public const string BASIC_TEXT_CONTAINER_SMALL = "basic-text-container-small";
    public static string BASIC_TEXT_CONTAINER_SMALL {get {return UI_Constants.BASIC_TEXT_CONTAINER_SMALL;}private set{}}
    //public const string BASIC_TEXT_CONTAINER_MEDIUM = "basic-text-container-medium";
    public static string BASIC_TEXT_CONTAINER_MEDIUM {get {return UI_Constants.BASIC_TEXT_CONTAINER_MEDIUM;}private set{}}
    //public const string BASIC_TEXT_CONTAINER_120px = "basic-text-container-120px";
    public static string BASIC_TEXT_CONTAINER_120px {get {return UI_Constants.BASIC_TEXT_CONTAINER_120px;}private set{}}

    //public const string BASIC_TEXT_CONTAINER_LARGE = "basic-text-container-large";
    public static string BASIC_TEXT_CONTAINER_LARGE {get {return UI_Constants.BASIC_TEXT_CONTAINER_LARGE;} private set{}}
    
    //public const string BASIC_TEXT_CONTAINER_STRETCH = "basic-text-container-stretch";
    public static string BASIC_TEXT_CONTAINER_STRETCH {get {return UI_Constants.BASIC_TEXT_CONTAINER_STRETCH;} private set{}}
    
    //public const string BASIC_CONTAINER_PICTOGRAM = "basic-text-container-pictogram";
    public string BASIC_CONTAINER_PICTOGRAM {get {return UI_Constants.BASIC_CONTAINER_PICTOGRAM;} private set{}}
    #endregion

   
    //public const string BASIC_PICTOGRAM = "pictogram";
    public static string BASIC_PICTOGRAM {get {return UI_Constants.BASIC_PICTOGRAM;} private set{}}
    //public const string IMAGE_COLOR_GREEN = "image-color-green";
    public static string IMAGE_COLOR_GREEN {get {return UI_Constants.IMAGE_COLOR_GREEN;} private set{}}
    //public const string HEORES_BAR = "heroes-bar";
    public static string HEORES_BAR {get {return UI_Constants.HEORES_BAR;} private set{}}
    //public const string BASIC_TEXT_TEXT = "basic-text-text";
    public static string BASIC_TEXT_TEXT {get {return UI_Constants.BASIC_TEXT_TEXT;} private set{}}

    //public const string MY_BUTTON = "my-button";
    public static string MY_BUTTON {get {return UI_Constants.MY_BUTTON;} private set{}}

    #region names
    //public const string EXIT_BUTTON = "ExitButton";
    public static string EXIT_BUTTON {get {return UI_Constants.EXIT_BUTTON;} private set{}}
    #endregion

    public StatField_List statFieldList;
    //this is to track callback methods subscibed to buttons for cmpllete removals later
    private Dictionary<Button, List<EventCallback<ClickEvent>>> _buttonCallbacks = new Dictionary<Button, List<EventCallback<ClickEvent>>>();
    private Dictionary<VisualElement, List<EventCallback<ClickEvent>>> _elementCallbacks = new Dictionary<VisualElement, List<EventCallback<ClickEvent>>>();
    void Awake()
    {
        statFieldList = GetComponent<StatField_List>();   
    }
    public void Start()
    {
        
    }
    #region SubscribeMethodToButton
    public void InitiateButtonUIPanel(Button button, GameObject gUIPanel)
    {
        //this will save method as callback
        EventCallback<ClickEvent> callback = evt => ButtonMethod(button, gUIPanel);
        button.RegisterCallback(callback);//this does subscription of method to button click event
        //if this button is not in dictionary add it
        if (!_buttonCallbacks.ContainsKey(button)) {_buttonCallbacks[button] = new List<EventCallback<ClickEvent>>();}
        //add callback to list
        _buttonCallbacks[button].Add(callback);

        gUIPanel.SetActive(false);
    }
    public void InitiateButtonUIPanel(Button button, UI_Old gUIPanel)
    {
        //this will save method as callback
        EventCallback<ClickEvent> callback = evt => ButtonMethod(button, gUIPanel);
        button.RegisterCallback(callback);//this does subscription of method to button click event
        //if this button is not in dictionary add it
        if (!_buttonCallbacks.ContainsKey(button)) {_buttonCallbacks[button] = new List<EventCallback<ClickEvent>>();}
        //add callback to list
        _buttonCallbacks[button].Add(callback);

        gUIPanel.gameObject.SetActive(false);
    }
    public void InitiateButton(Button button, Action method)
    {
        //this will save method as callback
        EventCallback<ClickEvent> callback = evt => method();
        button.RegisterCallback(callback);//this does subscription of method to button click event
        //if this button is not in dictionary add it
        if (!_buttonCallbacks.ContainsKey(button)) {_buttonCallbacks[button] = new List<EventCallback<ClickEvent>>();}
        //add callback to list
        _buttonCallbacks[button].Add(callback);

    }
    
    public void InitiateButton<T>(Button button, Action<T> method,T value)
    {

        //this will save method as callback
        EventCallback<ClickEvent> callback = evt => method(value);
        button.RegisterCallback(callback);//this does subscription of method to button click event
        //if this button is not in dictionary add it
        if (!_buttonCallbacks.ContainsKey(button)) {_buttonCallbacks[button] = new List<EventCallback<ClickEvent>>();}
        //add callback to list
        _buttonCallbacks[button].Add(callback);
    }
    
    public void InitiateButton (Button button, Action<Button,UI> method, UI ui)
    {

        //this will save method as callback
        EventCallback<ClickEvent> callback = evt => method(button,ui);
        button.RegisterCallback(callback);//this does subscription of method to button click event
        //if this button is not in dictionary add it
        if (!_buttonCallbacks.ContainsKey(button)) {_buttonCallbacks[button] = new List<EventCallback<ClickEvent>>();}
        //add callback to list
        _buttonCallbacks[button].Add(callback);
    }
    //this is prob for return type
    public void InitiateButtonFunc<T>(Button button, Func<T> method)
    {//will remove this later
        button.RegisterCallback<ClickEvent>(delegate
        {
            method();
        });
        //boolUI = false;
    }
    public void ButtonMethod(Button button, GameObject gUIPanel)
    {
        if (!gUIPanel.activeSelf)
        {
            //bool tempBoolean = true;
            // set color
            //button.GetComponent<Image>().color = _pressedColor;
            //uiComponent.SetActive(boolUI);
            //Debug.Log("ButtonePressed");
            gUIPanel.gameObject.SetActive(true);
        }
        else
        {
            //tempBoolean = false;
            // set color
            //button.GetComponent<Image>().color = _unpressedColor;
            //uiComponent.SetActive(boolUI);3
            //Debug.Log("ButtonUnpressed");
            gUIPanel.gameObject.SetActive(false);
        }
    }
    public void ButtonMethod(Button button, UI_Old gUIPanel)
    {
        if (!gUIPanel.gameObject.activeSelf)
        {
            //bool tempBoolean = true;
            // set color
            //button.GetComponent<Image>().color = _pressedColor;
            //uiComponent.SetActive(boolUI);
            //Debug.Log("ButtonePressed");
            gUIPanel.gameObject.SetActive(true);
        }
        else
        {
            //tempBoolean = false;
            // set color
            //button.GetComponent<Image>().color = _unpressedColor;
            //uiComponent.SetActive(boolUI);3
            //Debug.Log("ButtonUnpressed");
            gUIPanel.gameObject.SetActive(false);
        }
    }

    public void RemoveListeners(Button button)
    {
        //this will remove all listeners 
        if (_buttonCallbacks.ContainsKey(button))
        {
            foreach (var cb in _buttonCallbacks[button])
            {
                button.UnregisterCallback(cb);
            }
            _buttonCallbacks[button].Clear();
        }
    }
    #endregion

    #region SubscribeMethodToVisualElement
    
    public void InitiateElementUIPanel(VisualElement element, GameObject gUIPanel)
    {
        //this will save method as callback
        EventCallback<ClickEvent> callback = evt => ElementMethod(element, gUIPanel);
        element.RegisterCallback(callback);//this does subscription of method to button click event
        //if this button is not in dictionary add it
        if (!_elementCallbacks.ContainsKey(element)) {_elementCallbacks[element] = new List<EventCallback<ClickEvent>>();}
        //add callback to list
        _elementCallbacks[element].Add(callback);

        gUIPanel.SetActive(false);
    }
    public void InitiateElementUIPanel(VisualElement element, UI_Old gUIPanel)
    {
        //this will save method as callback
        EventCallback<ClickEvent> callback = evt => ElementMethod(element, gUIPanel);
        element.RegisterCallback(callback);//this does subscription of method to button click event
        //if this button is not in dictionary add it
        if (!_elementCallbacks.ContainsKey(element)) {_elementCallbacks[element] = new List<EventCallback<ClickEvent>>();}
        //add callback to list
        _elementCallbacks[element].Add(callback);

        gUIPanel.gameObject.SetActive(false);
    }
    public void InitiateElement(VisualElement element, Action method)
    {
        //this will save method as callback
        EventCallback<ClickEvent> callback = evt => method();
        element.RegisterCallback(callback);//this does subscription of method to button click event
        //if this button is not in dictionary add it
        if (!_elementCallbacks.ContainsKey(element)) {_elementCallbacks[element] = new List<EventCallback<ClickEvent>>();}
        //add callback to list
        _elementCallbacks[element].Add(callback);

    }
    
    public void InitiateElement<T>(VisualElement element, Action<T> method,T value)
    {

        //this will save method as callback
        EventCallback<ClickEvent> callback = evt => method(value);
        element.RegisterCallback(callback);//this does subscription of method to button click event
        //if this button is not in dictionary add it
        if (!_elementCallbacks.ContainsKey(element)) {_elementCallbacks[element] = new List<EventCallback<ClickEvent>>();}
        //add callback to list
        _elementCallbacks[element].Add(callback);
    }
    
    public void InitiateElement (VisualElement element, Action<VisualElement,UI> method, UI ui)
    {

        //this will save method as callback
        EventCallback<ClickEvent> callback = evt => method(element,ui);
        element.RegisterCallback(callback);//this does subscription of method to button click event
        //if this button is not in dictionary add it
        if (!_elementCallbacks.ContainsKey(element)) {_elementCallbacks[element] = new List<EventCallback<ClickEvent>>();}
        //add callback to list
        _elementCallbacks[element].Add(callback);
    }
    //this is prob for return type
    public void InitiateElementFunc<T>(VisualElement button, Func<T> method)
    {//will remove this later
        button.RegisterCallback<ClickEvent>(delegate
        {
            method();
        });
        //boolUI = false;
    }
    public void ElementMethod(VisualElement element, GameObject gUIPanel)
    {
        if (!gUIPanel.activeSelf)
        {
            //bool tempBoolean = true;
            // set color
            //button.GetComponent<Image>().color = _pressedColor;
            //uiComponent.SetActive(boolUI);
            //Debug.Log("ButtonePressed");
            gUIPanel.gameObject.SetActive(true);
        }
        else
        {
            //tempBoolean = false;
            // set color
            //button.GetComponent<Image>().color = _unpressedColor;
            //uiComponent.SetActive(boolUI);3
            //Debug.Log("ButtonUnpressed");
            gUIPanel.gameObject.SetActive(false);
        }
    }
    public void ElementMethod(VisualElement button, UI_Old gUIPanel)
    {
        if (!gUIPanel.gameObject.activeSelf)
        {
            //bool tempBoolean = true;
            // set color
            //button.GetComponent<Image>().color = _pressedColor;
            //uiComponent.SetActive(boolUI);
            //Debug.Log("ButtonePressed");
            gUIPanel.gameObject.SetActive(true);
        }
        else
        {
            //tempBoolean = false;
            // set color
            //button.GetComponent<Image>().color = _unpressedColor;
            //uiComponent.SetActive(boolUI);3
            //Debug.Log("ButtonUnpressed");
            gUIPanel.gameObject.SetActive(false);
        }
    }


    public void RemoveListeners(VisualElement element)
    {
        //this will remove all listeners 
        if (_elementCallbacks.ContainsKey(element))
        {
            foreach (var cb in _elementCallbacks[element])
            {
                element.UnregisterCallback(cb);
            }
            _elementCallbacks[element].Clear();
        }
    }
    #endregion

    #region Field Creation

    public VisualElement ReturnTextWindowSmall(string displayedValue)
    {
        VisualElement textField = new VisualElement();
        //add whole element to list
        textField.AddToClassList(BASIC_TEXT_CONTAINER_LARGE);
        Label text = new Label();
        textField.Add(text);
        text.AddToClassList(BASIC_TEXT_TEXT);
        text.text = displayedValue;
        return textField;
    }
    public VisualElement ReturnTextWindowMedium(string displayedValue)
    {
        VisualElement textField = new VisualElement();
        //add whole element to list
        textField.AddToClassList(BASIC_TEXT_CONTAINER_MEDIUM);
        Label text = new Label();
        textField.Add(text);
        text.AddToClassList(BASIC_TEXT_TEXT);
        text.text = displayedValue;
        return textField;
    }
    public VisualElement ReturnTextWindowLarge(string displayedValue)
    {
        VisualElement textField = new VisualElement();
        //add whole element to list
        textField.AddToClassList(BASIC_TEXT_CONTAINER_LARGE);
        Label text = new Label();
        textField.Add(text);
        text.AddToClassList(BASIC_TEXT_TEXT);
        text.text = displayedValue;
        return textField;
    }

    /*public VisualElement ReturnTextWindow(string containerClass, string textClass, string displayedValue)
    {
        VisualElement textField = new VisualElement();
        //add whole element to list
        textField.AddToClassList(containerClass);
        Label text = new Label();
        textField.Add(text);
        text.AddToClassList(textClass);
        text.text = displayedValue;
        return textField;
    }*/
    public VisualElement ReturnTextWindow(string containerClass, string displayedValue)
    {
        VisualElement textField = new VisualElement();
        //add whole element to list
        textField.AddToClassList(containerClass);
        Label text = new Label();
        textField.Add(text);
        text.AddToClassList(BASIC_TEXT_TEXT);
        text.text = displayedValue;
        return textField;
    }
    //need to take care of name setup
    public VisualElement ReturnTextWindow(string name,string containerClass, string displayedValue)
    {
        VisualElement textField = new VisualElement();
        //add whole element to list
        textField.AddToClassList(containerClass);
        textField.name = name;
        Label text = new Label();
        textField.Add(text);
        text.AddToClassList(BASIC_TEXT_TEXT);
        text.text = displayedValue;
        return textField;
    }    
    public Button ReturnButton(string containerClass, string displayedValue)
    {
        Button button = new Button();
        //***************************************WORK HERE
        button.AddToClassList(MY_BUTTON);
        button.AddToClassList(containerClass);//need fixing

        button.text=displayedValue;

        return button;
    }
    public Button ReturnButton(string name,string containerClass, string displayedValue)
    {
        Button button = new Button();
        //***************************************WORK HERE
        button.AddToClassList(MY_BUTTON);
        button.AddToClassList(containerClass);//need fixing

        button.text=displayedValue;
        button.name = name;

        return button;
    }
    public VisualElement ReturnPictogram(string inputName)
    {
        VisualElement element = new VisualElement();
        element.AddToClassList(BASIC_CONTAINER_PICTOGRAM);
        Image image = new Image();
        element.Add(image);
        image.AddToClassList(BASIC_PICTOGRAM);
        image.name = inputName;
        
        return element;
    }
        public VisualElement ReturnPictogram(string inputName, Texture displayImage)
    {
        VisualElement element = new VisualElement();
        element.AddToClassList(BASIC_CONTAINER_PICTOGRAM);
        Image image = new Image();
        element.Add(image);
        image.AddToClassList(BASIC_PICTOGRAM);
        image.name = inputName;
        image.image=displayImage;
        
        return element;
    }
    public VisualElement ReturnPictogram(string inputName, Texture displayImage, string colorClass)
    {
        VisualElement element = new VisualElement();
        element.AddToClassList(BASIC_CONTAINER_PICTOGRAM);
        Image image = new Image();
        element.Add(image);
        image.AddToClassList(BASIC_PICTOGRAM);
        image.name = inputName;
        image.image=displayImage;
        image.AddToClassList(colorClass);
        return element;
    }
    public VisualElement ReturnTopUI_Bar(string displayedValue)
    {
        VisualElement topUI_Bar = new VisualElement();
        topUI_Bar.AddToClassList(TOP_PAMEL_POPUP);

        Button exitButton = ReturnButton(EXIT_BUTTON,MY_BUTTON,"X");
        
        InitiateButton(exitButton,PrintStrinng,"X");
        topUI_Bar.Add(exitButton);

        VisualElement centralNameField = ReturnTextWindow("top-central-name-field",displayedValue);
        topUI_Bar.Add(centralNameField);
        return topUI_Bar;
    }
        public VisualElement ReturnTopUI_Bar(string displayedValue, Action closeUI)
    {
        VisualElement topUI_Bar = new VisualElement();
        topUI_Bar.AddToClassList(TOP_PAMEL_POPUP);

        VisualElement centralNameField = ReturnTextWindow("top-central-name-field",displayedValue);
        centralNameField.AddToClassList(BASIC_TEXT_CONTAINER_STRETCH);
        
        topUI_Bar.Add(centralNameField);

        Button exitButton = ReturnButton(EXIT_BUTTON,MY_BUTTON,"X");
        InitiateButton(exitButton,closeUI/*,"X"*/);
        //InitiateButton(exitButton,PrintStrinng,"X");
        topUI_Bar.Add(exitButton);


        return topUI_Bar;
    }

    #endregion
    public void ShowElement(VisualElement element)
    {
        element.style.display = DisplayStyle.Flex;
    }
    public void HideElement(VisualElement element)
    {
        element.style.display=DisplayStyle.None;
    }
    void PrintStrinng(string printString)
    {
        Debug.Log(printString);   
    }
    public void DestroyChildren()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
    public abstract void SetHeader();
    public abstract void DisplayUI();
    public abstract void OpenUI();
    public abstract void CloseUI();
    
    
}
