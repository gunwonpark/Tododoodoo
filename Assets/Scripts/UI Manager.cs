using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   // UI
    [SerializeField] private GameObject MainScreen;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject ResultScreen;
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject GameExit;
    [SerializeField] private GameObject PlayScreen;
    [SerializeField] private GameObject PlayerUpgrade;
    [SerializeField] private GameObject GameOver;
    // 오디오믹서, 볼륨조절 슬라이드
    [SerializeField] private Slider masterVolume_slider;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider bgm_slider;
    [SerializeField] private AudioClip[] bgm_clips;
    [SerializeField] private AudioSource bgm_player;
    [SerializeField] private Slider sfx_slider;
    [SerializeField] private AudioClip[] sfx_clips;
    [SerializeField] private AudioSource sfx_player;

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;

        masterVolume_slider = masterVolume_slider.GetComponent<Slider>();
        bgm_slider = bgm_slider.GetComponent<Slider>();
        sfx_slider = sfx_slider.GetComponent<Slider>();

        masterVolume_slider.onValueChanged.AddListener(SetMasterVolume);
        bgm_slider.onValueChanged.AddListener(SetBgmVolume);
        sfx_slider.onValueChanged.AddListener(SetSfxVolume);

        masterVolume_slider.value = PlayerPrefs.GetFloat("MasterVolume");
        bgm_slider.value = PlayerPrefs.GetFloat("BgmVolume");
        sfx_slider.value = PlayerPrefs.GetFloat("SfxVolume");
    }
    private void Start()
    {
        audioMixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat("MasterVolume")) * 20);
        audioMixer.SetFloat("BGM", Mathf.Log10(PlayerPrefs.GetFloat("BgmVolume")) * 20);
        audioMixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("SfxVolume")) * 20);
    }
    // UI 활성화 버튼
    public void OnClickGameStartBtn()
    {
        MainScreen.SetActive(false);
        PlayScreen.SetActive(true);
        PlayBgm("Main");
        Time.timeScale = 1.0f;
    }
    public void OnClickOptionsBtn()
    {
        Options.SetActive(true);
    }
    public void OnClickOptionsExitBtn()
    {
        Options.SetActive(false);
    }
    public void OnClickGameExitCheckBtn()
    {
        Pause.SetActive(false);
        GameExit.SetActive(true);
    }
    public void OnClickMainScreenBtn()
    {
        SceneManager.LoadScene("UI");
        Time.timeScale = 1.0f;
        //GameExit.SetActive(false);
        //PlayScreen.SetActive(false);
        //MainScreen.SetActive(true);
    }
    public void OnClickCancelBtn()
    {
        GameExit.SetActive(false);
        Pause.SetActive(true);
    }
    public void OnClickPlayContinueBtn()
    {
        Pause.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void OnClickResultScreenExitBtn()
    {
        SceneManager.LoadScene("UI");
        Time.timeScale = 1.0f;
        //ResultScreen.SetActive(false);
        //MainScreen.SetActive(true);
    }
    public void OnClickUpgradeBtn()
    {
        PlayerUpgrade.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void OnClickGameExitBtn()
    {
        GameOver.SetActive(false);
        PlayScreen.SetActive(false);
        ResultScreen.SetActive(true);
    }
    public void OnClickPause()
    {
        Time.timeScale = 0;
        Pause.SetActive(true);
    }
    public void OnClickGameOverBtn() // 게임오버 UI 테스트용 버튼 메서드
    {
        Time.timeScale = 0;
        GameOver.SetActive(true);
    }
    public void OnClickPlayerUpgradeBtn() // 플레이어 업그레이드 UI 테스트용 버튼 메서드
    {
        Time.timeScale = 0;
        PlayerUpgrade.SetActive(true);
    }
    // 볼륨 조절 및 셋팅값 저장
    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }
    public void SetBgmVolume(float value)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("BgmVolume", value);
    }
    public void SetSfxVolume(float value)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SfxVolume", value);
    }
    // 배경음악, 효과음 재생 메서드
    public void PlayBgm(string type)
    {
        if (bgm_player.isPlaying)
            bgm_player.Stop();
        int index = 0;
        switch (type)
        {
            case "Main": index = 0; break;

            default: break;
        }
        bgm_player.clip = bgm_clips[index];
        bgm_player.Play();
    }
    public void PlaySound(string type)
    {
        int index = 0;
        switch (type)
        {
            default: break;
        }
        sfx_player.clip = sfx_clips[index];
        sfx_player.Play();
    }
}
