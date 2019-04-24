using System.Collections.Generic;

public class InventoryRepository : IInventoryRepository
{
    private List<InventoryItem> playerItems = new List<InventoryItem>();

    public InventoryRepository()
    {
        playerItems.Add(new InventoryItem(
            "Lantern", 
            "Una linternucha de pilas sulfatadas que todavía funciona para iluminar ligeramente algún objeto.",
            @"















														    I
														     L
														      U
														       M
														       I
														        N
														        A
																 !"
        ));

        playerItems.Add(new InventoryItem(
            "Notes",
            "Como en cualquier trabajo el primer día llegaste con tu libreta y la mejor actitud del mundo. Apuntaste un montón de cosas, entre ellas algo que podría resultar útil.",
            @"







		LISTA DE CÓDIGOS: Almacén
        del garaje.

		CAJA DE HERRAMIENTAS: En la
		cocina, debajo del fregadero.











		NOTA: Si lo necesitas, 
		deberías ir a esos sitios y 
		buscar (Pulsando el botón
        BUSCAR)."
        ));
    }

    public List<InventoryItem> GetItems()
    {
        return playerItems;
    }
}