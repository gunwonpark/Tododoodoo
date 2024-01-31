using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterController : MonoBehaviour, IDamagable
{
    [SerializeField] CreatureStatSO _creatureStat;

    [SerializeField] protected float _hp;
    [SerializeField] protected float _maxHp;
    [SerializeField] protected float _moveSpeed;    

    protected Rigidbody2D _rigid;

    protected bool _isInit = false;
    protected bool _isDead = false;

    public virtual void Setup(ObstacleSpawner obstacleSpawner, Transform player) { }

    protected virtual void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _maxHp = _creatureStat.hp;
        _moveSpeed = _creatureStat.speed;
    }

    private void OnEnable()
    {
        _isDead = false;
        _hp = _maxHp;
        _rigid.velocity = Vector2.down * _moveSpeed;
    }

    public void GetDamage(float damage)
    {
        if (_isDead)
            return;

        _hp-=damage;
        if (_hp <= 0)
            Dead();
    }

    public virtual void Dead()
    {
        // Temp Code        
        _isDead = true;
        _rigid.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}
