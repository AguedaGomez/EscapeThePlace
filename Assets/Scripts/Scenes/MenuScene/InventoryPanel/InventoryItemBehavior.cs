using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemBehavior : MonoBehaviour
{
    public Image imageComponent;
    private InventoryItem inventoryItem;

    public void SetItem(InventoryItem inventoryItem)
    {
        this.inventoryItem = inventoryItem;
    }

    public void SetImage(Sprite itemImage)
    {
        imageComponent.sprite = itemImage;
        imageComponent.preserveAspect = true;
        imageComponent.SetNativeSize();
    }

    public void SetOnClick(Action<InventoryItem> clickHandler)
    {
        GetComponent<Button>().onClick.AddListener(() => clickHandler(inventoryItem));
    }


}
