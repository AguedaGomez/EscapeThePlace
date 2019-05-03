using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanelManager : PanelManager
{

    public GameObject itemsGrid;
    public GameObject inventoryItem;
    public GameObject emptyItem;
    public int capacity;

    public SpritesLoader spritesLoader;
    public ItemPanelDetailManager itemPanelDetail;

    private IInventoryRepository itemsRepository;
    private Dictionary<string, Sprite> itemSprites;
    private List<GameObject> displayedItems = new List<GameObject>();

    public override void Show()
    {
        Init();
        var playerItems = itemsRepository.GetItems();
        var emptySlots = capacity - playerItems.Count;

        DisplayPlayerItems(playerItems);
        DisplayEmptyItems(emptySlots);
        base.Show();
    }

    public override void Hide()
    {
        ClearItems();
        base.Hide();
    }

    private void Init()
    {
        if (itemsRepository == null)
        {
            itemsRepository = new InventoryRepository(); // Replace with singleton
        }
        itemSprites = spritesLoader.Sprites;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void DisplayPlayerItems(List<InventoryItem> items)
    {
        foreach (var item in items)
        {
            var uiItem = DisplayItem(inventoryItem);
            var behaviour = uiItem.GetComponent<InventoryItemPrefab>();
            behaviour.SetItem(item);
            behaviour.SetImage(itemSprites[item.name]);
            behaviour.SetOnClick(itemPanelDetail.DisplayItemDetails);
        }
    }

    private void DisplayEmptyItems(int empties)
    {
        for (int i = 0; i < empties; i++)
        {
            DisplayItem(emptyItem);
        }
    }

    private GameObject DisplayItem(GameObject prefab)
    {
        var item = Instantiate(prefab, itemsGrid.transform);
        displayedItems.Add(item);
        return item;
    }

    private void ClearItems()
    {
        foreach (var item in displayedItems)
        {
            Destroy(item);
        }
        displayedItems.Clear();
    }
}
