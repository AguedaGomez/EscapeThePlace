using System.Collections.Generic;

public interface IInventoryRepository
{
    List<InventoryItem> GetItems();
}
