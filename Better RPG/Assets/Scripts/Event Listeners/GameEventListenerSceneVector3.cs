using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameEventListenerSceneVector3 : MonoBehaviour
{
    public GameEventSceneVector3 Event;
    public UnityEvent<Scene, Vector3> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(Scene Scene, Vector3 vector3)
    {
        Response.Invoke(Scene, vector3);
    }
}