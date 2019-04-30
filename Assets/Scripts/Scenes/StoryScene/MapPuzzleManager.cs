using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPuzzleManager : ScreenPhase
{
    public List<Button> correctList = new List<Button>();


    [HideInInspector]
    public List<Button> currentList = new List<Button>();


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
