using System;

[Serializable]
public class InventoryItem
{

    public readonly string name, description, imageText;

    public InventoryItem(string name, string description, string imageText)
    {
        this.name = name;
        this.description = description;
        this.imageText = imageText;
    }

    public InventoryItem(string name, string description): this(name, description, "") { }
}
