using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaLeftPanelManager : MonoBehaviour
{
    public void OnConfirmClicked()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
