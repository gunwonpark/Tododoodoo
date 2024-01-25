using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn_Temp : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [SerializeField] Transform[] spawnPoints;

    private ObstacleSpawner obstacleSpawner;

    private void Awake()
    {
        obstacleSpawner = GetComponent<ObstacleSpawner>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SpawnMonster();
    }

    private void SpawnMonster()
    {
        int randMonster = Random.Range(0, prefabs.Length);
        int randPosition = Random.Range(0, spawnPoints.Length);

        GameObject clone = Instantiate(prefabs[randMonster], spawnPoints[randPosition].position, Quaternion.identity);
        
        MonsterController mc = clone.GetComponent<MonsterController>();
        mc.Setup(obstacleSpawner);
    }
}
