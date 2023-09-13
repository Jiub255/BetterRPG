using UnityEngine;

[CreateAssetMenu(fileName = "SODG", menuName = "SO/Default", order = 1)]
public class ScriptableObjectGenerics : ScriptableObject
{

    System.Object obj;

    public void Set<T>(T obj) where T : class
    {
        this.obj = obj;
    }

    public T Get<T>() where T : class
    {
        return (T)obj;
    }

    public void Set(System.Object obj)
    {
        this.obj = obj;
    }

    public System.Object Get()
    {
        return obj;
    }
}
