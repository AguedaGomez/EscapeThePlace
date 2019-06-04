using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionalMenuClickActivator : ScreenPhase
{
    public ScreenPhase sceneLoader;

    public override void InitPhase()
    {
        var gameState = GameState.Instance.GameProgress.GetSceneProgress("game");
        if (gameState == "1")
        {
            sceneLoader.InitPhase();
            GameState.Instance.GameProgress.UpdateSceneProgress("game", "2");
            GameState.Instance.currentPlace = "desktop";
        }
        else
        {
            GetComponent<HelpChildManger>().Hide();
        }
        base.InitPhase();
    }
}
