using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 _bulletDirection;
    private float _bulletSpeed = 5f;
    private void Start()
    {
        // 추후 ObejctPooling으로 변환 예정
        Destroy(gameObject, 3f);
    }
    void Update()
    {
        transform.position += (Vector3)_bulletDirection.normalized * _bulletSpeed * Time.deltaTime;
    }
}
