using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalScreenSwitcher : ScreenSwitcher
{
    public GameObject alternateScreen;
    public string sceneName;

    public override void InitPhase()
    {
        if(GameState.Instance.GameProgress.GetSceneProgress(sceneName) != "1")
            Instantiate(alternateScreen, transform.parent);
        else
            Instantiate(nextScreen, transform.parent);
        Destroy(gameObject);
    }

}
