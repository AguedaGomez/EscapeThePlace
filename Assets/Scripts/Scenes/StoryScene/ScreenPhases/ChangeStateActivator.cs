using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStateActivator : ScreenPhase
{

    public string sceneName;
    public string sceneStage;
    // Start is called before the first frame update

    public override void InitPhase()
    {
        GameState.Instance.GameProgress.UpdateSceneProgress(sceneName, sceneStage);
        base.InitPhase();
    }

}
