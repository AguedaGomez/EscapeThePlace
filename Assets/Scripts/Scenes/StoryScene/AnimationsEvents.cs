using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsEvents : MonoBehaviour
{
 public void ResetUseAnimator(string variable)
    {
        GetComponent<Animator>().SetBool(variable, false);
    }
}
