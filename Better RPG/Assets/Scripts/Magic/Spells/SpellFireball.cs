using System.Collections;
using UnityEngine;

public class SpellFireball : MonoBehaviour
{
    /*public*/ Transform player;

    /*public*/ Animator playerAnimator;

    /*public*/ ObjectPool objectPool;

    [SerializeField] GameObject fireballPrefab;

/*    void Awake()
    {
        player = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
        objectPool = GetComponent<ObjectPool>();
    }*/

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
        Debug.Log("MakeMagic invoked"); // this displays in console

        //Debug.Log(playerAnimator.gameObject.name, this); // this doesn't, but does in GetPlayerReference

        if (playerAnimator != null) // apparently it's null. but why?
        {
            Debug.Log("playerAnimator NOT null");

            // seems to not have reference to animator here, but it does?
            if (playerAnimator.GetFloat("Speed") <= 0.1f)
            {
                Vector2 temp = new Vector2(playerAnimator.GetFloat("LastHoriz"), playerAnimator.GetFloat("LastVert"));
                GameObject fireball = objectPool.GetPooledObject("Fireball");
                if (fireball != null)
                {
                    fireball.transform.position = player.position;
                    fireball.transform.rotation = player.rotation;
                    fireball.SetActive(true);
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
                }
                fireball.GetComponent<Fireball>().Setup(temp, Vector3.zero);
            }
        }
        else
        {
            Debug.Log("playerAnimator null", this); // Why?
            // pretty sure it's because the fireball SpellSO references the 
            // spelleffects prefab to get its unity event.
            // don't think this'll work like this
        }
    }
}