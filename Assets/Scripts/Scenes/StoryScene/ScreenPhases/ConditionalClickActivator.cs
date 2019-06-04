using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalClickActivator : ScreenPhase
{
    public GameObject welcomePanel;
    public ScreenPhase sceneLoader;

    public override void InitPhase()
    {
        var gameState = GameState.Instance.GameProgress.GetSceneProgress("game");
        if (gameState == "1")
        {
            welcomePanel.SetActive(true);
        } else
        {
            sceneLoader.InitPhase();
        }
        base.InitPhase();
    }
}
