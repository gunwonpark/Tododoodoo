using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDamagable
{
    private float _hp;

    private bool _isBroken = false;
    private bool _isInit = false;

    public void Setup(float hp, Vector3 position)
    {
        if (!_isInit)
            _isInit = true;

        _hp = hp;
        _isBroken = false;
        transform.position = position;
    }

    public void GetDamage(float damage)
    {
        Debug.Log("Get Damage");
        _hp -= damage;
        if (_hp <= 0)
            Dead();
    }

    public void Dead()
    {
        //To Do : 파괴 호출 후 자신의 위에 위치한 블록들을 이동 시켜야 됨.
        _isBroken = true;
        CheckMyUpPosition();

        gameObject.SetActive(false);
    }    

    private void CheckMyUpPosition()
    {
        Vector2 startRay = transform.position + Vector3.up;
        RaycastHit2D hit = Physics2D.Raycast(startRay, Vector2.one, 0.5f);

        if (hit && hit.collider.CompareTag("Ground"))
        {
            Debug.Log(hit.transform.name);
            hit.transform.GetComponent<Obstacle>().CheckMyUpPosition();            
        }            

        if (!_isBroken)
            MoveDown();
    }

    private void MoveDown()
    {
        transform.position += Vector3.down;
    }
}
