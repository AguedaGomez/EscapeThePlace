﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySceneManager : MonoBehaviour
{
    public Canvas canvas;
    public PrefabsLoader prefabsLoader;

    private GameObject currentScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadScreen();
    }

    public void CreateScreen(GameObject prefab)
    {
        if (currentScreen)
        {
            Destroy(currentScreen);
        } 
        currentScreen = Instantiate(prefab, canvas.transform);
        if (currentScreen.tag == "Text")
        {
            var typeWritterEffect = currentScreen.transform.Find("TextBoxBg").Find("Text").GetComponent<TypeWritterEffect>();
            typeWritterEffect.EffectIsFinish += TypeWritterEffect_EffectIsFinish;
        }
        else
        {
            GetScreenSwitcher();
        }

    }

    private void TypeWritterEffect_EffectIsFinish()
    {
        GetScreenSwitcher();
    }

    private void GetScreenSwitcher()
    {
        var screenSwitchers = currentScreen.GetComponents<ScreenSwitcher>();
        for(int i = 0; i < screenSwitchers.Length; i++)
            screenSwitchers[i].Initialize(this);
    }

    private void LoadScreen()
    {
        //Depends on beacon lecture
        //prefabsLoader.route += nameScreen
        prefabsLoader.route += "/" + "basement/basement4a";
        CreateScreen(prefabsLoader.Prefab);
    }



}