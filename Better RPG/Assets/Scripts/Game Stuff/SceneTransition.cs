using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 startingPosition;

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
        MasterSingleton.Instance.GameManager.SetPlayerPosition(startingPosition);
        Debug.Log("last line of ChangeScene method");
    }
}