using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class SpellSO : ScriptableObject
{
    public UnityEvent spellEffect;

    public int spellCost;

    public AudioClip magicClip;
}