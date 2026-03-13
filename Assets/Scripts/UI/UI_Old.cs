using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UI_Old : MonoBehaviour
{
    [SerializeField] public HeroManager heroManager;
    /*
    public Color32 pressedColor = new Color32(180,180,180,180);
    public Color32 unpressedColor = new Color32(200,200,200,200);
    */

    private Color32 _pressedColor = new Color32(200, 200, 200, 255);
    private Color32 _unpressedColor = new Color32(245, 245, 216, 255);
    private Color32 _backGroundColor = new Color32(0, 0, 0, 122);
    
    
    public void Start()
    {
        
    }

    public void InitiateButtonUIPanel(Button button, GameObject gUIPanel)
    {
        button.onClick.AddListener(delegate
        {

            ButtonMethod(button, gUIPanel);
            //boolUI = tempBoolean;
        });
        gUIPanel.SetActive(false);
    }
    public void InitiateButtonUIPanel(Button button, UI_Old gUIPanel)
    {
        button.onClick.AddListener(delegate
        {

            ButtonMethod( button, gUIPanel);
            //boolUI = tempBoolean;
        });
        gUIPanel.gameObject.SetActive(false);
    }
    public void InitiateButton(Button button, Action method)
    {
        button.onClick.AddListener(delegate
        {
            method();
        });
        //boolUI = false;
    }
    
    public void InitiateButton<T>(Button button, Action<T> method,T value)
    {
        button.onClick.AddListener(delegate
        {
            method(value);
        });
        //boolUI = false;
    }
    /*
    public void InitiateButton (Button button, Action<Button,UI> method, UI ui)
    {
        button.onClick.AddListener(delegate
        {
            method(button, ui);
        });
        //boolUI = false;
    }*/
    //this is prob for return type
    public void InitiateButtonFunc<T>(Button button, Func<T> method)
    {//will remove this later
        button.onClick.AddListener(delegate
        {
            method();
        });
        //boolUI = false;
    }
    public void RemoveListeners(Button button)
    { 
        button.onClick.RemoveAllListeners();
    }
    public void ButtonMethod(Button button, GameObject gUIPanel)
    {
        if (!gUIPanel.activeSelf)
        {
            //bool tempBoolean = true;
            button.GetComponent<Image>().color = _pressedColor;
            //uiComponent.SetActive(boolUI);
            //Debug.Log("ButtonePressed");
            gUIPanel.gameObject.SetActive(true);
        }
        else
        {
            //tempBoolean = false;
            button.GetComponent<Image>().color = _unpressedColor;
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
            button.GetComponent<Image>().color = _pressedColor;
            //uiComponent.SetActive(boolUI);
            //Debug.Log("ButtonePressed");
            gUIPanel.gameObject.SetActive(true);
        }
        else
        {
            //tempBoolean = false;
            button.GetComponent<Image>().color = _unpressedColor;
            //uiComponent.SetActive(boolUI);3
            //Debug.Log("ButtonUnpressed");
            gUIPanel.gameObject.SetActive(false);
        }
    }

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
        button.GetComponent<Image>().color = _unpressedColor;
    }
    public void SetButtonPressedColor(Button button)
    {
        button.GetComponent<Image>().color = _pressedColor;
    }
    public void SetButtonTextValue(TextMeshProUGUI fieldToFill, string text)
    {
        fieldToFill.text = text;
    }
    public void SetButtonTextValue(TextMeshProUGUI fieldToFill, int text)
    {
        fieldToFill.text = text.ToString();
    }
    public void SetBackGroundImageColor(Image image)
    { 
        image.color= _backGroundColor;
    }

    public void DestroyChildren()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}
