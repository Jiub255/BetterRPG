using UnityEngine;

public class Interactable : MonoBehaviour
{
    bool objectActive = true;

    public virtual void Interact()
    {
        //this method is meant to be overwritten
        Debug.Log("interacted with " + transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && objectActive && !collision.isTrigger)
        {
            objectActive = false;
            Interact();
        }
    }

/*    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.CompareTag("Player") && objectActive && !collision.isTrigger)
        {
            objectActive = false;
            Interact();
        }
    }*/
}