using System.Collections.Generic;

public class FileSystemInventoryRepository : IInventoryRepository
{
    private static readonly string fileName = "player-inventory.dat";
    private FileSystemRepository<InventoryItem> _fileSystemRepository = new FileSystemRepository<InventoryItem>(fileName);

    public void AddItem(InventoryItem newInventoryItem)
    {
        _fileSystemRepository.AddElement(newInventoryItem.name, newInventoryItem);
    }

    public List<InventoryItem> GetItems()
    {
        return new List<InventoryItem>(_fileSystemRepository.GetElements().Values);
    }
}
