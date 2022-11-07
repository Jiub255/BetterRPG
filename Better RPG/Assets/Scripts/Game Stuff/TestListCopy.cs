using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestListCopy : MonoBehaviour
{
    public List<int> list = new List<int>();
    public List<int> list2 = new List<int>();

    private void Start()
    {
        list.Add(0);
        list.Add(1);

        list2.Add(2);
        list2.Add(3);

        StartCoroutine(copyList());
    }

    IEnumerator copyList()
    {
        yield return new WaitForSeconds(3f);

        list.Clear();
        //list = list2;

        foreach (int i in list2)
        {
            list.Add(i);
        }
    }
}