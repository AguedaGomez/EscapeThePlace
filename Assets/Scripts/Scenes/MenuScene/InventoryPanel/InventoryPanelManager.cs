using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelManager : MonoBehaviour
{

    public GameObject itemsGrid;
    public GameObject inventoryItem;
    public GameObject emptyItem;
    public int capacity;

    private IItemsRepository itemsRepository;
    private Dictionary<string, Sprite> itemSprites = new Dictionary<string, Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        itemsRepository = new DummyItemsRepository();
        LoadSprites();

        var items = itemsRepository.GetItems();
        var empties = capacity - items.Count;

        foreach (var item in items)
        { 
            var uiItem = Instantiate(inventoryItem, itemsGrid.transform);
            uiItem.transform.Find("ItemImage").GetComponentInChildren<Image>().sprite = itemSprites[item.name];
        }

        for (int i = 0; i < empties; i++)
        {
            Instantiate(emptyItem, itemsGrid.transform);
        }
    }

    private void LoadSprites()
    {
        var sprites = Resources.LoadAll<Sprite>("Sprites/MenuScene/InventoryPanel/Items");
        foreach (var sprite in sprites)
        {
            itemSprites.Add(sprite.name, sprite);
        }
    }
}

[Serializable]
public class InventoryItem
{
    public string name;

    public InventoryItem(string name)
    {
        this.name = name;
    }
}

public interface IItemsRepository
{
    List<InventoryItem> GetItems();
}


public class DummyItemsRepository : IItemsRepository
{
    private List<InventoryItem> playerItems = new List<InventoryItem>();

    public DummyItemsRepository()
    {
        playerItems.Add(new InventoryItem("Lantern"));
        playerItems.Add(new InventoryItem("Notes"));
    }

    public List<InventoryItem> GetItems()
    {
        return playerItems;
    }
}
