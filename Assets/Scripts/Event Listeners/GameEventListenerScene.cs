using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameEventListenerScene : MonoBehaviour
{
    public GameEventScene Event;
    public UnityEvent<Scene> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(Scene Scene)
    {
        Response.Invoke(Scene);
    }
}