using UnityEngine;
using UnityEngine.InputSystem;

public class MagicUI : MonoBehaviour
{
    // new input system stuff
    public PlayerInputActions playerControls;

    private InputAction openInventory;

    public GameObject magicUIPanel;

    [SerializeField] CastMagic castMagic;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        openInventory = playerControls.Player.OpenInventory;
        openInventory.Enable();
        openInventory.performed += OpenMagicMenu;
    }

    private void OnDisable()
    {
        openInventory.Disable();
    }

    void OpenMagicMenu(InputAction.CallbackContext context)
    {
        magicUIPanel.SetActive(!magicUIPanel.activeSelf);
    }

    // have the Magic UI buttons call this method
/*    public void SelectSpell(SpellSO spellSO)
    {
        castMagic.currentSpell = spellSO;
    }*/
}