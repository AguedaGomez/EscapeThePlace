using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPanelManager : PanelManager
{
    public GameObject firstPanel;
    public override void Show()
    {
        Instantiate(firstPanel, transform);
        base.Show();
    }

    public override void Hide()
    {
        
        base.Hide();
    }
}
