using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemActivator : ButtonActivator
{
    public Image itemSprite;
    public string sceneName;
    public GameStages gameStage;

    private InventoryRepository inventoryRepository;
    private GameItems gameItems;

    public override void InitPhase()
    {
        inventoryRepository = GameState.Instance.Inventory;
        gameItems = new GameItems();
        AddItemToInventory();
        base.InitPhase();
    }

    private void AddItemToInventory()
    {
        var newItem = gameItems.GetInventoryItem(itemSprite.sprite.name);
        inventoryRepository.AddItem(newItem);
    }
}
