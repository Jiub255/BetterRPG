using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DropLoot : MonoBehaviour
{
    List<Item> itemsToDrop = new List<Item>();

    public GameObject itemPickup;

    private void Start()
    {
        itemsToDrop = GetComponent<Enemy>().itemsToDrop;
    }

    public void DropItem(Item item)
    {
        GameObject droppedItem = Instantiate(itemPickup, transform.position, Quaternion.identity);
        droppedItem.GetComponent<SpriteRenderer>().sprite = item.icon;
        droppedItem.GetComponent<ItemPickup>().item = item;
    }

    // all items drop in the same spot as is
    public void DropItems()
    {
        foreach (Item item in itemsToDrop)
        {
            DropItem(item);
        }
    }
}