using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumericPanelBehaviour : MonoBehaviour
{
    public Text screenText;
    public string correctCode;
    public int lenghtCode;
    public GameObject parentPanel;

    private PuzzleActivator puzzleActivator;

    // Start is called before the first frame update
    void Start()
    {
        puzzleActivator = parentPanel.GetComponent<PuzzleActivator>();
    }

   public void OnNumericButtonClick(Text value)
   {
        if (value.text == "C")
            ClearCode();
        else if (value.text == "OK")
            CheckCode();
        else if(screenText.text.Length < lenghtCode)
            screenText.text += value.text;
   }

    private void ClearCode()
    {
        screenText.text = "";
    }

    private void CheckCode()
    {
        if (screenText.text == correctCode)
            puzzleActivator.CheckSolution();
        else
        {
            print("códigoIncorrecto");
            ClearCode();
        }
    }
}
