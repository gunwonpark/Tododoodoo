using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 _bulletDirection;
    private float _bulletSpeed = 5f;
    void Update()
    {
        transform.position += (Vector3)_bulletDirection.normalized * _bulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster")||collision.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
    }
}
