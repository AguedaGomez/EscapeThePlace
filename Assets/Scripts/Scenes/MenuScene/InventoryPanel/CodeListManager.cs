using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeListManager : MonoBehaviour
{
    public Text codeListText;
    // Start is called before the first frame update
    void Start()
    {
        FillCodeList();
    }

    private void FillCodeList()
    {
        string text = $@"eo4geo
SEnviro
SUCRE4Kids
29072012
{GameState.Instance.PuzzleAnswers.GetDoorCode()}
sM4RT.Uj1.3s
3rM3s
S.L1br4ry";
        codeListText.text = text;
    }
}
