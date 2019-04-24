using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanelDetailBehavior : MonoBehaviour
{
    public SpritesLoader spritesLoader;
    public Image itemImage;
    public Text itemDescription;

    public void DisplayItemDetails(InventoryItem item)
    {
        var sprites = spritesLoader.Sprites;
        itemImage.sprite = sprites[item.name];
        itemImage.SetNativeSize();

        itemDescription.text = item.description;
        gameObject.SetActive(true);
    }

    public void OnCloseButtonClick()
    {
        
        gameObject.SetActive(false);
        itemImage.sprite = null;
    }
}
