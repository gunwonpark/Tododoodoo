using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private void Update()
    {
        if(!audioSource.isPlaying)
            gameObject.SetActive(false);
    }
}
