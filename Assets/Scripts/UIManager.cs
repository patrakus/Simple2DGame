using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    #region MEMBERS

    [SerializeField]
    private GameObject firstUIToSelect;
    [SerializeField]
    private GameObject settingsPanel;
    [SerializeField]
    private GameObject firstUIToSelectInSettings;
    [SerializeField]
    private GameObject mainMenuPanel;

    private bool isSettingPanelVisible;
    
    #endregion

    #region FUNCTIONS

    public void StartGame()
    {
        
    }
    
    public void ShowSettings()
    {
        ChangePanelToSettings();
    }
    
    public void Exit()
    {
        Application.Quit();
    }

    public void ReturnToMainScreen()
    {
        ChangePanelToMainMenu();
    }

    private void ChangePanelToSettings()
    {
        isSettingPanelVisible = true;
        mainMenuPanel.SetActive(isSettingPanelVisible == false);
        settingsPanel.SetActive(isSettingPanelVisible);
        EventSystem.current.SetSelectedGameObject(firstUIToSelectInSettings);

    }
    
    private void ChangePanelToMainMenu()
    {
        isSettingPanelVisible = false;
        mainMenuPanel.SetActive(isSettingPanelVisible == false);
        settingsPanel.SetActive(isSettingPanelVisible);
        EventSystem.current.SetSelectedGameObject(firstUIToSelect);
    }

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstUIToSelect);
    }

    private void Update()
    {
        if (isSettingPanelVisible == true && Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePanelToMainMenu();
        }
    }

    #endregion
}
