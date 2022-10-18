using UnityEngine;

public class SpellFireball : MonoBehaviour
{
    Transform player;

    Animator playerAnimator;

    ObjectPool objectPool;

    [SerializeField] GameObject fireballPrefab;

    public void GetPlayerReference(Transform playerTransform)
    {
        player = playerTransform;
        playerAnimator = playerTransform.gameObject.GetComponent<Animator>();
        objectPool = playerTransform.gameObject.GetComponent<ObjectPool>();

        Debug.Log("Got Player References");
        Debug.Log(player.name);
        Debug.Log(playerAnimator.gameObject.name, this);
    }

    public void MakeMagic()
    {
        if (playerAnimator != null) 
        {
            if (playerAnimator.GetFloat("Speed") <= 0.1f)
            {
                Vector2 temp = new Vector2(playerAnimator.GetFloat("LastHoriz"), playerAnimator.GetFloat("LastVert"));
                GameObject fireball = objectPool.GetPooledObject("Fireball");
                if (fireball != null)
                {
                    fireball.transform.position = player.position;
                    fireball.transform.rotation = player.rotation;
                    fireball.SetActive(true);
                    Debug.Log("fireball activated");
                }
                fireball.GetComponent<Fireball>().Setup(temp, Vector3.zero);
            }
            else
            {
                Vector2 temp = new Vector2(playerAnimator.GetFloat("Horiz"), playerAnimator.GetFloat("Vert"));
                GameObject fireball = objectPool.GetPooledObject("Fireball");
                if (fireball != null)
                {
                    fireball.transform.position = player.position;
                    fireball.transform.rotation = player.rotation;
                    fireball.SetActive(true);
                    Debug.Log("fireball activated");
                }
                fireball.GetComponent<Fireball>().Setup(temp, Vector3.zero);
            }
        }
        else
        {
            Debug.Log("playerAnimator null", this);
        }
    }
}