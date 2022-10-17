using UnityEngine;

public class Interactable : MonoBehaviour
{
    bool objectActive = true;

    public virtual void Interact(Collider2D collision)
    {
        //this method is meant to be overwritten
        Debug.Log("interacted with " + transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && objectActive && !collision.isTrigger)
        {
            objectActive = false;
            Interact(collision);
        }
    }
}