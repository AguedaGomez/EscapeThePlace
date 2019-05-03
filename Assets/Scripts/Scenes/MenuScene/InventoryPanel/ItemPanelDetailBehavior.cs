using UnityEngine;
using UnityEngine.UI;

public class ItemPanelDetailBehavior : MonoBehaviour
{
    public GameObject itemDetailPanel;
    public Text itemDescription;
    public PrefabsLoader prefabsLoader;
    public string ActiveItemName { get => activeItemPrefab.name; }

    private GameObject activeItemPrefab;

    public void DisplayItemDetails(InventoryItem item)
    {
        var itemPrefab = prefabsLoader.Prefabs[item.name];
        activeItemPrefab = Instantiate(itemPrefab, itemDetailPanel.transform);
        activeItemPrefab.name = item.name;

        itemDescription.text = item.description;
        gameObject.SetActive(true);
    }

    public void OnCloseButtonClick()
    {
        gameObject.SetActive(false);
        Destroy(activeItemPrefab);
        activeItemPrefab = null;
    }
}
