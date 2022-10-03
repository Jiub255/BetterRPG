using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void KnockBack(float force, Vector3 direction)
    {
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }
}