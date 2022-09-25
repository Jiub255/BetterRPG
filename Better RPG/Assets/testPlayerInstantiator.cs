using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerInstantiator : MonoBehaviour
{
    public GameObject testplayer;

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        GameObject testPlayer = Instantiate(testplayer, Vector3.zero, Quaternion.identity);
    }
}