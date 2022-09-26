using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
   // public GameObject virtualCamera;


    /*    private void OnEnable()
        {
            virtualCamera.SetActive(true); //for loading new scenes?
        }*/

    public Cinemachine.CinemachineVirtualCamera c_VirtualCamera;
    [SerializeField] Transform target;

    private void Awake()
    {
        //c_VirtualCamera = GetComponent<Cinemachine.CinemachineVirtualCamera>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Start()
    {
        c_VirtualCamera.m_LookAt = target;
        c_VirtualCamera.m_Follow = target;
    }


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            c_VirtualCamera.gameObject.SetActive(true);
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            c_VirtualCamera.gameObject.SetActive(false);
        }
    }

    //ADD MORE COLLIDERS AROUND DOORS THAT ARE INSIDE A ROOM
}