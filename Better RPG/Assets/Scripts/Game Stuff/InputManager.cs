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
        // Want to make it so player controls are disabled on main menu and UI controls aren't

        // start with Player controls enabled
        ChangeActionMap(inputActions.UI);
    }

    public static void ChangeActionMap(InputActionMap actionMap)
    {
        inputActions.Disable();

        actionMap.Enable();

        Debug.Log("Action Map: " + actionMap.name);
    }
}