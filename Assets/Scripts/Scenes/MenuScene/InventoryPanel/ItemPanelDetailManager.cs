using UnityEngine;
using UnityEngine.UI;

public class ItemPanelDetailManager : MonoBehaviour
{
    public GameObject itemDetailPanel;
    public Text itemDescription;
    public PrefabsLoader prefabsLoader;

    private GameObject activeItemPrefab;

    public void DisplayItemDetails(InventoryItem item)
    {
        var itemPrefab = prefabsLoader.Prefabs[item.name];
        activeItemPrefab = Instantiate(itemPrefab, itemDetailPanel.transform);

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
