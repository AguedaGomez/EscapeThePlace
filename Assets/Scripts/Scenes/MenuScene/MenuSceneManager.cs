using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneManager : MonoBehaviour
{
    #region public
    public List<Button> menuButtons;
    public List<GameObject> menuPanels;
    #endregion

    #region private
    private Dictionary<Button, GameObject> buttonsAndPanels = new Dictionary<Button, GameObject>();
    private GameObject activePanel;

    #endregion

    void Start()
    {
        FillDictionary();
    }

    public void OnMenuButtonClick(Button menuButton)
    {
        activePanel = buttonsAndPanels[menuButton];
        activePanel.SetActive(true);

    }

    public void OnCloseButtonClick()
    {
        activePanel.SetActive(false);
        activePanel = null;
    }

    private void FillDictionary()
    {
        for (int i=0; i < menuButtons.Count; i++ )
        {
            buttonsAndPanels.Add(menuButtons[i], menuPanels[i]);
        }
    }


}
