using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRepository<T>
{
    void AddElement(string key, T element);
    Dictionary<string, T> GetElements();
}
