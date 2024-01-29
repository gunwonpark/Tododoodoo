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

    [SerializeField] Text AttackDelay;
    [SerializeField] Text MoveSpeed;
    [SerializeField] Text JumpDegree;

    private int attackUpgradeCount;
    private int speedUpgradeCount;
    private int jumpUpgradeCount;

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
        AttackDelay.text = attackUpgradeCount.ToString() + "+";
        rewardWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Upgrade2()
    {
        GameManager.Instance.currentState = GameManager.State.Ready;
        Debug.Log("스피드 +" + ++speedUpgradeCount);
        MoveSpeed.text = speedUpgradeCount.ToString() + "+";
        rewardWindow.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Upgrade3()
    {
        GameManager.Instance.currentState = GameManager.State.Ready;
        Debug.Log("점프력 +" + ++jumpUpgradeCount);
        JumpDegree.text = jumpUpgradeCount.ToString() + "+";
        rewardWindow.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ClearStats()
    {
        attackUpgradeCount = 0;
        speedUpgradeCount = 0;
        jumpUpgradeCount = 0;
    }
}
