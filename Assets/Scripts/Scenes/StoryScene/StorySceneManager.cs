using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBeacons;

public class StorySceneManager : MonoBehaviour
{
    public Canvas canvas;
    public PrefabsLoader prefabsLoader;
    public GameObject areaLeftPanelPrefab;
    public string nonPhysicalScene;

    private IBeaconsEventSystem _iBeacons;
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
        if (_iBeacons == null) return;
        _iBeacons.OnBeaconLost -= OnPlaceOutOfRange;
    }

    private void ListenToPhysicalSceneChanges()
    {
        if (CurrentScene.ToLower() == nonPhysicalScene.ToLower()) return;

        _iBeacons = IBeaconsEventSystem.Instance;
        if (_iBeacons == null) return;

        _iBeacons.OnBeaconLost += OnPlaceOutOfRange;
    }

    private void LoadScreen()
    {
        var prefab = prefabsLoader.Prefab($"{CurrentScene}/{CurrentScene}{CurrentSceneProgress}");
        Instantiate(prefab, canvas.transform);
    }

    private void OnPlaceOutOfRange(IBeacon beacon)
    {
        var currenPlace = GameState.Instance.currentPlace;
        if (beacon.Tag != currenPlace) return;
        Instantiate(areaLeftPanelPrefab, canvas.transform);
    }

}
