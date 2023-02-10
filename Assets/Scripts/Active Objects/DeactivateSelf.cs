using UnityEngine;

public class DeactivateSelf : MonoBehaviour
{
    // for calling as animation event when breakable object's death animation is over

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}