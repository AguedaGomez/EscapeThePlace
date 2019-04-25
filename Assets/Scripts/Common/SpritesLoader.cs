using System.Collections.Generic;
using UnityEngine;

public class SpritesLoader: MonoBehaviour
{
    public string route;

    public Dictionary<string, Sprite> Sprites
    {
        get {
            if (_resourcesLoader == null)
            {
                _resourcesLoader = new ResourcesLoader<Sprite>(route);
            }
            return _resourcesLoader.LoadedResources;
        }
    }

    private ResourcesLoader<Sprite> _resourcesLoader;
}
