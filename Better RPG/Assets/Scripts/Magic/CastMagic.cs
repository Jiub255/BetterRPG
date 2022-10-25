using UnityEngine;
using UnityEngine.InputSystem;

public class CastMagic : MonoBehaviour
{
    public Spell currentSpell { get; private set; }

    Transform spells;

    // do i need the animator in this script?
    Animator animator;

    [SerializeField] PlayerMagicManager playerMagicManager;

    public float magicTimerLength = 0.4f;
    private float magicTimer;
    public bool canCastSpell { get; private set; } = true;

    // sound effect
    public GameEventAudioClip onPlayClip;

    #region Input System Stuff

    public PlayerInputActions playerControls;

    private InputAction castSpell;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        magicTimer = magicTimerLength;
    }

    private void OnEnable()
    {
        castSpell = playerControls.Player.Cast;
        castSpell.Enable();
        castSpell.performed += CastSpell;

        InventoryMenuUI.OnTogglePause += TogglePlayerControls;
        EscapeMenuUI.OnTogglePause += TogglePlayerControls;
    }

    private void OnDisable()
    {
        castSpell.Disable();

        InventoryMenuUI.OnTogglePause -= TogglePlayerControls;
        EscapeMenuUI.OnTogglePause -= TogglePlayerControls;
    }

    #endregion

    public void GetSpellsReference()
    {
        spells = gameObject.transform.GetChild(1);
    }

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!canCastSpell)
        {
            magicTimer -= Time.deltaTime;

            if (magicTimer <= 0)
            {
                magicTimer = magicTimerLength;
                canCastSpell = true;
                castSpell.Enable();
            }
        }
    }

    void CastSpell(InputAction.CallbackContext context)
    {
        // checks if you have enough mp to cast, and subtracts spell cost from your mp if you do
        if (playerMagicManager.UseMagic(currentSpell.spellCost))
        {
            if (currentSpell != null)
            {
                // want to have a variable event here so you can call any script from the cast button
                currentSpell.spellEffect.Invoke();

                // make a spell animation
                // animator.SetTrigger("AttackTrigger");

                // signal to AudioManager
                onPlayClip.Raise(currentSpell.magicClip);

                canCastSpell = false;
                magicTimer = magicTimerLength;
                castSpell.Disable();
            }
            else
            {
                Debug.Log("No Spell Selected");
            }
        }
    }

    public void ChangeSpell(Spell spell)
    {
        currentSpell = spell;

        Debug.Log("Current Spell: " + spell.name);
    }



    public void TogglePlayerControls(bool gameIsPaused)
    {
        if (gameIsPaused)
        {
            castSpell.Disable();
        }
        else if (!gameIsPaused)
        {
            castSpell.Enable();
        }
    }
}