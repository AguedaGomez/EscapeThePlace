using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpChildManger : MonoBehaviour
{
    public void Hide()
    {
        transform.parent.GetComponent<HelpPanelManager>().Hide();
        Destroy(gameObject);
    }
}
