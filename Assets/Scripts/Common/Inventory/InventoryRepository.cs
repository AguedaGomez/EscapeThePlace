using System.Collections.Generic;

public class InventoryRepository : IInventoryRepository
{
    private List<InventoryItem> playerItems = new List<InventoryItem>();

    public InventoryRepository()
    {
        playerItems.Add(new InventoryItem(
            "Lantern", 
            "Una linternucha de pilas sulfatadas que todavía funciona para iluminar ligeramente algún objeto."
        ));

        playerItems.Add(new InventoryItem(
            "Notes",
            "Como en cualquier trabajo el primer día llegaste con tu libreta y la mejor actitud del mundo. Apuntaste un montón de cosas, entre ellas algo que podría resultar útil."
        ));
    }

    public List<InventoryItem> GetItems()
    {
        return playerItems;
    }
}