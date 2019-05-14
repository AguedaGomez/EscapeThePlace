using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRepository<T>
{
    void AddElement(string key, T element);
    T GetElement(string key);
    Dictionary<string, T> GetElements();
}
