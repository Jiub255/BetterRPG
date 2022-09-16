using UnityEngine;
using UnityEngine.SceneManagement;

public class TempSceneTransition : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // store player position for when you return to this scene
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}