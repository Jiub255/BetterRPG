using UnityEngine;
using UnityEngine.Events;

public class Spell : MonoBehaviour
{
    public UnityEvent spellEffect;

    public int spellCost;

    public AudioClip magicClip;

    public GameEventTransform gameEventTransform;

    private void OnEnable()
    {
        gameEventTransform.Raise(transform);
    }
}