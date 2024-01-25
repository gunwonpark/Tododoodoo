using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject MainScreen;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject ResultScreen;
    [SerializeField] private GameObject Pause;
    [SerializeField] private GameObject GameStopCheck;
    [SerializeField] private GameObject PlayScreen;

    public void OnClickGameStartBtn()
    {
        MainScreen.SetActive(false);
        PlayScreen.SetActive(true);
    }
    public void OnClickOptionsBtn()
    {
        Options.SetActive(true);
    }
    public void OnClickOptionsEscBtn()
    {
        Options.SetActive(false);
    }
    public void OnClickGameStopCheckBtn()
    {
        Pause.SetActive(false);
        GameStopCheck.SetActive(true);
    }
    public void OnClickMainScreenBtn()
    {
        GameStopCheck.SetActive(false);
        PlayScreen.SetActive(false);
        MainScreen.SetActive(true);
    }
    public void OnClickCancelBtn()
    {
        GameStopCheck.SetActive(false);
        Pause.SetActive(true);
    }
    public void OnClickPlayContinueBtn()
    {
        Pause.SetActive(false);
    }
    public void OnClickResultScreenEscBtn()
    {
        ResultScreen.SetActive(false);
        MainScreen.SetActive(true);
    }
}
