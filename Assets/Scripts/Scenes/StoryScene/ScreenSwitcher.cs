using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSwitcher : MonoBehaviour
{
    public GameObject nextScene;
    public Button activator;

    private StorySceneManager storySceneManager;
 
    public void Initialize(StorySceneManager storySceneManager)
    {
        this.storySceneManager = storySceneManager;
        AddOnClickEvent();
    }

    private void AddOnClickEvent()
    {
        activator.onClick.AddListener(() => storySceneManager.CreateScreen(nextScene));
    }
}
