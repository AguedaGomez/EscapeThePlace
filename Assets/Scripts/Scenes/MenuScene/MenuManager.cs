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
        if(progressGame == "new")
        {
            helpPanel.GetComponent<HelpPanelManager>().Show();
            GameState.Instance.GameProgress.UpdateSceneProgress("game", "continuos");
        }
    }
}
