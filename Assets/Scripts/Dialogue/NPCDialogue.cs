using UnityEngine;
using UnityEngine.InputSystem;

public class NPCDialogue : ClickInteract
{
    //ref to intermediate dialog value
    [SerializeField] private TextAssetSO dialogueValue;
    //ref to npc's dialog
    [SerializeField] private TextAsset myDialogue;
    //send signal to canvases
    [SerializeField] private GameEvent dialogueSignal;

    public override void Interact(InputAction.CallbackContext context)
    {
        base.Interact(context);
         
        if (playerInRange)
        {
            dialogueValue.value = myDialogue;
            dialogueSignal.Raise();
            ToggleInteract();
        }
    }
}