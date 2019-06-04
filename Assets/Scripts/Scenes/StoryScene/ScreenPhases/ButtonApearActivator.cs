using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonApearActivator : ButtonActivator
{
    public override void InitPhase()
    {
        AddClickListener();
    }
    private void AddClickListener()
    {
        button.gameObject.SetActive(true);
        button.onClick.AddListener(() => NotifyPhaseFinished());
    }

}
