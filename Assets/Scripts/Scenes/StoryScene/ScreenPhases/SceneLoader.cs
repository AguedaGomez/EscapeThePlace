using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneLoader : ScreenPhase
{
    public string nameScene;
    public override void InitPhase()
    {
        SceneManager.LoadScene(nameScene);
    }
}
