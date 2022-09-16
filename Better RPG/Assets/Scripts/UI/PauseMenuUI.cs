using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public static event Action OnEscapePressed;

    public GameObject MenuPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        OnEscapePressed?.Invoke();
        MenuPanel.SetActive(!MenuPanel.activeSelf);
    }

    public void ToggleOptionsMenu()
    {
        //MenuPanel.SetActive(false);
        //OptionsPanel.SetActive(true);
    }

    public void ExitToMainMenu()
    {
        // exit save here?
        SceneManager.LoadScene("MainMenu");
    }
}