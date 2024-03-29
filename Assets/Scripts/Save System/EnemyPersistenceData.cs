﻿using System.Collections.Generic;

[System.Serializable]
public class EnemyPersistenceData
{
    // global target object ID
    public ulong globalTargetObjectID;

    // health. if zero, deactivate object
    public int currentHealth;

    // dropLoot list. do i need new List<Item>?
    public List<ItemSO> dropLoot = new List<ItemSO>();

    // bool for checking if enemy just died
    public bool dead = false;
}