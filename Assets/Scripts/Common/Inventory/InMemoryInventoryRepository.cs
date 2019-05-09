using System.Collections.Generic;

public class InMemoryInventoryRepository : IInventoryRepository
{
    private InMemoryRepository<InventoryItem> _playerItems = new InMemoryRepository<InventoryItem>();

    public void AddItem(InventoryItem newInventoryItem)
    {
        _playerItems.AddElement(newInventoryItem.name, newInventoryItem);
    }

    public List<InventoryItem> GetItems()
    {
        return new List<InventoryItem>(_playerItems.GetElements().Values);
    }
}