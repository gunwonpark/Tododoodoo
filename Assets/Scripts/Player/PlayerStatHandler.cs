using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatHandler : MonoBehaviour
{
    [Header("플레이어 스텟")]
    public PlayerStat _playerStat;
    
    [Header("강화 정도")]
    [SerializeField] float _increaseMoveSpeedRate = 0.2f;
    [SerializeField] float _increaseAttackDamage = 3.0f;
    [SerializeField] float _decreaseAttackDelayRate = 0.02f;

    public void IncreaseMoveSpeed()
    {
        _playerStat.moveSpeed += _increaseMoveSpeedRate;
    }
    public void IncreaseAttackDamage()
    {
        _playerStat.attackDamage += _increaseAttackDamage;
    }
    public void  DecreaseAttackDelay()
    {
        _playerStat.attackDelay -= _decreaseAttackDelayRate;
        if(_playerStat.attackDelay < 0.02f)
        {
            _playerStat.attackDelay = 0.02f;
        }
    }
    public void Init()
    {
        _playerStat.Init();
    }
}
