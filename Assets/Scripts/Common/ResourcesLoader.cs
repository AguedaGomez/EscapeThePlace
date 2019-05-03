using System.Collections.Generic;
using UnityEngine;

public class ResourcesLoader<T> where T : Object
{
    public ResourcesLoader(string route)
    {
        _route = route;
    }

    public Dictionary<string, T> LoadedResources
    {
        get
        {
            if (_resources.Count == 0)
            {
                LoadResources();
            }
            return _resources;
        }
    }

    private readonly string _route;
    private readonly Dictionary<string, T> _resources = new Dictionary<string, T>();

    private void LoadResources()
    {
        var resources = Resources.LoadAll<T>(_route);
        foreach (var resource in resources)
        {
            _resources.Add(resource.name, resource);
        }
    }

    public T LoadResource(string path)
    {
        return Resources.Load<T>(_route + "/" + path);
    }
}
