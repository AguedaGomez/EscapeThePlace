﻿using System.Collections.Generic;
using UnityEngine;

public class PrefabsLoader : MonoBehaviour
{
    public string route;

    public Dictionary<string, GameObject> Prefabs
    {
        get
        {
            if (_resourcesLoader == null)
            {
                _resourcesLoader = new ResourcesLoader<GameObject>(route);
            }
            return _resourcesLoader.LoadedResources;
        }
    }

    public GameObject Prefab
    {
        get
        {
            if (_resourcesLoader == null)
            {
                _resourcesLoader = new ResourcesLoader<GameObject>(route);
            }
            return _resourcesLoader.LoadedResource;
        }
    }

    private ResourcesLoader<GameObject> _resourcesLoader;
}
