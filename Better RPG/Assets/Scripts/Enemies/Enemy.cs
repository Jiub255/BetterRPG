using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName = "Enter Enemy Name";
    public int maxHealth = 1;
    public int currentHealth = 1;
    public int attack;
    public int defense;
    public int experience;
    public int moveSpeed;
    public int chaseRadius;
    public List<Item> itemsToDrop;

    // not sure about this
    public Guid UniqueId { get; }

    public Enemy()
    {
        UniqueId = Guid.NewGuid();
    }

    // just to see guid in inspector
    [SerializeField] string guid;
    private void Start()
    {
        guid = UniqueId.ToString();
    }
}