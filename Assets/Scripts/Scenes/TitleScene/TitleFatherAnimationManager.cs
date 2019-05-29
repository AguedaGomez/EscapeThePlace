using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleFatherAnimationManager : MonoBehaviour
{

    public Animator titleAnimation;
    
    public void FinishTitleEnter()
    {
        titleAnimation.SetTrigger("OpensDoor");
    }

    
}
