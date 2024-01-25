using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private TopDownCharacterController _controller;

    [SerializeField] private Transform bulletPos;
    [SerializeField] private Bullet bullet;
    private Vector2 _bulletDirection = Vector2.right;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    private void Start()
    {
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim;
    }
    private void OnAim(Vector2 newBulletDirection)
    {
        // 마우스 방향으로 조절
        _bulletDirection = newBulletDirection;
    }
    private void OnShoot(PlayerStat playerStat)
    {
        bullet._bulletDirection = _bulletDirection;
        float degree = Mathf.Atan2(_bulletDirection.y, _bulletDirection.x) * Mathf.Rad2Deg;
        bool canShoot = !(degree < -playerStat.attakRange && degree > playerStat.attakRange - 180f);
        if(canShoot) Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
