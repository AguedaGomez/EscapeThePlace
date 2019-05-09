using System.Collections.Generic;

public class InMemoryRepository<T> : IRepository<T>
{
    private Dictionary<string, T> _elements = new Dictionary<string, T>();

    public void AddElement(string key, T element)
    {
        _elements[key] = element;
    }

    public T GetElement(string key)
    {
        T element;
        _elements.TryGetValue(key, out element);
        return element;
    }

    public Dictionary<string, T> GetElements()
    {
        return _elements;
    }
}
