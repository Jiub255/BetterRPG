using UnityEngine;

public class SpellFireball : MonoBehaviour
{
    Transform player;

    Animator playerAnimator;

   // ObjectPool objectPool;

    [SerializeField] GameObject fireballPrefab;

    public void GetPlayerReference(Transform playerTransform)
    {
        player = playerTransform;
        playerAnimator = playerTransform.gameObject.GetComponent<Animator>();
       // objectPool = playerTransform.gameObject.GetComponent<ObjectPool>();
    }

    public void CreateFireball()
    {
        if (playerAnimator != null) 
        {
            GameObject fireball = MasterSingleton.Instance.ObjectPool.GetPooledObject("Fireball");
            if (fireball != null)
            {
                fireball.transform.position = player.position;
                fireball.transform.rotation = player.rotation;
                fireball.SetActive(true);
                Debug.Log("fireball activated");
            }

            if (playerAnimator.GetFloat("Speed") <= 0.1f)
            {
                Vector2 temp = new Vector2(playerAnimator.GetFloat("LastHoriz"), playerAnimator.GetFloat("LastVert"));
                fireball.GetComponent<Fireball>().Setup(temp, Vector3.zero);
            }
            else
            {
                Vector2 temp = new Vector2(playerAnimator.GetFloat("Horiz"), playerAnimator.GetFloat("Vert"));
                fireball.GetComponent<Fireball>().Setup(temp, Vector3.zero);
            }
        }
        else
        {
            Debug.Log("playerAnimator null", this);
        }
    }
}