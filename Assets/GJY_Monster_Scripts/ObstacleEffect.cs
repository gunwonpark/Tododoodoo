using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleEffect : MonoBehaviour
{
    [SerializeField] Sprite[]       _pazeSprites;
    [SerializeField] GameObject     _brokenParticle;    

    public Sprite SpriteChange(int index) => _pazeSprites[index];

    public void SpawnEffect()
    {
        GameObject go = ObjectPool.i.GetFromPool("Particle");
        go.transform.position = transform.position;

        ParticleSystem[] particles = go.GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem particle in particles)
            particle.Play();
    }
}
