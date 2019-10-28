using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NearbyMessages;

public class StorySceneManager : MonoBehaviour
{
    public Canvas canvas;
    public PrefabsLoader prefabsLoader;
    public GameObject areaLeftPanelPrefab;
    public string nonPhysicalScene;

    private NearbyMessagesEventSystem _nearbyMessages;
    private GameObject currentScreen;

    private string CurrentScene { get => GameState.Instance.currentPlace;  }
    private string CurrentSceneProgress { get => GameState.Instance.GameProgress.GetSceneProgress(CurrentScene); }
    
    // Start is called before the first frame update
    void Start()
    {
        ListenToPhysicalSceneChanges();
        LoadScreen();
    }

    void OnDestroy()
    {
        if (_nearbyMessages == null) return;
        _nearbyMessages.OnNearbyMessageLost -= OnPlaceOutOfRange;
    }

    private void ListenToPhysicalSceneChanges()
    {
        if (CurrentScene.ToLower() == nonPhysicalScene.ToLower()) return;

        _nearbyMessages = NearbyMessagesEventSystem.Instance;
        if (_nearbyMessages == null) return;

        _nearbyMessages.OnNearbyMessageLost += OnPlaceOutOfRange;
    }

    private void LoadScreen()
    {
        var prefab = prefabsLoader.Prefab($"{CurrentScene}/{CurrentScene}{CurrentSceneProgress}");
        Instantiate(prefab, canvas.transform);
    }

    private void OnPlaceOutOfRange(NearbyMessage message)
    {
        var currenPlace = GameState.Instance.currentPlace;
        if (message.Content != currenPlace) return;
        Instantiate(areaLeftPanelPrefab, canvas.transform);
    }

}
