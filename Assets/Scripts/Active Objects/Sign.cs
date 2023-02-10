using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Sign : ClickInteract
{
    public static UnityAction<string> signalEventString;

    public StringSO dialog;

    public override void Interact(InputAction.CallbackContext context)
    {
        base.Interact(context);

        if (playerInRange)
        {
            signalEventString?.Invoke(dialog.text);
        }
    }
}