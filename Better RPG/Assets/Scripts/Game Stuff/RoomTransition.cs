using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera virtualCamera;
    [SerializeField] Transform target;

    public void GetPlayerReference(Transform player)
    {
        target = player;

        virtualCamera.m_LookAt = target;
        virtualCamera.m_Follow = target;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCamera.gameObject.SetActive(true);
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCamera.gameObject.SetActive(false);
        }
    }

    //ADD MORE COLLIDERS AROUND DOORS THAT ARE INSIDE A ROOM
}