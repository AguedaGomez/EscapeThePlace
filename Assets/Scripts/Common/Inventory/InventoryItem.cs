using System;

[Serializable]
public class InventoryItem
{

    public readonly string name, description;

    public InventoryItem(string name, string description)
    {
        this.name = name;
        this.description = description;
    }
}
