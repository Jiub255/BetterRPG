using UnityEngine;

public class SpellButton : MonoBehaviour
{
    [SerializeField] CastMagic playerCastMagic;

    // how to get this reference? with another signal?
    [SerializeField] GameObject spellObject;
    Spell spell;

    public void GetSpellObjectReference(Transform spellObj)
    {
        spellObject = spellObj.gameObject;
        spell = spellObject.GetComponent<Spell>();
    }

    // have a Transform listener on the canvas for this
    // didn't work when i put the listeners on the buttons
    // maybe listeners have to be in parent objects?
    public void GetPlayerReference(Transform playerTransform)
    {
        playerCastMagic = playerTransform.gameObject.GetComponent<CastMagic>();
    }

    // button event in UI does this
    public void Click()
    {
        playerCastMagic.ChangeSpell(spell);
    }
}