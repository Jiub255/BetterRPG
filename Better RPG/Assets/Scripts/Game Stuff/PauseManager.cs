using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameEventBool onPauseToggled;

    private void OnEnable()
    {
        InventoryUI.OnToggleInventory += TogglePause;
        PauseMenuUI.OnEscapePressed += TogglePause;
    }

    public void TogglePause()
    {
        gameIsPaused = !gameIsPaused;

        // player listens, to disable/enable playercontrols
        onPauseToggled.Raise(gameIsPaused);

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