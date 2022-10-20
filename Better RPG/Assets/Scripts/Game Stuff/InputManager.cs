using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static PlayerInputActions inputActions;
    public static event Action<InputActionMap> actionMapChange;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    private void Start()
    {
        // start with player controller enabled
        ToggleActionMap(inputActions.Player);

        Debug.Log("Input Manager Start called");
    }

    public static void ToggleActionMap(InputActionMap actionMap)
    {
/*        if (actionMap.enabled)
        {
            Debug.Log("action map enabled, return");
            return;
        }*/

        inputActions.Disable();

        // have playerMovement, playerMelee, InventoryMenuUI, EscapeMenuUI, maybe others,
        // listen for this to change their active action map
    //    actionMapChange?.Invoke(actionMap); 
        // but shouldn't this method change the static instance of inputActions's action map?
        // why should anyone need to listen to this? shouldn't the actions subscribed to things
        // just not work when that action map is disabled?
        
        actionMap.Enable();

        Debug.Log("Action Map: " + actionMap.name);
    }
}