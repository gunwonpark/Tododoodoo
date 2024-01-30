using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Rush : MonsterController
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    public Sprite _initSprite;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _initSprite = _spriteRenderer.sprite;
    }

    private void OnEnable()
    {
        _hp = _maxHp;
        _rigid.velocity = Vector2.down * _moveSpeed;        
    }

    private void OnDisable()
    {
        _animator.SetTrigger("Reset");
        _spriteRenderer.sprite = _initSprite;
    }

    public override void Setup(ObstacleSpawner obstacleSpawner, Transform player)
    {
        StartCoroutine(RushStandby());
    }

    private IEnumerator RushStandby()
    {
        float current = 0;
        float percent = 0;
        float time_temp = 2f;

        Vector3 startVelocity = _rigid.velocity;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time_temp;

            _rigid.velocity = Vector3.Lerp(startVelocity, Vector3.zero, percent);
            yield return null;
        }

        _rigid.velocity = Vector3.zero;

        _animator.SetTrigger("RushStandby");
    }

    public void OnRush()
    {
        _rigid.velocity = Vector2.down * _moveSpeed * 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Ground"))
        {            
            Dead();
        }
    }

    public override void Dead()
    {
        StopAllCoroutines();
        base.Dead();
    }
}
