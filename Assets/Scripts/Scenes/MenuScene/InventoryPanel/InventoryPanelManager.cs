using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelManager : MonoBehaviour
{

    public GameObject itemsGrid;
    public GameObject inventoryItem;
    public GameObject emptyItem;
    public int capacity;

    public SpritesLoader spritesLoader;
    public ItemPanelDetailBehavior itemPanelDetail;

    private IItemsRepository itemsRepository;
    private Dictionary<string, Sprite> itemSprites;

    // Start is called before the first frame update
    void Start()
    {
        itemSprites = spritesLoader.Sprites;

        itemsRepository = new DummyItemsRepository();
        var playerItems = itemsRepository.GetItems();
        var emptySlots = capacity - playerItems.Count;

        DisplayPlayerItems(playerItems);
        DisplayEmptyItems(emptySlots);
    }

    private void DisplayPlayerItems(List<InventoryItem> items)
    {
        foreach (var item in items)
        {
            var uiItem = Instantiate(inventoryItem, itemsGrid.transform);
            var behaviour = uiItem.GetComponent<InventoryItemBehavior>();
            behaviour.SetItem(item);
            behaviour.SetImage(itemSprites[item.name]);
            behaviour.SetOnClick(itemPanelDetail.DisplayItemDetails);
        }
    }

    private void DisplayEmptyItems(int empties)
    {
        for (int i = 0; i < empties; i++)
        {
            Instantiate(emptyItem, itemsGrid.transform);
        }
    }
}

[Serializable]
public class InventoryItem
{
    public string name;
    public string description;
    public string textInImage;

    public InventoryItem(string name, string description, string textInImage)
    {
        this.name = name;
        this.description = description;
        this.textInImage = textInImage;
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
        playerItems.Add(new InventoryItem("Lantern", "adfoibgnersx", ""));
        playerItems.Add(new InventoryItem("Notes", "sdfgsfgdfg", ""));
    }

    public List<InventoryItem> GetItems()
    {
        return playerItems;
    }
}
