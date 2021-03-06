﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivator : ScreenPhase
{
    public Button button;

    public override void InitPhase()
    {
        AddClickListener();
    }

    private void AddClickListener()
    {
        button.onClick.AddListener(() => NotifyPhaseFinished());
    }
}
