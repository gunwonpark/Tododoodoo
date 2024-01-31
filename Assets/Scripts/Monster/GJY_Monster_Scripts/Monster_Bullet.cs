using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Bullet : MonoBehaviour
{
    private Rigidbody2D _rigid;

    [Range(0, 10)]
    [SerializeField] float _speed;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void Setup(Vector2 dir)
    {
        _rigid.velocity = dir.normalized * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Player"))
            gameObject.SetActive(false);
    }
}
