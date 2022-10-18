using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CastMagic : MonoBehaviour
{
    public Spell/*SO*/ currentSpell;

    // Non SO attempt
   // public Spell currentSpell2;

    // do i need the animator in this script?
    Animator animator;

    [SerializeField] PlayerMagicManager playerMagicManager;

    public float magicTimerLength = 0.4f;
    private float magicTimer;
    public bool canCastSpell { get; private set; } = true;

    // sound effect
    public GameEventAudioClip onPlayClip;
    
    // new input system stuff
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
    }

    private void OnDisable()
    {
        castSpell.Disable();
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
                EnableCastSpell();
            }
        }
    }

    void CastSpell(InputAction.CallbackContext context)
    {
        // checks if you have enough mp to cast, and subtracts spell cost from your mp if you do
        if (playerMagicManager.UseMagic(currentSpell.spellCost))
        {
            // want to have a variable event here so you can call any script from the cast button
            currentSpell.spellEffect.Invoke();

            // make a spell animation
            // animator.SetTrigger("AttackTrigger");

            // signal to AudioManager
            onPlayClip.Raise(currentSpell.magicClip);

            canCastSpell = false;
            magicTimer = magicTimerLength;
            DisableCastSpell();
        }
    }

    public void ChangeSpell(Spell/*SO*/ spell)
    {
        currentSpell = spell;

        Debug.Log("Spell changed to " + spell.name);
    }

    public void TogglePlayerControls(bool gameIsPaused)
    {
        if (gameIsPaused)
        {
            DisableCastSpell();
        }
        else if (!gameIsPaused)
        {
            EnableCastSpell();
        }
    }

    public void EnableCastSpell()
    {
        castSpell.performed += CastSpell;
    }

    public void DisableCastSpell()
    {
        castSpell.performed -= CastSpell;
    }
}