using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    [SerializeField] private GameObject rewardWindow;

    [SerializeField] private Button upgradeBtn1;
    [SerializeField] private Button upgradeBtn2;
    [SerializeField] private Button upgradeBtn3;

    public int attackUpgradeCount;
    public int speedUpgradeCount;
    public int jumpUpgradeCount;

    private void Awake()
    {
        upgradeBtn1.onClick.AddListener(Upgrade1);
        upgradeBtn2.onClick.AddListener(Upgrade2);
        upgradeBtn3.onClick.AddListener(Upgrade3);
    }

    public void StartReward()
    {
        rewardWindow.SetActive(true);
    }

    public void Upgrade1()
    {
        GameManager.Instance.currentState = GameManager.State.Ready;
        Debug.Log("공격력 +" + ++attackUpgradeCount);
        rewardWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Upgrade2()
    {
        GameManager.Instance.currentState = GameManager.State.Ready;
        Debug.Log("공격력 +" + ++speedUpgradeCount);
        rewardWindow.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Upgrade3()
    {
        GameManager.Instance.currentState = GameManager.State.Ready;
        Debug.Log("공격력 +" + ++jumpUpgradeCount);
        rewardWindow.SetActive(false);
        Time.timeScale = 1f;
    }
}
