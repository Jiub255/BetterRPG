using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool gameIsPaused;

    private void OnEnable()
    {
        InventoryUI.OnToggleInventory += TogglePause;
        PauseMenuUI.OnEscapePressed += TogglePause;
    }

    public void TogglePause()
    {
        gameIsPaused = !gameIsPaused;

        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }
    }

    private void OnDisable()
    {
        InventoryUI.OnToggleInventory -= TogglePause;
        PauseMenuUI.OnEscapePressed -= TogglePause;
    }
}