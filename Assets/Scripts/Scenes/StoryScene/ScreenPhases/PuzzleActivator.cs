using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleActivator : ScreenPhase
{
    protected override void InitPhase()
    {
        SetupPuzzle();
    }

    private void SetupPuzzle()
    {
        // Pasos previos para hacer el puzzle interactuable
    }

    public void CheckSolution()
    {
        if (true /* Superado */)
        {
            NotifyPhaseFinished();
        }
    }
}
