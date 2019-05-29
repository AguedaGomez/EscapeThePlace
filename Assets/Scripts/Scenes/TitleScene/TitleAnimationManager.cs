using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleAnimationManager : MonoBehaviour
{
    public Button start;

    public void FinishTitleOpensDoor()
    {
        start.gameObject.SetActive(true);
    }
}
