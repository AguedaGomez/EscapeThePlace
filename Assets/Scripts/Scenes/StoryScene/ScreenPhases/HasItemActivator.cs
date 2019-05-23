using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasItemActivator : ScreenPhase
{
    public ScreenPhase alternativePhase;
    public ScreenPhase normalPhase;
    public override void InitPhase()
    {
        if (GameState.Instance.Inventory.GetItems().Find(it => it.name == "Notes") != null)
            alternativePhase.InitPhase();
        else
            normalPhase.InitPhase();

    }
}
