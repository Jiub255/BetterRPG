using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;

    CharacterStats myStats;

    private void Start()
    {
        playerManager = MasterSingleton.Instance.PlayerManager;
        myStats = GetComponent<CharacterStats>();                            
    }

    public override void Interact()
    {
        base.Interact();

        //attack the enemy
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        playerCombat?.Attack(myStats);
    }
}