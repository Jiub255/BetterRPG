using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] 
    private string sceneToLoad;

    [SerializeField]
    private Vector2 startingPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!collision.isTrigger)
            {
                //StartCoroutine(ChangeSceneCO(/*collision, */sceneToLoad));
                MasterSingleton.Instance.SceneTransitionManager.ChangeScene(
                    sceneToLoad, startingPosition, false);
            }
        }
    }
}