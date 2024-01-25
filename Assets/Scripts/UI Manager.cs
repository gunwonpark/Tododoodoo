using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject MainScreen;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject ResultScreen;
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject GameExit;
    [SerializeField] private GameObject PlayScreen;
    [SerializeField] private GameObject PlayerUpgrade;
    [SerializeField] private GameObject GameOver;

    public void OnClickGameStartBtn()
    {
        MainScreen.SetActive(false);
        PlayScreen.SetActive(true);
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
    }
    public void OnClickCancelBtn()
    {
        GameExit.SetActive(false);
        Pause.SetActive(true);
    }
    public void OnClickPlayContinueBtn()
    {
        Pause.SetActive(false);
    }
    public void OnClickResultScreenExitBtn()
    {
        ResultScreen.SetActive(false);
        MainScreen.SetActive(true);
    }
    public void OnClickUpgradeBtn()
    {
        PlayerUpgrade.SetActive(false);
    }
    public void OnClickGameExitBtn()
    {
        GameOver.SetActive(false);
        PlayScreen.SetActive(false);
        ResultScreen.SetActive(true);
    }
    public void OnClickPause()
    {
        Pause.SetActive(true);
    }
    public void OnClickGameOverBtn() // 게임오버 UI 테스트용 버튼 메서드
    {
        GameOver.SetActive(true);
    }
    public void OnClickPlayerUpgradeBtn() // 플레이어 업그레이드 UI 테스트용 버튼 메서드
    {
        PlayerUpgrade.SetActive(true);
    }
}
