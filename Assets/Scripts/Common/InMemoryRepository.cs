using System.Collections.Generic;

public class InMemoryRepository<T> : IRepository<T>
{
    private Dictionary<string, T> _elements = new Dictionary<string, T>();

    public void AddElement(string key, T element)
    {
        _elements.Add(key, element);
    }

    public Dictionary<string, T> GetElements()
    {
        return _elements;
    }
}
