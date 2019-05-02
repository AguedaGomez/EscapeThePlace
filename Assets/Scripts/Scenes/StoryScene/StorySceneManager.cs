using System;
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

    private void LoadScreen()
    {
        //Depends on beacon lecture
        //prefabsLoader.route += nameScreen
        prefabsLoader.route += "/" + "basement/basement1";
        Instantiate(prefabsLoader.Prefab, canvas.transform);
    }



}
