using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//makes instances of this class editable from within the inspector
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand = true;
}

public class ObjectPool : MonoBehaviour
{
  //  public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;

/*    private void Awake()
    {
        SharedInstance = this;
    }*/

    private void /*Start*/Awake()
    {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            GameObject tmp;
            for (int i = 0; i < item.amountToPool; i++)
            {
                tmp = Instantiate(item.objectToPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }
        }
    }

    public GameObject GetPooledObject(string tag/*GameObject gameObject*/)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag/*gameObject*/)
            {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tag/*gameObject*/)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }
}