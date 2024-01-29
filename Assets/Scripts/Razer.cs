using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razer : MonoBehaviour
{
    Rigidbody2D _rigi;
    [SerializeField] LayerMask lay;
    private void Awake()
    {
        _rigi = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        _rigi.AddForce(Vector2.down * 3500);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            collision.GetComponent<Obstacle>()?.GetDamage(200);
        }
        if (collision.gameObject.layer == lay)
        {
            _rigi.velocity = Vector2.zero;
        }
    }
}