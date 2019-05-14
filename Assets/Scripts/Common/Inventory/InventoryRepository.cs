using System.Collections.Generic;

public class InventoryRepository
{
    private IRepository<InventoryItem> _playerItems;

    public InventoryRepository(IRepository<InventoryItem> repository)
    {
        _playerItems = repository;
    }

    public void AddItem(InventoryItem newInventoryItem)
    {
        _playerItems.AddElement(newInventoryItem.name, newInventoryItem);
    }

    public List<InventoryItem> GetItems()
    {
        return new List<InventoryItem>(_playerItems.GetElements().Values);
    }
}