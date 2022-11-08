using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMelee : MonoBehaviour
{
    private Animator animator;

    // keep longer than max length of all attack animations
    // just store statSO speed here instead of attacktimerlength, and calculate timer 
    // length based off of the speed statSO
    [SerializeField] 
    private float attackTimerLength = 0.4f;
    private float attackTimer;
    public bool swingActive { get; private set; } = true;
    // Using separate bool here because swingActive affects movement speed,
    // and it was slowing the player for a second whenever getting near signs/NPCs.
    // Can probably think of a better fix, this'll do for now.
    public bool swingEnabled { get; private set; } = true;

    // sound effect
    [SerializeField]
    private GameEventAudioClip onPlayClip;
    [SerializeField]
    private AudioClip swingClip;

    // new input system stuff
    private InputAction swing;

    private void Awake()
    {
        attackTimer = attackTimerLength;
    }

    private void OnEnable()
    {
        StartCoroutine(OnEnableCo());
    }

    // I hate that this works
    IEnumerator OnEnableCo()
    {
        yield return new WaitForEndOfFrame();

        swing = InputManager.inputActions.Player.Swing;
        swing.Enable();
        swing.performed += Swing;
    }

    private void OnDisable()
    {
        swing.Disable();
        swing.performed -= Swing;
    }

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // might not need this? animator taking care of it? by using trigger instead of bool for IsAttacking?
    private void Update()
    {
        if (!swingActive)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                attackTimer = attackTimerLength;
                swingActive = true;
                EnableSwing();
            }
        }
    }

    private void Swing(InputAction.CallbackContext context)
    {
        animator.SetTrigger("AttackTrigger");

        onPlayClip.Raise(swingClip);

        attackTimer = attackTimerLength;
        swingActive = false;
        DisableSwing();
    }

    public void EnableSwing()
    {
        swingEnabled = true;
        swing.performed += Swing;
    }

    public void DisableSwing()
    {
        swingEnabled = false;
        swing.performed -= Swing;
    }

    // listens for dontAttack signal
    // called when near signs, maybe other things
    public void ToggleSwing()
    {
        if (swingEnabled)
            DisableSwing();
        else
            EnableSwing();
    }
}