using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMelee : MonoBehaviour
{
    Animator animator;

    //keep longer than max length of all attack animations
    public float attackTimerLength = 0.4f;
    private float attackTimer;
    public bool canAttack { get; private set; } = true;

    // sound effect
    public GameEventAudioClip onPlayClip;
    public AudioClip swingClip;

    // new input system stuff
    public PlayerInputActions playerControls;

    private InputAction swing;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
        attackTimer = attackTimerLength;
    }

    private void OnEnable()
    {
        swing = playerControls.Player.Swing;
        swing.Enable();
        swing.performed += Swing;
    }

    private void OnDisable()
    {
        swing.Disable();
    }

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // might not need this? animator taking care of it? by using trigger instead of bool for IsAttacking?
    private void Update()
    {
        if (!canAttack)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                attackTimer = attackTimerLength;
                canAttack = true;
                EnableSwing();
            }
        }
    }

    void Swing(InputAction.CallbackContext context)
    {
        animator.SetTrigger("AttackTrigger");

        onPlayClip.Raise(swingClip);

        canAttack = false;
        attackTimer = attackTimerLength;
        DisableSwing();
    }

    public void TogglePlayerControls(bool gameIsPaused)
    {
        if (gameIsPaused)
        {
            DisableSwing();
        }
        else if (!gameIsPaused)
        {
            EnableSwing();
        }
    }

    public void EnableSwing()
    {
        swing.performed += Swing;
    }

    public void DisableSwing()
    {
        swing.performed -= Swing;
    }
}