using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] float windForce = 5f;
    [SerializeField] float windDuration = 2f;

    private void Update()
    {
        windDuration -= Time.deltaTime;

        if (windDuration < 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<KnockbackEnemy>())
        {
            collision.GetComponent<KnockbackEnemy>().GetKnockedBack(
                this.transform.rotation.eulerAngles.normalized * windForce, 1);
        }
    }
}