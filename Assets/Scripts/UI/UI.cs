using UnityEngine;
using UnityEngine.UI;
using System;
using NUnit.Framework;
using UnityEditor;
using System.Collections.Generic;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] public HeroManager heroManager;
    /*
    public Color32 pressedColor = new Color32(180,180,180,180);
    public Color32 unpressedColor = new Color32(200,200,200,200);
    */

    private Color32 _pressedColor = new Color32(200, 200, 200, 255);
    private Color32 _unpressedColor = new Color32(245, 245, 216, 255);

    
    
    public void Start()
    {
        
    }

    public void InitiateButtonUIPanel(/*bool boolUI,*/Button button, GameObject gUIPanel)
    {
        button.onClick.AddListener(delegate
        {

            ButtonMethod(/*boolUI,*/ button, gUIPanel);
            //boolUI = tempBoolean;
        });
        gUIPanel.SetActive(false);
    }
    public void InitiateButtonUIPanel(/*bool boolUI,*/Button button, UI gUIPanel)
    {
        button.onClick.AddListener(delegate
        {

            ButtonMethod(/*boolUI,*/ button, gUIPanel);
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
    public void InitiateButtonFunc<T>(Button button, Func<T> method)
    {//will remove this later
        button.onClick.AddListener(delegate
        {
            method();
        });
        //boolUI = false;
    }
    public void ButtonMethod(/*bool boolUI,*/ Button button, GameObject gUIPanel)
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
    public void ButtonMethod(/*bool boolUI,*/ Button button, UI gUIPanel)
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
            //button.GetComponent<Image>().color = _unpressedColor;
            //uiComponent.SetActive(boolUI);3
            //Debug.Log("ButtonUnpressed");
            gUIPanel.gameObject.SetActive(false);
        }
    }


    public void SetValue(TextMeshProUGUI fieldToFill, string text)
    {
        fieldToFill.text = text;
    }
    public void SetValue(TextMeshProUGUI fieldToFill, int text)
    {
        fieldToFill.text = text.ToString();
    }

    public void DestroyChildren()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }
}
