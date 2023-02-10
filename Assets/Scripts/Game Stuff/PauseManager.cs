using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool gameIsPaused;

    private void OnEnable()
    {
        InventoryMenuUI.OnTogglePause += TogglePause;
        EscapeMenuUI.OnTogglePause += TogglePause;
    }

    private void OnDisable()
    {
        InventoryMenuUI.OnTogglePause -= TogglePause;
        EscapeMenuUI.OnTogglePause -= TogglePause;
    }

    public void TogglePause(bool pausing)
    {
        if (pausing)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;

         //   Debug.Log("Paused");
        }
        else
        {
            Time.timeScale = 1f;
            AudioListener.pause = false;

          //  Debug.Log("Unpaused");
        }
    }
}