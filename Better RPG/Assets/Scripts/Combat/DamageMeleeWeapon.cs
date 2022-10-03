using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMeleeWeapon : MonoBehaviour
{
    StatManager statManager;

   // [SerializeField] GameEventInt onDamaged;

    private void Awake()
    {
        if (gameObject.GetComponentInParent<StatManager>() != null)
        {
            statManager = gameObject.GetComponentInParent<StatManager>();
        }
        else
        {
            Debug.LogWarning("No StatManager found on player");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // only send OnDamaged signal if collision has HealthManager script
        if (collision.GetComponent<EnemyHealthManager>() != null)
        {

            collision.GetComponent<EnemyHealthManager>().TakeDamage(statManager.attack.GetValue());

            // but will this damage all enemies with a similar listener?
            // maybe need to pass through a unique enemy ID or something too?
           // onDamaged.Raise(statManager.attack.GetValue()); ;
        }
    }
}