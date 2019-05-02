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

    private IInventoryRepository itemsRepository;
    private Dictionary<string, Sprite> itemSprites;

    // Start is called before the first frame update
    void Start()
    {
        itemsRepository = new InventoryRepository();
        itemSprites = spritesLoader.Sprites;

        var playerItems = itemsRepository.GetItems();
        var emptySlots = capacity - playerItems.Count;

        DisplayPlayerItems(playerItems);
        DisplayEmptyItems(emptySlots);
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
