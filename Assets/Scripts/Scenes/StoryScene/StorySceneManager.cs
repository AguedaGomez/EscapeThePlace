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
        var sceneName = GameState.Instance.currentPlace;
        var prefab = prefabsLoader.Prefab($"{sceneName}/{sceneName}1");
        Instantiate(prefab, canvas.transform);
    }



}
