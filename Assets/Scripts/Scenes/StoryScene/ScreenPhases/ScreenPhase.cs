using System;
using UnityEngine;

public abstract class ScreenPhase: MonoBehaviour
{
    public ScreenPhase activator;
    public event Action OnFinished;

    void Start()
    {
        if (activator == null)
        {
            InitPhase();
        }
        else
        {
            activator.OnFinished += InitPhase;
        }
    }

    protected virtual void InitPhase() { }

    protected void NotifyPhaseFinished()
    {
        OnFinished?.Invoke();
    }
}
