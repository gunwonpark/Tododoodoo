using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    PlayerStatHandler _playerStatHandler;
    TopDownCharacterController _characterController;
    Rigidbody2D _rigidbody;
    Vector2 _moveDirection;

    void Awake()
    {
        _characterController = gameObject.GetComponent<TopDownCharacterController>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _playerStatHandler = gameObject.GetComponent<PlayerStatHandler>();
    }
    private void Start()
    {
        _characterController.OnMoveEvent += Move;
        _characterController.OnJumpEvent += Jump;
        _characterController.OnDeadEvent += Dead;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _playerStatHandler._playerStat.jumpDegree, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        ApplayMovement();
    }

    void Move(Vector2 direction)
    {
        _moveDirection = direction;
    }
    void ApplayMovement()
    {
        //Debug.Log(_playerStatHandler._playerStat.moveSpeed);

        _rigidbody.velocity = new Vector2(_moveDirection.x * _playerStatHandler._playerStat.moveSpeed, _rigidbody.velocity.y);
    }
    void Dead()
    {
        GameManager.Instance.currentState = GameManager.State.Dead;
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        _characterController.IsDead = false;
        transform.position = new Vector2(-4,-3);
    }
}
