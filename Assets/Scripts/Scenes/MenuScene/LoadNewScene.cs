using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    public void ChangeFirstScene(string name)
    {
        GameState.Instance.currentPlace = "desktop";
        SceneManager.LoadScene(name);
    }
}
