using System;
using UnityEngine;

[Serializable]
public class PlayerStat
{
    [Range(5,20)] public float moveSpeed;
    [Range(0, 3)] public float attackDelay;

    public PlayerStat()
    {
        moveSpeed = 5f;
        attackDelay = 0.2f;
    }
}
