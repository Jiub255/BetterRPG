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
                swing.performed += Swing;
            }
        }
    }

    void Swing(InputAction.CallbackContext context)
    {
        //Debug.Log("Swing button pressed");

        animator.SetTrigger("AttackTrigger");
        //animator.SetBool("IsAttacking", true);

        canAttack = false;
        attackTimer = attackTimerLength;
        swing.performed -= Swing;
    }

    // not getting called at end of animation by animation event
/*    public void StopAttack()
    {
        Debug.Log("StopAttack called");
        //animator.SetBool("IsAttacking", false);
    }*/
}