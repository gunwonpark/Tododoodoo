using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgm_player;
    [SerializeField] private AudioClip[] bgm_clips;
    [SerializeField] private AudioClip[] sfx_clips;

    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayBgm(string type)
    {
        bgm_player.Stop();
        int index = 0;
        switch (type)
        {
            case "Main": index = 0; break;
            case "Playing": index = 1; break;

            default: break;
        }
        bgm_player.clip = bgm_clips[index];
        bgm_player.Play();
    }
    public void PlaySound(string type)
    {
        GameObject sfx = ObjectPool.i.GetFromPool("Sfx");
        AudioSource audioSource = sfx.GetComponent<AudioSource>();
        int index = 0;
        switch (type)
        {
            case "Shot": index = 0; break;
            case "Hit": index = 1; break;
            case "Destroy": index = 2; break;
            case "Button": index = 3; break;
            case "Laser": index = 4; break;
            case "UpDmg": index = 5; break;
            case "UpAS": index = 6; break;
            case "UpMS": index = 7; break;
            default: break;
        }
        audioSource.clip = sfx_clips[index];
        audioSource.Play();
    }
}
