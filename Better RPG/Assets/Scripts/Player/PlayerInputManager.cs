using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    public void ToggleActionMap(InputActionMap actionMap)
    {
        if (actionMap.enabled)
            return;

        inputActions.Disable();
       // actionMapChange?.Invoke(actionMap);
        actionMap.Enable();
    }
}