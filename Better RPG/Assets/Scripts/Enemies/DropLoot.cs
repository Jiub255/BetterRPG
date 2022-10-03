using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DropLoot : MonoBehaviour
{
    List<Item> itemsToDrop = new List<Item>();

    private void Start()
    {
        itemsToDrop = GetComponent<Enemy>().itemsToDrop;
    }


}