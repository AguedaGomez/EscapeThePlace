using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicketCode : MonoBehaviour
{

    public Text code;

    // Start is called before the first frame update
    void Start()
    {
        code.text = GameState.Instance.PuzzleAnswers.GetTicketCode();
    }

    
}
