using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemActivator : ButtonActivator
{
    public Image itemSprite;

    private InventoryRepository inventoryRepository;
    private GameItems gameItems;

    public override void InitPhase()
    {
        DisplayNewItemObtainedPopup();
        inventoryRepository = new InventoryRepository(); //Eliminar
        gameItems = new GameItems();
        AddItemToInventory();
        base.InitPhase();
    }

    private void DisplayNewItemObtainedPopup()
    {
        // Activar panel
    }

    private void AddItemToInventory()
    {
        var newItem = gameItems.GetInventoryItem(itemSprite.sprite.name);
        inventoryRepository.AddItem(newItem);
    }
}
