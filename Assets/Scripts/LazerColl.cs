using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerColl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Ground"))
            return;

        Obstacle obs = collision.GetComponent<Obstacle>();
        if (obs != null)
            obs.GetDamage(float.MaxValue);
    }
}
