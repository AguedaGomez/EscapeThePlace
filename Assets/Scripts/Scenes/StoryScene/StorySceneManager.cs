using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NearbyMessages;

public class StorySceneManager : MonoBehaviour
{
    public Canvas canvas;
    public PrefabsLoader prefabsLoader;

    private NearbyMessagesEventSystem _nearbyMessages;
    private GameObject currentScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        _nearbyMessages = NearbyMessagesEventSystem.Instance;
        _nearbyMessages.OnNearbyMessageLost += OnPlaceOutOfRange;
        LoadScreen();
    }

    private void OnDestroy()
    {
        _nearbyMessages.OnNearbyMessageLost -= OnPlaceOutOfRange;
    }

    private void LoadScreen()
    {
        var sceneName = GameState.Instance.currentPlace;
        var prefab = prefabsLoader.Prefab($"{sceneName}/{sceneName}{GameState.Instance.GameProgress.GetSceneProgress(sceneName)}");
        Instantiate(prefab, canvas.transform);
    }

    private void OnPlaceOutOfRange(NearbyMessage message)
    {
        var currenPlace = GameState.Instance.currentPlace;
        if (message.Content != currenPlace) return;
        SceneManager.LoadScene("MenuScene");
    }

}
