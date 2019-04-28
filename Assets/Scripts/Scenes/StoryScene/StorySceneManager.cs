using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySceneManager : MonoBehaviour
{
    public Canvas canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadScreen();
    }

    private void LoadScreen()
    {
        //Depends on beacon lecture
    }

    private void CreateScreen(GameObject prefab)
    {
        Instantiate(prefab, canvas.transform);
    }

}
