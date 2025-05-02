using UnityEngine;
using UnityEngine.UI;
using System;
using NUnit.Framework;
using UnityEditor;
using System.Collections.Generic;

public class UI : MonoBehaviour
{
    /*
    public Color32 pressedColor = new Color32(180,180,180,180);
    public Color32 unpressedColor = new Color32(200,200,200,200);
    */

    Color32 pressedColor = new Color32(200, 200, 200, 255);
    Color32 unpressedColor = new Color32(245, 245, 216, 255);

    
    
    private void Start()
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
    public void InitiateButton(Button button, Action method)
    {
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
            button.GetComponent<Image>().color = pressedColor;
            //uiComponent.SetActive(boolUI);
            Debug.Log("ButtonePressed");
            gUIPanel.gameObject.SetActive(true);
        }
        else
        {
            //tempBoolean = false;
            button.GetComponent<Image>().color = unpressedColor;
            //uiComponent.SetActive(boolUI);3
            Debug.Log("ButtonUnpressed");
            gUIPanel.gameObject.SetActive(false);
        }
    }
}
