using System.Collections;
using UnityEngine;

public class SpellFireball : MonoBehaviour
{
    public Transform player;

    public Animator playerAnimator;

    public ObjectPool objectPool;

    [SerializeField] GameObject fireballPrefab;

/*    void Awake()
    {
        player = GetComponent<Transform>(); 
        playerAnimator = GetComponent<Animator>();
        objectPool = GetComponent<ObjectPool>();   
    }
*/
/*    public void GetPlayerReference(Transform playerTransform)
    {
        player = playerTransform;
        playerAnimator = playerTransform.GetComponent<Animator>();
        objectPool = playerTransform.GetComponent<ObjectPool>();

        Debug.Log("Got Player References");
        Debug.Log(player.name);
    }*/

    public void MakeMagic()
    {
        Debug.Log("MakeMagic invoked"); // this displays in console

        // do i need to attach this to player prefab instead?
        // heal spell works fine and that script is attached to player prefab
        // nope. doesn't work either
        // getting "animator is not playing an animator controller"
        if (playerAnimator.GetFloat("Speed") <= 0.1f) // says this reference is unassigned, but it isn't
        {
            Vector2 temp = new Vector2(playerAnimator.GetFloat("LastHoriz"), playerAnimator.GetFloat("LastVert"));
            GameObject fireball = objectPool.GetPooledObject(fireballPrefab);
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
            GameObject fireball = objectPool.GetPooledObject(fireballPrefab);
            if (fireball != null)
            {
                fireball.transform.position = player.position;
                fireball.transform.rotation = player.rotation;
                fireball.SetActive(true);
            }
            fireball.GetComponent<Fireball>().Setup(temp, Vector3.zero);
        }
    }
}