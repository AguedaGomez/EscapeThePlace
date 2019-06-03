using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject helpPanel;
    // Start is called before the first frame update
    void Start()
    {
        var progressGame = GameState.Instance.GameProgress.GetSceneProgress("game");
        if(progressGame == "1")
        {
            helpPanel.GetComponent<HelpPanelManager>().Show();
        }
    }
}
