using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Range : MonsterController
{
    [SerializeField] GameObject _bulletPrefab;
    //To-Do 원거리 공격을 할 플레이어 Transform 필요
    private Transform _player;
    private float _cooldownTime;

    private readonly float SHOOT_DELAY = 1f;

    private void Update()
    {
        if (_isDead)
            return;

        _cooldownTime += Time.deltaTime;
        if(_cooldownTime > SHOOT_DELAY)
        {
            _cooldownTime = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject go = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        Monster_Bullet mb = go.GetComponent<Monster_Bullet>();
        Vector3 dir = _player.transform.position - transform.position;
        mb.Setup(dir);
    }

    public override void Setup(ObstacleSpawner obstacleSpawner, Transform player)
    {
        // 싱글톤 게임매니저 + 플레이어 가지고 있으면 게임매니저에서 가져오기
        _player = player;
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
