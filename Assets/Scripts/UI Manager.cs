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
}
