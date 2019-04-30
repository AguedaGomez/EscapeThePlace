using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPuzzleManager : MonoBehaviour
{
    public List<Button> correctList = new List<Button>();
    public GameObject panelParent;

    [HideInInspector]
    public List<Button> currentList = new List<Button>();

    private PuzzleActivator puzzleActivator;

    void Start()
    {
        puzzleActivator = panelParent.GetComponent<PuzzleActivator>();
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
        puzzleActivator.CheckSolution();
    }


}
