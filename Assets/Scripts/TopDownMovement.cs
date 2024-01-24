using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TopDownMovement : MonoBehaviour
{
    TopDownCharacterController _characterController;
    Rigidbody2D _rigidbody;
    Vector2 _moveDirection;
    [SerializeField][Range(10, 1000)] float _moveSpeed;
    void Awake()
    {
        _characterController = gameObject.GetComponent<TopDownCharacterController>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _characterController.OnMoveEvent += Move;
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
        _rigidbody.velocity = _moveDirection * _moveSpeed;
    }
}
