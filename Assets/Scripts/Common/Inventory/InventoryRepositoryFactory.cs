using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryRepositoryFactory
{
    public static IInventoryRepository Create()
    {
#if UNITY_EDITOR
        return new InMemoryInventoryRepository();
#else
        return new FileSystemInventoryRepository();
#endif
    }
}
