using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemActivator : ButtonActivator
{
    protected override void InitPhase()
    {
        DisplayNewItemObtainedPopup();
        AddItemToInventory();
        base.InitPhase();
    }

    private void DisplayNewItemObtainedPopup()
    {
        // Activar panel
    }

    private void AddItemToInventory()
    {
        // Guardar item en el inventario
    }
}
