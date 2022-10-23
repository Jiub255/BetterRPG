using UnityEngine;
using UnityEngine.EventSystems;

public class DontAttackWhileMouseOverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameEvent dontAttack;

    public void OnPointerEnter(PointerEventData eventData)
    {     
        Debug.Log("Mouse over button");
        dontAttack.Raise();
    }

    public void OnPointerExit(PointerEventData eventData)
    {     
        Debug.Log("Mouse not over button");
        dontAttack.Raise();
    }
}