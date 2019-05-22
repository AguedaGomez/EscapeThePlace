using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPuzzleManager : ScreenPhase
{
    private List<string> correctList = new List<string>();


    [HideInInspector]
    public List<string> currentList = new List<string>();

    void Start()
    {
        correctList = GameState.Instance.PuzzleAnswers.GetMapSequence();
    }

    public void CheckSequence()
    {
        if (correctList.Count != currentList.Count)
            return;
        for (int i = 0; i < correctList.Count; i++)
        {
            if (!currentList.Contains(correctList[i]))
                return;
        }
        
        NotifyPhaseFinished();
    }


}
