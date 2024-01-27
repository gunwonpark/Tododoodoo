using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shooter { Player, Monster }

public class Bullet : MonoBehaviour
{
    [SerializeField] Sprite enemySprite;
    [SerializeField] Sprite[] _bulletSprites;

    private Shooter _shooter;
    private Vector2 _bulletDirection;

    private Rigidbody2D _rigid;
    private SpriteRenderer _spriteRenderer;
    private float _bulletSpeed = 5f;

    private bool _isHit = false;
    private float _bulletDamage = 5f;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Setup(Shooter shooter, Vector2 direction, float speed)
    {
        _isHit = false;

        _bulletDirection = direction;
        _bulletSpeed = speed;
        _shooter = shooter;
        _spriteRenderer.sprite = enemySprite;

        _rigid.velocity = _bulletDirection * _bulletSpeed;

        if (_shooter == Shooter.Player)
            SetBulletSprite();
    }

    private void SetBulletSprite()
    {        
        _spriteRenderer.sprite = _bulletSprites[Random.Range(0, _bulletSprites.Length)];

        float randZ = Random.Range(0, 360);
        transform.eulerAngles = Vector3.forward * randZ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isHit)
            return;        
        
        if(_shooter == Shooter.Player && (collision.CompareTag("Monster")|| collision.CompareTag("Ground")))
        {
            _isHit = true;
            gameObject.SetActive(false);
            if (collision.CompareTag("Monster"))
            {
                MonsterController ob = collision.GetComponent<MonsterController>();
                ob.GetDamage(_bulletDamage);
            }
            if (collision.CompareTag("Ground"))
            {
                Obstacle ob = collision.GetComponent<Obstacle>();
                if(ob != null)
                {
                    ob.GetDamage(_bulletDamage);
                }
            }
        }
        else if(_shooter == Shooter.Monster && (collision.CompareTag("Player") || collision.CompareTag("Ground")))
        {
            gameObject.SetActive(false);
        }
    }
}
