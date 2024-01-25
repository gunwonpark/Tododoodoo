using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Rush : MonsterController
{
    private void OnEnable()
    {
        _hp = _maxHp;
        _rigid.velocity = Vector2.down * _moveSpeed;
        StartCoroutine(RushStandby());
    }

    private IEnumerator RushStandby()
    {
        float current = 0;
        float percent = 0;
        float time_temp = 2f;

        Vector3 startVelocity = _rigid.velocity;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time_temp;

            _rigid.velocity = Vector3.Lerp(startVelocity, Vector3.zero, percent);
            yield return null;
        }

        _rigid.velocity = Vector3.zero;

        yield return new WaitForSeconds(0.5f);
        Rush();
    }

    private void Rush()
    {
        _rigid.velocity = Vector2.down * _moveSpeed * 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Temp Code
        if (collision.CompareTag("Ground"))
        {            
            Dead();
        }
    }

    public override void Dead()
    {
        StopAllCoroutines();
        base.Dead();
    }
}
