using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Common : MonsterController
{
    [SerializeField] ObstacleSpawner _obstacleSpawner;

    public override void Setup(ObstacleSpawner obstacleSpawner, Transform player)
    {        
        _obstacleSpawner = obstacleSpawner;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Temp Code
        if (collision.CompareTag("Ground"))
        {
            _obstacleSpawner.Spawn(transform.position);
            Dead();
        }
    }
}
