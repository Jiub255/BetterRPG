using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsAttacking", true);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("IsShooting", true);
        }
    }

    public void StopAttack()
    {
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsShooting", false);
    }
}
