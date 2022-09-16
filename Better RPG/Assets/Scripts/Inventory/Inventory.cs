using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
/*    #region Singleton

    private static Inventory instance;

    public static Inventory Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("more than one instance of Inventory found");
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion*/

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public int money;
    public int arrows;

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room");
            Debug.Log("Add method returned false");
            return false;
        }

        items.Add(item);

        onItemChangedCallback?.Invoke();

        Debug.Log("Add method returned true");
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        onItemChangedCallback?.Invoke();
    }
}