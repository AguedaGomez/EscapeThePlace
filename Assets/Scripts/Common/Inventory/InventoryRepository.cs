using System.Collections.Generic;

public class InventoryRepository : IInventoryRepository
{
    public static InventoryRepository Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new InventoryRepository();
            }
            return _instance;
        }
    }
    private static InventoryRepository _instance;

    private List<InventoryItem> playerItems = new List<InventoryItem>();

    private InventoryRepository() { }

    public void AddItem(InventoryItem newInventoryItem)
    {
        playerItems.Add(newInventoryItem);
    }

    public List<InventoryItem> GetItems()
    {
        return playerItems;
    }
}