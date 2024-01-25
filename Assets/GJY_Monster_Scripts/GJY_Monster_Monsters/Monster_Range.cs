using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Range : MonsterController
{
    // To-Do 원거리 공격을 할 플레이어 Transform 필요
    // private Transform _player

    public override void Setup(ObstacleSpawner obstacleSpawner)
    {        
        // 싱글톤 게임매니저 + 플레이어 가지고 있으면 게임매니저에서 가져오기
        // _player = GameManager.Player 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Temp Code
        if (collision.CompareTag("Ground"))
        {            
            Dead();
        }
    }
}
