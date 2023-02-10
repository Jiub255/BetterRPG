using UnityEngine;

public class LootObjectHealthManager : MonoBehaviour, IDamageable<int>
{
    [SerializeField] 
    private int numberOfHitsToBreak;

    [SerializeField]
    private GameObject deathAnimation;

    public void TakeDamage(int damage)
    { 
        numberOfHitsToBreak--;

        if (numberOfHitsToBreak <= 0)
        {
            numberOfHitsToBreak = 0;
            Die();
        }
    }

    public void Die()
    {
        Debug.Log(transform.name + " broke");

        // should i destroy/deactivate this when it's done playing?
        GameObject deathExplosionInstance = Instantiate(deathAnimation, transform.position, Quaternion.identity);

        // deactivate unbroken component, activate broken
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetComponent<Collider2D>().enabled = false;
    }
}