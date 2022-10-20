using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static PlayerInputActions inputActions;

    public static bool invMenuOpen = false;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void Start()
    {
        // start with player controller enabled
        ToggleActionMap(inputActions.Player);
    }

    public static void ToggleActionMap(InputActionMap actionMap)
    {
        inputActions.Disable();

        actionMap.Enable();

        Debug.Log("Action Map: " + actionMap.name);
    }
}