using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{   // UI
    [Header("UI")]
    [SerializeField] private GameObject MainScreen;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject GameExit;
    [SerializeField] private GameObject PlayScreen;
    [SerializeField] private GameObject PlayerUpgrade;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private Text StageCount;
    [SerializeField] private Text AttackCount;
    [SerializeField] private Text JumpCount;
    [SerializeField] private Text SpeedCount;
    // 오디오믹서, 볼륨조절 슬라이드
    [Header("AudioMixer & Volume Slider")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterVolume_slider;
    [SerializeField] private Slider bgm_slider;
    [SerializeField] private Slider sfx_slider;
    // 플레이어
    [Header("Player")]
    [SerializeField] private GameObject Player;

    private void Awake()
    {
        masterVolume_slider = masterVolume_slider.GetComponent<Slider>();
        bgm_slider = bgm_slider.GetComponent<Slider>();
        sfx_slider = sfx_slider.GetComponent<Slider>();

        masterVolume_slider.onValueChanged.AddListener(SetMasterVolume);
        bgm_slider.onValueChanged.AddListener(SetBgmVolume);
        sfx_slider.onValueChanged.AddListener(SetSfxVolume);
    }
    private void Start()
    {// 볼륨, 볼륨 슬라이더 셋팅 PlayerPrefs 저장값으로 초기화
        masterVolume_slider.value = PlayerPrefs.GetFloat("MasterVolume");
        bgm_slider.value = PlayerPrefs.GetFloat("BgmVolume");
        sfx_slider.value = PlayerPrefs.GetFloat("SfxVolume");

        audioMixer.SetFloat("Master", Mathf.Log10(PlayerPrefs.GetFloat("MasterVolume")) * 20);
        audioMixer.SetFloat("BGM", Mathf.Log10(PlayerPrefs.GetFloat("BgmVolume")) * 20);
        audioMixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("SfxVolume")) * 20);

        //event 저장
        GameManager.Instance.Player.GetComponent<TopDownCharacterController>().OnDeadEvent += ShowGameOverUI;
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
    // UI 활성화 버튼 메서드
    public void OnClickGameStartBtn()
    {
        MainScreen.SetActive(false);
        PlayScreen.SetActive(true);
        GameManager.Instance.stageCount = 1;
        StageCount.text = "1";
        AttackCount.text = "0+";
        SpeedCount.text = "0+";
        JumpCount.text = "0+";
        GameManager.Instance.currentState = GameManager.State.Ready;
        AudioManager.Instance.PlayBgm("Playing");
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
        GameExit.SetActive(false);
        PlayScreen.SetActive(false);
        MainScreen.SetActive(true);
        Player.SetActive(false);
        GameManager.Instance.currentState = GameManager.State.Dead;
        AudioManager.Instance.PlayBgm("Main");
        Time.timeScale = 1.0f;
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
    public void OnClickUpgradeBtn()
    {
        PlayerUpgrade.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void OnClickGameExitBtn()
    {
        GameOver.SetActive(false);
        PlayScreen.SetActive(false);
        MainScreen.SetActive(true);
        AudioManager.Instance.PlayBgm("Main");
        Time.timeScale = 1.0f;
    }
    public void OnClickPause()
    {
        Time.timeScale = 0;
        Pause.SetActive(true);
    }
    public void OnClickGameSpeedUpBtn() // 플레이어 업그레이드 테스트용 버튼 메서드
    {
        Time.timeScale = 15;
    }
    public void ShowGameOverUI()
    {
        Time.timeScale = 0;
        GameOver.SetActive(true);
    }
    public void ButtonSound()
    {
        AudioManager.Instance.PlaySound("Button");
    }
}
