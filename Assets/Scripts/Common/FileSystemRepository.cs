using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileSystemRepository<T> : IRepository<T>
{
    private string _fileName;
    private IRepository<T> _repositoryCache = new InMemoryRepository<T>();

    private string FilePath { get => $"{Application.persistentDataPath}/{_fileName}"; }


    public FileSystemRepository(string fileName)
    {
        _fileName = fileName;
        Debug.Log(FilePath);
        Load();
    }

    public void AddElement(string key, T element)
    {
        _repositoryCache.AddElement(key, element);
        Save();
    }

    public T GetElement(string key)
    {
        return _repositoryCache.GetElement(key);
    }

    public Dictionary<string, T> GetElements()
    {
        return _repositoryCache.GetElements();
    }
    private void Load()
    {
        if (!File.Exists(FilePath)) return;
        var formatter = new BinaryFormatter();
        using (var file = File.Open(FilePath, FileMode.Open))
        {
            try
            {
                Dictionary<string, T> elements = (Dictionary<string, T>)formatter.Deserialize(file);
                LoadItems(elements);
            }
            catch (Exception e)
            {
                Debug.Log($"Error saving {_fileName}: {e}");
            }
        }
    }

    private void Save()
    {
        var formatter = new BinaryFormatter();
        using (var file = File.Create(FilePath))
        {
            try
            {
                formatter.Serialize(file, _repositoryCache.GetElements());
            }
            catch (Exception e)
            {
                Debug.Log($"Error saving {_fileName}: {e}");
            }
        }
    }

    private void LoadItems(Dictionary<string, T> elements)
    {
        foreach (var entry in elements)
        {
            _repositoryCache.AddElement(entry.Key, entry.Value);
        }
    }
}
