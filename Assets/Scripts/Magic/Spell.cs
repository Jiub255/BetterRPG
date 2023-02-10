using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Spell : MonoBehaviour
{
    public UnityEvent spellEffect;

    public int spellCost;

    public AudioClip magicClip;

    // player listens to this for CastMagic reference?
    public GameEventTransform onSpellInstantiated;

    private void OnEnable()
    {
        StartCoroutine(delayedSpellInstantiatedSignal());
    }

    IEnumerator delayedSpellInstantiatedSignal()
    {
        yield return new WaitForEndOfFrame()/*WaitForSeconds(0.1f)*/;

        onSpellInstantiated.Raise(transform);
    }
}