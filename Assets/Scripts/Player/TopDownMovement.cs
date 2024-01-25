using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    PlayerStatHandler _playerStatHandler;
    TopDownCharacterController _characterController;
    Rigidbody2D _rigidbody;
    SpriteRenderer _characterSprite;
    Vector2 _moveDirection;
   
    void Awake()
    {
        _characterController = gameObject.GetComponent<TopDownCharacterController>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _characterSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
        _playerStatHandler = gameObject.GetComponent<PlayerStatHandler>();
    }
    private void Start()
    {
        _characterController.OnMoveEvent += Move;
        _characterController.OnLookEvent += Look;
        _characterController.OnJumpEvent += Jump;
    }

    private void Jump()
    {
        Debug.Log(_playerStatHandler._playerStat.jumpDegree);
        _rigidbody.AddForce(Vector3.up * _playerStatHandler._playerStat.jumpDegree, ForceMode2D.Impulse);
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
        _rigidbody.velocity = new Vector2(_moveDirection.x * _playerStatHandler._playerStat.moveSpeed, _rigidbody.velocity.y);
    }
}
