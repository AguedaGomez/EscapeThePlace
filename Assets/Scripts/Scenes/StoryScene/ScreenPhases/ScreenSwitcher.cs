using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher : ScreenPhase
{
    public GameObject nextScreen;

    protected override void InitPhase()
    {
        Instantiate(nextScreen, transform.parent);
        Destroy(gameObject);
    }
}
