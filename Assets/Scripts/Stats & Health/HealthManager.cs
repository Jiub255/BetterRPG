using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public HealthSO health;

    // just for testing. dont want to heal player/enemies every scene change
    private void Start()
    {
        MaxHeal();
    }

    public void TakeDamage(int amount)
    {
        health.currentValue -= amount;

        if (health.currentValue <= 0)
        {
            health.currentValue = 0;
            Die();
        }
    }

    public void Heal(int amount)
    {
        health.currentValue += amount;

        if (health.currentValue > health.maxValue)
            health.currentValue = health.maxValue;
    }

    public void MaxHeal()
    {
        health.currentValue = health.maxValue;
    }

    // overwrite this for different enemies?
    public virtual void Die()
    {
        Debug.Log(transform.name + " died");
        // send out a "player died" signal to UI, scene manager, whatever
    }
}