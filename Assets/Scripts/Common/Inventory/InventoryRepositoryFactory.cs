using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryRepositoryFactory
{
    public static InventoryRepository Create()
    {
#if UNITY_EDITOR
        return new InventoryRepository(new InMemoryRepository<InventoryItem>());
#else
        return new InventoryRepository(new FileSystemRepository<InventoryItem>("player-inventory.dat"));
#endif
    }
}
