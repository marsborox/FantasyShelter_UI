using UnityEngine;
using UnityEngine.UIElements;
using System;
using TMPro;
using System.Collections.Generic;

public class UI : MonoBehaviour
{
    [SerializeField] public HeroManager heroManager;
    /*
    public Color32 pressedColor = new Color32(180,180,180,180);
    public Color32 unpressedColor = new Color32(200,200,200,200);
    */

    private Color32 _pressedColor = new Color32(200, 200, 200, 255);
    private Color32 _unpressedColor = new Color32(245, 245, 216, 255);
    private Color32 _backGroundColor = new Color32(0, 0, 0, 122);
    
    public const string BASIC_TEXT_CONTAINER_SMALL = "basic-text-container-small";
    public const string BASIC_TEXT_CONTAINER_MEDIUM = "basic-text-container-medium";
    public const string BASIC_TEXT_CONTAINER_120px = "basic-text-container-120px";
    public const string BASIC_TEXT_CONTAINER_LARGE = "basic-text-container-large";
    public const string HEORES_BAR = "heroes-bar";
    public const string BASIC_TEXT_TEXT = "basic-text-text";
    public const string MY_BUTTON = "my-button";

    //this is to track callback methods subscibed to buttons for cmpllete removals later
    private Dictionary<Button, List<EventCallback<ClickEvent>>> _buttonCallbacks = new Dictionary<Button, List<EventCallback<ClickEvent>>>();
    private Dictionary<VisualElement, List<EventCallback<ClickEvent>>> _elementCallbacks = new Dictionary<VisualElement, List<EventCallback<ClickEvent>>>();
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

    #region Subscribe Method to VisualElement
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
    public void InitiateElement(Button button, Action method)
    {
        //this will save method as callback
        EventCallback<ClickEvent> callback = evt => method();
        button.RegisterCallback(callback);//this does subscription of method to button click event
        //if this button is not in dictionary add it
        if (!_buttonCallbacks.ContainsKey(button)) {_buttonCallbacks[button] = new List<EventCallback<ClickEvent>>();}
        //add callback to list
        _buttonCallbacks[button].Add(callback);

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

    #region OldMethods
    public void CloseThisTab(Button button)
    {
        ResetButtonColor(button);
        gameObject.SetActive(false);
    }
    public void CloseTab(Button button, UI_Old ui)
    {
        ResetButtonColor(button);
        ui.gameObject.SetActive(false);
    }
    public void CloseTab(UI_Old ui)
    {
        ui.gameObject.SetActive(false);
    }

    public void ResetButtonColor(Button button)
    {
        // set color
        //button.GetComponent<Image>().color = _unpressedColor;
    }
    public void SetButtonPressedColor(Button button)
    {
        // set color
        //button.GetComponent<Image>().color = _pressedColor;
    }
    public void SetButtonTextValue(TextMeshProUGUI fieldToFill, string text)
    {
        fieldToFill.text = text;
    }
    public void SetButtonTextValue(TextMeshProUGUI fieldToFill, int text)
    {
        fieldToFill.text = text.ToString();
    }
    /*public void SetBackGroundImageColor(Image image)
    { 
    seems unused for now
        image.color= _backGroundColor;
    }*/
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
    public VisualElement ReturnTextWindow(string containerClass, string textClass, string displayedValue)
    {
        VisualElement textField = new VisualElement();
        //add whole element to list
        textField.AddToClassList(containerClass);
        Label text = new Label();
        textField.Add(text);
        text.AddToClassList(textClass);
        text.text = displayedValue;
        return textField;
    }
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
    public Button ReturnButton(string containerClass, string displayedValue)
    {
        Button button = new Button();
        //***************************************WORK HERE
        button.AddToClassList(MY_BUTTON);
        button.AddToClassList(containerClass);//need fixing

        button.text=displayedValue;

        return button;
    }
    #endregion
    public void DestroyChildren()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}
