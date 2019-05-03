using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItems
{
    private Dictionary<string, InventoryItem> allItems = new Dictionary<string, InventoryItem>();
    // Start is called before the first frame update

    public GameItems()
    {
        FillAllItems();
    }

        


    private void FillAllItems()
    {
        allItems.Add("Lantern", new InventoryItem(
        "Lantern",
        "Una linternucha de pilas sulfatadas que todavía funciona para iluminar ligeramente algún objeto."
        ));

        allItems.Add("Notes", new InventoryItem(
            "Notes",
            "Como en cualquier trabajo el primer día llegaste con tu libreta y la mejor actitud del mundo. Apuntaste un montón de cosas, entre ellas algo que podría resultar útil."
        ));
        allItems.Add("CodeList", new InventoryItem(
        "CodeList",
        "Una larga lista con códigos para un montón de cosas, hay uno que suena especialmente útil."
        ));
    }

    public InventoryItem GetInventoryItem (string name)
    {
        return allItems[name];
    }
}
