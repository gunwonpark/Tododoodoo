using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shooter { Player, Monster }

public class Bullet : MonoBehaviour
{
    public Shooter _shooter;

    public Vector2 _bulletDirection;

    private Rigidbody2D _rigid;
    private float _bulletSpeed = 5f;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void Setup(Shooter shooter, Vector2 direction, float speed)
    {
        _bulletDirection = direction;
        _bulletSpeed = speed;
        _shooter = shooter;

        _rigid.velocity = _bulletDirection * _bulletSpeed;
    }    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
        else if(_shooter == Shooter.Player && collision.CompareTag("Monster"))
        {
            gameObject.SetActive(false);
        }
        else if(_shooter == Shooter.Monster && collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
