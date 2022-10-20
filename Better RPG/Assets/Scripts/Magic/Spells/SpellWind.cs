using UnityEngine;

public class SpellWind : MonoBehaviour
{
    Transform player;

    Animator playerAnimator;

    ObjectPool objectPool;

    [SerializeField] GameObject windPrefab;

    public void GetPlayerReference(Transform playerTransform)
    {
        player = playerTransform;
        playerAnimator = playerTransform.gameObject.GetComponent<Animator>();
        objectPool = playerTransform.gameObject.GetComponent<ObjectPool>();
    }

    public void Blow()
    {
        if (playerAnimator != null)
        {
            GameObject wind = objectPool.GetPooledObject("Wind");
            if (wind != null)
            {
                wind.SetActive(true);
                Debug.Log("wind activated");
            }

            if (playerAnimator.GetFloat("Speed") <= 0.1f)
            {
                Vector2 temp = new Vector2(playerAnimator.GetFloat("LastHoriz"), playerAnimator.GetFloat("LastVert"));
                wind.transform.rotation = Quaternion.Euler(temp);
                wind.transform.position = player.position + Quaternion.Euler(temp).eulerAngles.normalized;
            }
            else
            {
                Vector2 temp = new Vector2(playerAnimator.GetFloat("Horiz"), playerAnimator.GetFloat("Vert"));
                wind.transform.rotation = Quaternion.Euler(temp);
                wind.transform.position = player.position + Quaternion.Euler(temp).eulerAngles.normalized;
            }
        }
        else
        {
            Debug.Log("playerAnimator null", this);
        }
    }
}