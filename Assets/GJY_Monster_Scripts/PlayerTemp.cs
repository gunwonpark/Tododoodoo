using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTemp : MonoBehaviour
{
    private Rigidbody2D rigid;

    [Range(0, 10)] public float speed;
    [Range(0, 10)] public float jumpPower;

    private Vector3 nextVect;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
        Attack();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * speed;
        nextVect = Vector2.right * moveX * Time.fixedDeltaTime;

        transform.position += nextVect;
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 dir = Vector3.right * Input.GetAxisRaw("Horizontal");

            Debug.DrawRay(transform.position, dir, Color.red, 1f);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 0.5f, LayerMask.GetMask("Ground"));            
            if (hit)
            {
                Debug.Log(hit.transform.name);
                Obstacle obs = hit.transform.GetComponent<Obstacle>();
                obs.GetDamage(5);
            }
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rigid.velocity = Vector2.up * jumpPower;
    }
}
