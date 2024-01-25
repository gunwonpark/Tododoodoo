using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour, IDamagable
{
    [SerializeField] CreatureStatSO _creatureStat;
    [SerializeField] float _hp;
    [SerializeField] float _maxHp;
    [SerializeField] float _moveSpeed;    

    private Rigidbody2D _rigid;
    [SerializeField] ObstacleSpawner _obstacleSpawner;

    private bool _isInit = false;

    // Temp
    private void Awake()
    {
        if (_isInit)
            return;
        _isInit = true;

        _rigid = GetComponent<Rigidbody2D>();        

        _maxHp = _creatureStat.hp;
        _moveSpeed = _creatureStat.speed;

        _rigid.velocity = Vector2.down * _moveSpeed;
    }

    public void Init(ObstacleSpawner obstacleSpawner)
    {
        if (_isInit)
            return;
        _isInit = true;

        _rigid = GetComponent<Rigidbody2D>();
        _obstacleSpawner = obstacleSpawner;

        _maxHp = _creatureStat.hp;
        _moveSpeed = _creatureStat.speed;
    }

    private void OnEnable()
    {
        _hp = _maxHp;        
    }

    private void FixedUpdate()
    {
        //MoveMonster();
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

    private void MoveMonster()
    {
        _rigid.velocity = Vector2.down * _moveSpeed;
    }

    public void GetDamage(float damage)
    {
        _hp-=damage;
        if (_hp <= 0)
            Dead();
    }

    public void Dead()
    {
        // Temp Code
        gameObject.SetActive(false);
    }
}
