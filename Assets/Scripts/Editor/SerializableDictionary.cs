using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<Tkey, TValue> : 
    Dictionary<Tkey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<Tkey> keys = new List<Tkey>();
    [SerializeField]
    private List<TValue> values = new List<TValue>();

    // Save dictionary to lists.
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach (KeyValuePair<Tkey, TValue> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    // Load dictionary from lists.
    public void OnAfterDeserialize()
    {
        this.Clear();

        if (keys.Count != values.Count)
        {
            Debug.LogError("keys and values lists have different Counts");
        }

        for (int i = 0; i < keys.Count; i++)
        {
            this.Add(keys[i], values[i]);
        }
    }
}