using UnityEngine;

[RequireComponent(typeof(DropLoot))]
public class ObjectHealthManager : MonoBehaviour
{
    [SerializeField] int numberOfHitsToBreak;

    public GameObject deathAnimation;

    DropLoot dropLoot;

    private void Start()
    {
        dropLoot = GetComponent<DropLoot>();
    }

    public void TakeDamage()
    {
        numberOfHitsToBreak--;

        if (numberOfHitsToBreak <= 0)
        {
            numberOfHitsToBreak = 0;
            Break();
        }
    }

    public void Break()
    {
        Debug.Log(transform.name + " died");

        dropLoot.DropItems();

        // should i destroy/deactivate this when its done playing?
        GameObject deathExplosionInstance = Instantiate(deathAnimation, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}