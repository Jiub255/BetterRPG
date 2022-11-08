using UnityEngine;
using UnityEngine.InputSystem;

public class ClickInteract : MonoBehaviour
{
    public GameEvent dontAttack;
    public GameEvent questionMark;
    public bool playerInRange;
    public bool objectActive = true;

    // new input system stuff
    public PlayerInputActions playerControls;

    private InputAction interact;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        interact = playerControls.Player.Interact;
        interact.Enable();
        interact.performed += Interact;
    }

    private void OnDisable()
    {
        interact.Disable();
        interact.performed -= Interact;
    }

    public virtual void Interact(InputAction.CallbackContext context)
    {
        // meant to be overwritten
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && objectActive && !collision.isTrigger)
        {
            questionMark.Raise();
            dontAttack.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && objectActive && !collision.isTrigger)
        {
            questionMark.Raise();
            dontAttack.Raise();
            playerInRange = false;
        }
    }

    public void ToggleInteract()
    {
        if (interact.enabled)
            interact.Disable();
        else
            interact.Enable();
    }
}