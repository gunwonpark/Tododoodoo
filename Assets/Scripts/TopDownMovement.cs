using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    TopDownCharacterController _characterController;
    Rigidbody2D _rigidbody;
    SpriteRenderer _characterSprite;
    Vector2 _moveDirection;
    float _moveSpeed = 5f;
    void Awake()
    {
        _characterController = gameObject.GetComponent<TopDownCharacterController>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _characterSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        _characterController.OnMoveEvent += Move;
        _characterController.OnLookEvent += Look;
    }
    void FixedUpdate()
    {
        ApplayMovement();
    }
    private void Look(Vector2 direction)
    {
        _characterSprite.flipX = (direction.x < 0);
    }
    void Move(Vector2 direction)
    {
        _moveDirection = direction;
    }
    void ApplayMovement()
    {
        _rigidbody.velocity = _moveDirection * _moveSpeed;
    }
}
