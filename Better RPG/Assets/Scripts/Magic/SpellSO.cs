using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class SpellSO : ScriptableObject
{
    // this only works if the event you call only affects other SO's
    // cant get access to anything in scene
    public UnityEvent spellEffect;

    public int spellCost;

    public AudioClip magicClip;
}