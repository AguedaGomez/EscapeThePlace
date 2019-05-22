using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public Text keyText;
    // Start is called before the first frame update
    void Start()
    {
        ShowKeyText();
    }

    private void ShowKeyText()
    {
        string key = string.Join(",", GameState.Instance.PuzzleAnswers.GetMapSequence());
        keyText.text = "UB1S " + key + " CA";
    }
}
