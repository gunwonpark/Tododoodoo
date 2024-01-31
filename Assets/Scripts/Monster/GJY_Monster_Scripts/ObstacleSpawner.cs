using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject _obstacle;    

    public void Spawn(Vector2 position)
    {
        // 오브젝트 풀링으로 바뀔예정
        GameObject go = ObjectPool.i.GetFromPool("Block");

        Obstacle obs = go.GetComponent<Obstacle>();        
        obs.Setup(6, SetPosition(position));
    }

    private Vector3 SetPosition(Vector2 position)
    {
        float xPos = Mathf.Round(position.x);
        float yPos = Mathf.Round(position.y);

        return new Vector3(xPos, yPos);
    }
}
